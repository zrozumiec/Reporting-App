using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportingApp.Application.CQRS.Commands.Status.CreateStatus;
using ReportingApp.Application.CQRS.Commands.Status.DeleteStatus;
using ReportingApp.Application.CQRS.Commands.Status.EditStatus;
using ReportingApp.Application.CQRS.Queries.Status.GetAllStatuses;
using ReportingApp.Application.CQRS.Queries.Status.GetStatusById;

namespace ReportingApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatusController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public StatusController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var statuses = await this.mediator.Send(new GetAllStatusesQuery());

            return this.View(statuses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View(new CreateStatusCommand());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStatusCommand command)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(command);
            }

            await this.mediator.Send(command);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{controller}/{action}/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var status = await this.mediator.Send(new GetStatusByIdQuery(id));

            var editCommand = this.mapper.Map<EditStatusCommand>(status);

            return this.View(editCommand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditStatusCommand command)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(command);
            }

            await this.mediator.Send(command);

            return this.RedirectToAction("Index");
        }

        [Route("{controller}/{action}/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var status = await this.mediator.Send(new GetStatusByIdQuery(id));

            return this.View(status);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new DeleteStatusCommand(id));

            return this.RedirectToAction("Index");
        }
    }
}
