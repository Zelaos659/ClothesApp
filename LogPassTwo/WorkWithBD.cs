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
        public static bool Login(string log, string pass)
        {
            using (var BD = new ApplicationContext())
            {
                var user = BD.Employees.FirstOrDefault(x=>x.login == log);
                if (user != null) 
                {
                    if (md5.hashPassword(pass) == user.password)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static bool Register(string log, string pass)
        {
            using(var BD = new ApplicationContext())
            {

                if (BD.Employees.FirstOrDefault(x => x.login == log) != null)
                    return false;

                var user = new Employee() 
                { 
                  login = log,
                  password = md5.hashPassword(pass),
                  role = "new"
                };

                BD.Employees.Add(user);
                BD.SaveChanges();
                return true;
            }
        }
    }
}
