using Microsoft.AspNetCore.Mvc;
using Shopping.core.Model;
using Shopping.Infrastructure.Manager;
using System.Collections.Generic;


namespace Shopping.api.Controllers
{

    [Route("api/msg")]
    public class MsgController : Controller
    {
        MsgManager msg = new MsgManager();
        [HttpGet]
        public List<Comments> Get()
        {
            return msg.msg();
        }
    }


}
