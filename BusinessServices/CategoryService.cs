using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopMart.BusinessServices
{
    public class CategoryService : ICategoryService
    {
        private  LapShopContext _context { get; set; }
        public CategoryService(LapShopContext context)
        {
            _context = context;
        }


        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                var categories = _context.TbCategories;
                return categories;

            }catch(Exception ex)
            {
                return new List<Category>();
            }
        }


        public void AddCategory(Category category)
        {
            try
            {
                _context.TbCategories.Add(category);
                _context.SaveChanges();
          

            }catch(Exception ex)
            {
                return; 
            }
        }


        public Category GetCategoryById(int id)
        {
            try
            {
              var category =  _context.TbCategories.Where(c=>c.categoryId==id).FirstOrDefault();
              return category;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
            public void UpdateCategory(Category category)  {

            try
            {
                _context.Entry(category).State = EntityState.Modified;
                category.createdBy = "1";
                category.imageName = "";
                category.updatedDate = DateTime.Now;
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            }


         public void RemoveCategory(int id)  {

            try
            {
                var categoryToRemove = GetCategoryById(id);
                _context.TbCategories.Attach(categoryToRemove);
                _context.TbCategories.Remove(categoryToRemove);
  
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            }


    }
}
