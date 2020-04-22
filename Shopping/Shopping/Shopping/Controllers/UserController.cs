using Microsoft.AspNetCore.Mvc;
using Shopping.core.Model;
using Shopping.Infrastructure.Manager;
using Shopping.Infrastructure.Util;
using System.Collections.Generic;


namespace Shopping.api.Controllers
{

    /// <summary>
    /// 登录
    /// </summary>
    [Route("api/login")]
    public class UserController : Controller
    {
        UserManager user = new UserManager();
        [HttpGet]
        public List<User> Get()
        {
            return user.Longin(HttpContext.Request.Query["username"], HttpContext.Request.Query["password"]);
        }
    }

    /// <summary>
    /// 注册时用户名异样步验证
    /// </summary>
    [Route("api/Reusers")]
    public class ReUserController : Controller
    {
        UserManager user = new UserManager();
        [HttpGet]
        public bool Get()
        {
            return user.Reusers(HttpContext.Request.Query["username"]);
        }
    }

    /// <summary>
    /// 发送邮件
    /// </summary>
    [Route("api/Remail")]
    public class RemailController : Controller
    {
        UserManager user = new UserManager();
        mail mails = new mail();
        [HttpGet]
        public string Get()
        {
            if (user.amail(HttpContext.Request.Query["mail"]))
                return "该邮箱以被注册";
            return mails.Sendmail(HttpContext.Request.Query["mail"]);
        }
    }

    /// <summary>
    /// 注册
    /// </summary>
    [Route("api/Remail")]
    public class RegController : Controller
    {
        UserManager user = new UserManager();
        [HttpGet]
        public int Get()
        {
            return user.Reg(HttpContext.Request.Query["username"], HttpContext.Request.Query["password"], HttpContext.Request.Query["mail"]);
        }
    }

}
