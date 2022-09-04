using System.Collections.Generic;
using LaptopMart.Models;

namespace LaptopMart.Interfaces.IBusinessServices
{
    public interface IItemTypeService
    {
        public IEnumerable<ItemType> GettAllItemTypes();

        public ItemType GetItemTypeById(int id);


        public void AddItemType(ItemType ItemType);

        public void UpdateItemType(ItemType ItemType);

        public void DeleteItemType(int id);

        }
    }
