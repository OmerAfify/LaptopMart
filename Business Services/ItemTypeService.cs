using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopMart.BusinessServices
{
    public class ItemTypeService : IItemTypeService
    {
        private  LapShopContext _context { get; set; }
        public ItemTypeService(LapShopContext context)
        {
            _context = context;
        }


        public IEnumerable<ItemType> GettAllItemTypes()
        {
            try
            {
                var ItemTypeTypesList = _context.TbItemTypes;
                return ItemTypeTypesList;

            }catch(Exception ex)
            {
                return new List<ItemType>();
            }
        }
        public ItemType GetItemTypeById(int id)
        {
            try
            {
                var ItemType = _context.TbItemTypes.Where(c => c.itemTypeId == id).FirstOrDefault();
                return ItemType;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void AddItemType(ItemType ItemType)
        {
            try
            {
                _context.TbItemTypes.Add(ItemType);
                _context.SaveChanges();
          

            }catch(Exception ex)
            {
                return; 
            }
        }
        public void UpdateItemType(ItemType ItemType)  {

          try
            {
                _context.Entry(ItemType).State = EntityState.Modified;
                ItemType.createdBy = "1";
                ItemType.updatedDate = DateTime.Now;

                if (ItemType.imageName == null)
                    ItemType.imageName = "";

                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            }
        public void DeleteItemType(int id)  {

            try
            {
                var ItemTypeToRemove = this.GetItemTypeById(id);
                _context.TbItemTypes.Attach(ItemTypeToRemove);
                _context.TbItemTypes.Remove(ItemTypeToRemove);
  
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            }


    }
}
