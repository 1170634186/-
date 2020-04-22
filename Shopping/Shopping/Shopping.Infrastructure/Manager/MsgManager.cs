using Shopping.core.Model;
using Shopping.Infrastructure.Database;
using System;
using System.Collections.Generic;

namespace Shopping.Infrastructure.Manager
{
    public class MsgManager : DbContext
    {
        public List<Comments> msg()
        {
            List<Comments> comments = Db.Queryable<Comments>().ToList();//根据条件查询

            return comments;
        }
    }
}
