using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.core.Model
{
    [SugarTable("user")]    //对应数据库的user表
    public class User
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] //是主键, 还是标识列
        public int id { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string mail { set; get; }
    }
}
