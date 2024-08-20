using Expense.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expense.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryInterface categoryInterface;

        public CategoryController(CategoryInterface categoryInterface)
        {
            this.categoryInterface = categoryInterface;
        }

        public IActionResult Index()
        {
            var Allcategory = categoryInterface.GetAllCategory();
            return View(Allcategory);
        }

        [HttpGet]
        public IActionResult CategoryDetails(int Id)
        {
            Category category = categoryInterface.GetCategorybyId(Id);
            return View(category);
        }
        public IActionResult CreateCategory()
        {
            return View(new Category());
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryInterface.AddCategory(category);
            }
                return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int Id)
        {
            Category Newcategory = categoryInterface.DeleteCategory(Id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            categoryInterface.UpdateCategory(category);

            return RedirectToAction("Index");
        }
    }
}
