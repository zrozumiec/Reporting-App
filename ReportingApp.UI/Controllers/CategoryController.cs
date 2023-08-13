using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportingApp.Application.CQRS.Commands.Category.CreateCategory;
using ReportingApp.Application.CQRS.Commands.Category.DeleteCategory;
using ReportingApp.Application.CQRS.Commands.Category.EditCategory;
using ReportingApp.Application.CQRS.Queries.Category.GetAllCategories;
using ReportingApp.Application.CQRS.Queries.Category.GetCategoryById;

namespace ReportingApp.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categoriesDto = await this.mediator.Send(new GetAllCategoriesQuery());

            return this.View(categoriesDto);
        }

        [Route("{controller}/{action}/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var categoryDto = await this.mediator.Send(new GetCategoryByIdQuery(id));

            return this.View(categoryDto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View(new CreateCategoryCommand());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryCommand category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.mediator.Send(category);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{controller}/{action}/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDto = await this.mediator.Send(new GetCategoryByIdQuery(id));

            var query = this.mapper.Map<EditCategoryCommand>(categoryDto);

            return this.View(query);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCategoryCommand editedCategory)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.mediator.Send(editedCategory);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new DeleteCategoryCommand(id));

            return this.RedirectToAction("Index");
        }
    }
}
