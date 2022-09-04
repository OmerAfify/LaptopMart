using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopMart.BusinessServices
{
    public class ItemService : IItemService
    {
        private  LapShopContext _context { get; set; }
        public ItemService(LapShopContext context)
        {
            _context = context;
        }


        public IEnumerable<Item> GetAllItems()
        {
            try
            {
                var items = _context.TbItems;
                return items;

            }catch(Exception ex)
            {
                return new List<Item>();
            }
        }

        public IEnumerable<VwItemCategory> GetAllItemsCategoriesView()
        {
            try
            {
                var items = _context.VwItemCategories;
                return items;

            }
            catch (Exception ex)
            {
                return new List<VwItemCategory>();
            }
        }


        public Item GetItemById(int id)
        {
            try
            {
                var Item = _context.TbItems.Where(c => c.itemId == id).FirstOrDefault();
                return Item;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<Item> GetItemByIdAsync(int id)
        {
            try
            {
                var Item = await _context.TbItems.Where(c => c.itemId == id).FirstOrDefaultAsync();
                return Item;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void AddItem(Item Item)
        {
            try
            {
                _context.TbItems.Add(Item);
                _context.SaveChanges();
          

            }catch(Exception ex)
            {
                return; 
            }
        }

        public void UpdateItem(Item item)  {

          try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            }

         public void DeleteItem(int id)  {

            try
            {
                var ItemToRemove = GetItemById(id);
                _context.TbItems.Attach(ItemToRemove);
                _context.TbItems.Remove(ItemToRemove);
  
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            }


    }
}
