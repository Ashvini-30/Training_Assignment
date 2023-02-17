#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;

#endregion

namespace WebApplication3.Repository
{
    public interface ICategoryInterface
    {
        Task<List<Category>> GetAllCategoryList();
        Task<List<Category>> AddCategory(Category category);

    }
}
