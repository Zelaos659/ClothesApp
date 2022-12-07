using LogPass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

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

        public static bool Register(string log, string pass)
        {
            using(var BD = new ApplicationContext())
            {

                if (BD.Users.FirstOrDefault(x => x.Login == log) != null)
                    return false;

                var user = new User() 
                { 
                  Login = log,
                  Password = md5.hashPassword(pass),
                  Access = "Admin"
                };

                BD.Users.Add(user);
                BD.SaveChanges();
                return true;
            }
        }
    }
}
