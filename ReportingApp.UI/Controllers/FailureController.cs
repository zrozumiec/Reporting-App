﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReportingApp.Application.ApplicationUser;
using ReportingApp.Application.CQRS.Commands.Failure.DeleteFailure;
using ReportingApp.Application.CQRS.Commands.Failure.EditFailure;
using ReportingApp.Application.CQRS.Commands.FailureType.GetFailureTypeById;
using ReportingApp.Application.CQRS.Queries.Category.GetAllCategories;
using ReportingApp.Application.CQRS.Queries.Category.GetCategoryById;
using ReportingApp.Application.CQRS.Queries.Failure.GetAllFailures;
using ReportingApp.Application.CQRS.Queries.Failure.GetAllUserFailures;
using ReportingApp.Application.CQRS.Queries.Failure.GetFailureById;
using ReportingApp.Application.CQRS.Queries.Status.GetStatusByName;
using ReportingApp.Application.DTO;
using ReportingApp.UI.Models.Calendar;
using ReportingApp.UI.Models.FailureSolutions;
using ReportingApp.UI.Models.FailureVM;

namespace ReportingApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FailureController : Controller
    {
        private const string UserRoleReceiver = "Receiver";
        private const string UserRoleApplicant = "Applicant";
        private const string UserRoleAdmin = "Admin";

        private readonly IMediator mediator;
        private readonly IUserContext userContext;

        public FailureController(IMediator mediator, IUserContext userContext)
        {
            this.mediator = mediator;
            this.userContext = userContext;
        }

        public async Task<IActionResult> Index()
        {
            var user = this.userContext.GetCurrentUser();
            var failures = new FailuresListVM();

            if (user.ContainRole(UserRoleReceiver))
            {
                failures.Failures = await this.mediator.Send(new GetAllFailuresQuery());
                failures.AccesToEdit = false;

                return this.View(failures);
            }
            else if (user.ContainRole(UserRoleApplicant) || user.ContainRole(UserRoleAdmin))
            {
                failures.Failures = await this.mediator.Send(new GetAllUserFailuresQuery(user.Id));
                failures.AccesToEdit = true;

                return this.View(failures);
            }

            return this.RedirectToAction("Error", "Home");
        }

        [Route("{controller}/{action}/{failureId:int}")]

        public async Task<IActionResult> Details(int failureId)
        {
            var failureSolutions = new FailureSolutionsVM();
            var user = this.userContext.GetCurrentUser();
            var failure = await this.mediator.Send(new GetFailureByIdQuery(failureId));
            var accesToEdit = user.ContainRole(UserRoleApplicant);

            failureSolutions.Failure = failure;
            failureSolutions.AccesToAcceptSolution = accesToEdit;
            failureSolutions.CurrentUserId = user.Id;
            failureSolutions.AnyAccepted = failure.AnySolutionAccepted;

            return this.View(failureSolutions);
        }

        [HttpGet]
        [Authorize(Roles = UserRoleApplicant)]

        public async Task<IActionResult> Create()
        {
            var createFailure = new AddFailureVM();
            var categories = await this.mediator.Send(new GetAllCategoriesQuery());

            foreach (var c in categories)
            {
                createFailure.FailureCategoriesSelectedList.Categories.Add(new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            }

            return this.View(createFailure);
        }

        [HttpPost]
        [Authorize(Roles = UserRoleApplicant)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewFailureVM newFailure)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = this.userContext.GetCurrentUser();
            var status = await this.mediator.Send(new GetStatusByNameQuery("New"));

            newFailure.CreateFailureCommand.StatusId = status.Id;
            newFailure.CreateFailureCommand.FailureTypes = await this.AddNewFailuryTypesToFailure(newFailure.AddMoreFailureTypes, newFailure.CreateFailureCommand.FailureTypes);
            newFailure.CreateFailureCommand.UserId = user.Id;

            await this.mediator.Send(newFailure.CreateFailureCommand);

            return this.RedirectToAction("Index");
        }

        [Route("{controller}/{action}/{failureId:int}")]
        [HttpGet]
        [Authorize(Roles = UserRoleApplicant)]
        public async Task<IActionResult> Edit(int failureId)
        {
            var failure = await this.mediator.Send(new GetFailureByIdQuery(failureId));
            var editFailure = new EditFailureVM();
            var categories = await this.mediator.Send(new GetAllCategoriesQuery());

            foreach (var c in categories)
            {
                editFailure.FailureCategoriesSelectedList.Categories.Add(new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            }

            editFailure.EditFailureCommand.Failure = failure;

            return this.View(editFailure);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRoleApplicant)]
        public async Task<IActionResult> Edit(EditFailureVM newFailure)
        {
            if (newFailure.AddMoreFailureTypes.Any() && !string.IsNullOrEmpty(newFailure.AddMoreFailureTypes.First().Description))
            {
                newFailure.EditFailureCommand.Failure.FailureTypes = await this.AddNewFailuryTypesToFailure(newFailure.AddMoreFailureTypes, newFailure.EditFailureCommand.Failure.FailureTypes);
            }

            var editFailureCommand = new EditFailureCommand
            {
                Failure = newFailure.EditFailureCommand.Failure
            };

            await this.mediator.Send(editFailureCommand);

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = UserRoleApplicant)]
        public async Task<IActionResult> Delete(int failureId)
        {
            await this.mediator.Send(new DeleteFailureCommand(failureId));

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = UserRoleApplicant)]
        public async Task<IActionResult> BlankSentence()
        {
            var createFailure = new FailureCategoriesSelectedList();
            var categories = await this.mediator.Send(new GetAllCategoriesQuery());

            foreach (var c in categories)
            {
                createFailure.Categories.Add(new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            }

            return this.PartialView("_AddFailureType", createFailure);
        }

        [Authorize(Roles = UserRoleApplicant)]
        public async Task<IActionResult> RemoveFailureTypeFromFailure(int failureId, int failureTypeId)
        {
            await this.mediator.Send(new DeleteFailureTypeByIdCommand(failureTypeId));
            var failure = await this.mediator.Send(new GetFailureByIdQuery(failureId));

            return this.PartialView("_RemoveFailureType", failure);
        }

        [Authorize(Roles = UserRoleApplicant)]

        public async Task<IActionResult> MyAcceptedFailuresCalendar()
        {
            var userId = this.userContext.GetCurrentUser().Id;
            var events = await CalendarEvent.FillCalendarWithFailureEvents(userId, this.mediator);

            return this.View(events);
        }

        private async Task<ICollection<FailureTypeDto>> AddNewFailuryTypesToFailure(List<AddFailureTypeToFailure> failureTypesToAdd, ICollection<FailureTypeDto> failureTypes)
        {
            foreach (var failureType in failureTypesToAdd)
            {
                int.TryParse(failureType.SelectedCategory, out var categoryId);
                var category = await this.mediator.Send(new GetCategoryByIdQuery(categoryId));
                var type = new FailureTypeDto();
                type.Description = failureType.Description;
                type.CategoryId = category.Id;
                type.Category = null!;
                failureTypes.Add(type);
            }

            return failureTypes;
        }
    }
}
