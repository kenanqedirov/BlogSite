using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        private readonly ICategoryService _categoryManager;

        public CategoryListDashboard(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryManager.GetList();
            return View(values);
        }
    }
}
