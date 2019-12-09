using LoginApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginApi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly Model1 db = new Model1();
        public HttpResponseMessage ValidateLogin(usuario user)
        {
            var items = db.usuario.ToList();
            foreach (var item in items)
            {
                if (item.usu.Equals(user.usu) && item.passw.Equals(user.passw))
                {
                    return Request.CreateResponse(HttpStatusCode.OK,item);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.NoContent,"No se ha encontrado registro que coincida");
        }
    }
}
