using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Models;

namespace LaptopMart.Interfaces.IBusinessServices
{
         public interface IItemService {
  
         
            public IEnumerable<Item> GetAllItems();
            public IEnumerable<VwItemCategory> GetAllItemsCategoriesView();
            public VwItem GetItemView(int id);

            public IEnumerable<Item> GetRecomendedItems(int id);
            public Item GetItemById(int id);
            public  Task<Item> GetItemByIdAsync(int id);
     
            public void AddItem(Item Item);
            public void UpdateItem(Item Item);
            public void DeleteItem(int id);

}
}
