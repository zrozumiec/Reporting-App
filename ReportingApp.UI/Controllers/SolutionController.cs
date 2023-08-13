using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportingApp.Application.ApplicationUser;
using ReportingApp.Application.CQRS.Commands.Failure.EditFailureStatus;
using ReportingApp.Application.CQRS.Commands.Solution.AcceptSolution;
using ReportingApp.Application.CQRS.Commands.Solution.CreateSolution;
using ReportingApp.Application.CQRS.Commands.Solution.DeleteSolution;
using ReportingApp.Application.CQRS.Commands.Solution.EditSolution;
using ReportingApp.Application.CQRS.Queries.Solution.GetAllFailureSolutions;
using ReportingApp.Application.CQRS.Queries.Solution.GetAUserAcceptedSolutions;
using ReportingApp.Application.CQRS.Queries.Solution.GetSolutionById;
using ReportingApp.Application.CQRS.Queries.Solution.GetUserSolutions;
using ReportingApp.Application.CQRS.Queries.Status.GetStatusByName;
using ReportingApp.UI.Models.Calendar;
using ReportingApp.UI.Models.FailureSolutions;

namespace ReportingApp.UI.Controllers
{
    public class SolutionController : Controller
    {
        private const string UserRoleReceiver = "Receiver";
        private const string UserRoleApplicant = "Applicant";
        private const string UserRoleAdmin = "Admin";

        private readonly IMediator mediator;
        private readonly IUserContext userContext;
        private readonly IMapper mapper;

        public SolutionController(IMediator mediator, IUserContext userContext, IMapper mapper)
        {
            this.mediator = mediator;
            this.userContext = userContext;
            this.mapper = mapper;
        }

        [Route("{controller}/{action}/{failureId:int}")]
        public async Task<IActionResult> Index(int failureId)
        {
            var user = this.userContext.GetCurrentUser();
            var failureSolution = new FailureSolutionsVM();
            var solutions = await this.mediator.Send(new GetAllFailureSolutionsQuery(failureId));

            var checkIfUserAlreadyAddSolution = solutions.Any(x => x.UserId == user.Id);

            failureSolution.Failure.Id = failureId;
            failureSolution.Failure.FailureSolutions = solutions;
            failureSolution.AnyAccepted = solutions.Any(x => x.Accepted);
            failureSolution.AccesToAddSolution = (user.ContainRole(UserRoleAdmin) || user.ContainRole(UserRoleReceiver)) && !failureSolution.AnyAccepted && !checkIfUserAlreadyAddSolution;
            failureSolution.AccesToAcceptSolution = (user.ContainRole(UserRoleAdmin) || user.ContainRole(UserRoleApplicant)) && !failureSolution.AnyAccepted;
            failureSolution.CurrentUserId = user.Id;

            return this.View(failureSolution);
        }

        [HttpGet]
        [Authorize(Roles = UserRoleReceiver)]
        [Route("{controller}/{action}/{failureId:int}")]
        public IActionResult Create(int failureId)
        {
            var newSolution = new CreateSolutionCommand();
            newSolution.FailureId = failureId;

            return this.View(newSolution);
        }

        [HttpPost]
        [Authorize(Roles = UserRoleReceiver)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSolutionCommand failureSolution)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(failureSolution);
            }

            var user = this.userContext.GetCurrentUser();

            failureSolution.UserId = user.Id;

            await this.mediator.Send(failureSolution);

            return this.RedirectToAction("Index", "Failure");
        }

        public async Task<IActionResult> Delete(int solutionId)
        {
            await this.mediator.Send(new DeleteSolutionCommand(solutionId));

            return this.RedirectToAction("Index", "Failure");
        }

        [HttpGet]
        [Authorize(Roles = UserRoleReceiver)]
        [Route("{controller}/{action}/{solutionId:int}")]
        public async Task<IActionResult> Edit(int solutionId)
        {
            var solutionDto = await this.mediator.Send(new GetSolutionByIdQuery(solutionId));

            var editsolutionCommand = this.mapper.Map<EditSolutionCommand>(solutionDto);

            return this.View(editsolutionCommand);
        }

        [HttpPost]
        [Authorize(Roles = UserRoleReceiver)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditSolutionCommand editedSolution)
        {
            await this.mediator.Send(editedSolution);

            return this.RedirectToAction("Index", new { failureId = editedSolution.FailureId });
        }

        [Authorize(Roles = UserRoleReceiver)]
        public async Task<IActionResult> MySolutions()
        {
            var userId = this.userContext.GetCurrentUser().Id;

            var solutions = await this.mediator.Send(new GetUserSolutionsQuery(userId));

            return this.View(solutions);
        }

        [Authorize(Roles = UserRoleReceiver)]
        public async Task<IActionResult> MyAcceptedSolutions()
        {
            var userId = this.userContext.GetCurrentUser().Id;

            var solutions = await this.mediator.Send(new GetUserAcceptedSolutionsQuery(userId));

            return this.View(solutions);
        }

        [Authorize(Roles = UserRoleReceiver)]
        public async Task<IActionResult> MyAcceptedSolutionsCalendar()
        {
            var userId = this.userContext.GetCurrentUser().Id;
            var events = await CalendarEvent.FillCalendarWithSolutionsEvents(userId, this.mediator);

            return this.View(events);
        }

        [Authorize(Roles = UserRoleApplicant)]
        public async Task<IActionResult> AcceptSolution(int solutionId, int failureId)
        {
            var status = await this.mediator.Send(new GetStatusByNameQuery("In progress"));
            await this.mediator.Send(new EditFailureStatusCommand(failureId, status.Id));
            await this.mediator.Send(new AcceptSolutionCommand(solutionId));

            return this.RedirectToAction("Index", "Failure");
        }
    }
}
