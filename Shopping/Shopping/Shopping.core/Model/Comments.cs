using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.core.Model
{
    [SugarTable("comments")]    //对应数据库的user表
    public class Comments
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] //是主键, 还是标识列
        public int id { set; get; }
        public string comment { set; get; }
        public string reply { set; get; }
        public string user { set; get; }
        public string business { set; get; }
    }
}
