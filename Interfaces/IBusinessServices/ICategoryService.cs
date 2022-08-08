using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.Interfaces.IBusinessServices
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        public void UpdateCategory(Category category);
        public void AddCategory(Category category);
        public void RemoveCategory(int id);
    }
}
