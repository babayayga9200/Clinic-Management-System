using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AdminAPI.Models;

namespace AdminAPI.Controllers
{
    public class LoginTablesController : ApiController
    {
        private Context db = new Context();

        //Roles = Admin:1, Doctor:2, Patient:3
        // GET: api/LoginTables
        [Route("api/LoginTables/GetLoginTables")]
        [Authorize(Roles = "1,2,3")]
        public HttpResponseMessage GetloginTables()
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var entity = dbContext.loginTables.ToList();
                    if (entity == null)
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

        }


    }
}