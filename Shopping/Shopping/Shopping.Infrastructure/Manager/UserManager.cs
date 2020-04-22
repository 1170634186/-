using Shopping.core.Model;
using Shopping.Infrastructure.Database;
using System;
using System.Collections.Generic;

namespace Shopping.Infrastructure.Manager
{
    public class UserManager : DbContext
    {
        public List<User> Longin(string username, string password)
        {

            List<User> user = Db.Queryable<User>().Where(it => it.username == username && it.password == password).ToList();//根据条件查询

            return user;
        }

        public bool Reusers(string username)
        {
            return Db.Queryable<User>().Where(it => it.username == username).Any();
        }

        public int Reg(string username, string password, string mail)
        {
            var data = new User() { username = username, password = password, mail = mail };
            return Db.Insertable(data).ExecuteCommand();
        }

        public bool amail(string mail)
        {
            return Db.Queryable<User>().Where(it => it.mail == mail).Any();

        }
    }
}
