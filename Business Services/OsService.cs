using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopMart.Interfaces.IBusinessServices;
using LaptopMart.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopMart.BusinessServices
{
    public class OsService : IOsService
    {
        private  LapShopContext _context { get; set; }
        public OsService(LapShopContext context)
        {
            _context = context;
        }

        public IEnumerable<OS> GetAllOS()
        {
            try
            {
                var OSList = _context.TbOs;
                return OSList;

            }catch(Exception ex)
            {
                return new List<OS>();
            }
        }
     
        public OS GetOSById(int id)
        {
            try
            {
                var OS = _context.TbOs.Where(c => c.osId == id).FirstOrDefault();
                return OS;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void AddOS(OS OS)
        {
            try
            {
                _context.TbOs.Add(OS);
                _context.SaveChanges();
          

            }catch(Exception ex)
            {
                return; 
            }
        }

        public void UpdateOS(OS OS)  {

          try
            {
                _context.Entry(OS).State = EntityState.Modified;
                OS.createdBy = "1";
                OS.updatedDate = DateTime.Now;

                if (OS.imageName == null)
                    OS.imageName = "";

                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            }

        public void DeleteOS(int id)  {

            try
            {
                var OSToRemove = GetOSById(id);
                _context.TbOs.Attach(OSToRemove);
                _context.TbOs.Remove(OSToRemove);
  
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            }

    }
}
