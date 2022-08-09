using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LaptopMart.Helpers
{
    public class UploadingFilesHelper
    {

        public async Task<string> UploadImage(IFormFile? File, string path)
        {

            if (File == null)
                return "";


            if (File.Length > 0 && File != null)
            {
                string ImageName = Guid.NewGuid().ToString() + ".jpg";
                var filepath = Path.Combine(Directory.GetCurrentDirectory(),
                    path, ImageName);

                using (var stream = System.IO.File.Create(filepath))
                {
                    await File.CopyToAsync(stream);

                }

                return ImageName;
            }
            else
                return "";
        }  
        
        
        public void DeleteImage(string path, string fileName)
        {
            File.Delete(Path.Combine(path, fileName));

        }




        //public async Task<string> UploadCategoryImage(IFormFile File)
        //{

        //    if (File.Length > 0 || File != null)
        //    {
        //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
        //        var filepath = Path.Combine(Directory.GetCurrentDirectory(),
        //            @"wwwRoot\Uploads\Images\CategoryImages", ImageName);

        //        using (var stream = System.IO.File.Create(filepath))
        //        {
        //            await File.CopyToAsync(stream);

        //        }

        //        return ImageName;
        //    }
        //    else
        //        return "";


        //}






    }
}
