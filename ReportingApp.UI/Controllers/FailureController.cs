using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReportingApp.Application.CQRS.Commands.Failure.DeleteFailure;
using ReportingApp.Application.CQRS.Commands.Failure.EditFailure;
using ReportingApp.Application.CQRS.Commands.Failure.EditFailureStatus;
using ReportingApp.Application.CQRS.Commands.FailureType.GetFailureTypeById;
using ReportingApp.Application.CQRS.Commands.Solution.AcceptSolution;
using ReportingApp.Application.CQRS.Queries.Category.GetAllCategories;
using ReportingApp.Application.CQRS.Queries.Category.GetCategoryById;
using ReportingApp.Application.CQRS.Queries.Failure.GetAllFailures;
using ReportingApp.Application.CQRS.Queries.Failure.GetFailureById;
using ReportingApp.Application.CQRS.Queries.Solution.GetAllFailureSolutions;
using ReportingApp.Application.CQRS.Queries.Status.GetStatusByName;
using ReportingApp.Application.DTO;
using ReportingApp.UI.Models.FailureSolutions;
using ReportingApp.UI.Models.FailureVM;

namespace ReportingApp.UI.Controllers
{
    //[Authorize]
    public class FailureController : Controller
    {
        private readonly IMediator mediator;

        public FailureController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var failures = await this.mediator.Send(new GetAllFailuresQuery());
            // TODO:
            //var failures = await this.mediator.Send(new GetAllUserFailures());
            return this.View(failures);
        }

        public async Task<IActionResult> Details(int failureId)
        {
            var failure = await this.mediator.Send(new GetFailureByIdQuery(failureId));

            return this.View(failure);
        }

        public async Task<IActionResult> Solutions(int failureId)
        {
            var failureSolution = new FailureSolutionsVM();
            var solutions = await this.mediator.Send(new GetAllFailureSolutionsQuery(failureId));

            failureSolution.Solutions = solutions;
            failureSolution.AnyAccepted = solutions.Any(x => x.Accepted);

            return this.View(failureSolution);
        }

        [HttpGet]
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewFailureVM newFailure)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var status = await this.mediator.Send(new GetStatusByNameQuery("New"));
            newFailure.CreateFailureCommand.StatusId = status.Id;
            newFailure.CreateFailureCommand.Status = null!;
            newFailure.CreateFailureCommand.FailureTypes = await this.AddNewFailuryTypesToFailure(newFailure.AddMoreFailureTypes, newFailure.CreateFailureCommand.FailureTypes);

            await this.mediator.Send(newFailure.CreateFailureCommand);

            return this.RedirectToAction("Index");
        }

        [Route("{controller}/{action}/{failureId:int}")]
        [HttpGet]
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

        public async Task<IActionResult> Delete(int failureId)
        {
            await this.mediator.Send(new DeleteFailureCommand(failureId));

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> AcceptSolution(int solutionId, int failureId)
        {
            var status = await this.mediator.Send(new GetStatusByNameQuery("In progress"));
            await this.mediator.Send(new EditFailureStatusCommand(failureId, status.Id));
            await this.mediator.Send(new AcceptSolutionCommand(solutionId));

            return this.RedirectToAction("Index");
        }

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

        public async Task<IActionResult> RemoveFailureTypeFromFailure(int failureId, int failureTypeId)
        {
            await this.mediator.Send(new DeleteFailureTypeByIdCommand(failureTypeId));
            var failure = await this.mediator.Send(new GetFailureByIdQuery(failureId));

            return this.PartialView("_RemoveFailureType", failure);
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
