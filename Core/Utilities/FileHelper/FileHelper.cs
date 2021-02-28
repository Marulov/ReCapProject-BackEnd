using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {
            // resmin dizin yolu oluşturuldu.
            var result = newPath(file);
            try
            {
                // geçiçi bir dosya yolu ve dosyayı döndürdük
                var sourcepath = Path.GetTempFileName();
                if (file.Length > 0)
                    using (var stream = new FileStream(sourcepath, FileMode.Create))
                        file.CopyTo(stream);

                File.Move(sourcepath, result.newPath); // geçiçi yolu kendi oluşturduğumuz dosya yolu ile değiştirdik.
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

            return result.Path2;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                File.Delete(sourcePath);
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }

            return result.Path2;
        }

        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            // resmimizin  uzantısını buluyoruz.(jpg,png gibi)
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            // guid ile kendimize özgü fileName i oluşturuyoruz.  örn => 16dff19bf753485981282718e0d8f295_2_27_2021.jpeg
            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;

            // dizin yolu oluşturuldu
            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            string result = $@"{path}\{creatingUniqueFilename}";

            return (result, $"\\Images\\{creatingUniqueFilename}");
        }
    }
}
