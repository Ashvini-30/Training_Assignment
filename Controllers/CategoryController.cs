#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication3.Models;
using WebApplication3.Repository;

#endregion

namespace WebApplication3.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        [HttpGet]
        public async Task<List<Category>> List()
        {
            return await _categoryRepository.GetAllCategoryList();
        }

        [HttpPost]
        public async Task<List<Category>> AddCategory(Category model)
        {
            return await _categoryRepository.AddCategory(model);
        }
    }
}