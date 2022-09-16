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


        public IEnumerable<VwItem> GetAllVwItems()
        {
            try
            {
                var items = _context.VwItems;
                return items;

            }
            catch (Exception ex)
            {
                return new List<VwItem>();
            }
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

        public VwItem GetItemView(int id)
        {
            try
            {
                var itemView = _context.VwItems.Where(i=>i.itemId == id).FirstOrDefault();
                return itemView;
            }
            catch (Exception ex)
            {
                return new VwItem();
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

        
        //logic is getting products with range ' price-50 < price < price + 50 ' as well as of the same category.
        public IEnumerable<Item> GetRecomendedItems(int id)
        {
            try
            {
                var price = this.GetItemById(id).salesPrice;
                var categoryId = this.GetItemById(id).categoryId;
                var RecomendedItemsList = _context.TbItems.Where(c => (c.itemId !=id) &&
                (c.salesPrice > price-50 && c.salesPrice< price+50 ) &&
                (c.categoryId == categoryId));

                return RecomendedItemsList;

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
