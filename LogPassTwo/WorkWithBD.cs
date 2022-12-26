using LogPass.Data;
using LogPassTwo;
using LogPassTwo.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LogPass
{
    static class WorkWithBD
    {
        /// <summary>
        /// Попытка авторизации в систему.
        /// </summary>
        /// <param name="log">Логин пользователя</param>
        /// <param name="pass">Пароль пользователя</param>
        /// <returns>Функция возвращает true если авторизация успешна, иначе false</returns>
        public static User Login(string log, string pass)
        {
            using (var BD = new ApplicationContext())
            {
                var user = BD.Users.FirstOrDefault(x=>x.Login == log);
                if (user != null) 
                {
                    if (md5.hashPassword(pass) == user.Password)
                    {
                        return user;
                    }
                }
                return null;
            }
        }

        public static bool Register(User user)
        {
            using(var BD = new ApplicationContext())
            {
                BD.Users.Add(user);
                BD.SaveChanges();
                return true;
            }
        }

        public static byte[] ConvertFileToByte(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        //public static Image ConvertByteToImage(byte[] photo)
        //{
        //    Image newImage;
        //    using (MemoryStream ms = new MemoryStream(photo, 0, photo.Length))
        //    {
        //        ms.Write(photo, 0, photo.Length);
        //        newImage = Image.FromStream(ms, true);
        //    }
        //    return newImage;
        //}
        
        public static BitmapSource ConvertByteToImage(byte[] photo)
        {
            using (MemoryStream ms = new MemoryStream(photo))
            {
                var decoder = BitmapDecoder.Create(ms,
                    BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                return decoder.Frames[0];
            }
        }

        public static void SaveProduct(string _title, string _desc, string _price, string _count,string _photo)
        {
            Product prod = new Product()
            {
                Title = _title,
                Description = _desc,
                Price = Convert.ToDecimal(_price),
                Count = Convert.ToInt32(_count),
                Photo = ConvertFileToByte(_photo)
            };
            using(var BD = new ApplicationContext())
            {
                BD.Products.Add(prod);
                BD.SaveChanges();
            }
        }

    }
}
