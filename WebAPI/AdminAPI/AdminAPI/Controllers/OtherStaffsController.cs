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
using AdminAPI.ViewModels;

namespace AdminAPI.Controllers
{
    public class OtherStaffsController : ApiController
    {
        private Context db = new Context();

        //Roles = Admin:1, Doctor:2, Patient:3
        // GET: api/OtherStaffs
        [Authorize(Roles = "1,2,3")]
        public HttpResponseMessage GetOtherStaffs()
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var entity = dbContext.otherStaff.ToList();
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor's list not available");
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }
        [HttpGet]
        [Authorize(Roles = "1,2,3")]
        [Route("api/OtherStaffs/GetStaffById/{id}")]
        public HttpResponseMessage GetStaffById(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var entity = dbContext.otherStaff.Where(c=>c.StaffID==id).ToList();
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor's list not available");
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        // GET: api/OtherStaffs/5
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(OtherStaff))]
        public IHttpActionResult GetOtherStaff(int id)
        {
            OtherStaff otherStaff = db.otherStaff.Find(id);
            if (otherStaff == null)
            {
                return NotFound();
            }

            return Ok(otherStaff);
        }

        // PUT: api/OtherStaffs/5
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOtherStaff(int id, OtherStaff otherStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != otherStaff.StaffID)
            {
                return BadRequest();
            }

            db.Entry(otherStaff).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherStaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OtherStaffs
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(OtherStaff))]
        public IHttpActionResult PostOtherStaff(AddStaffViewModel staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                using (Context dbContext = new Context())
                {

                    LoginTable lt = new LoginTable()
                    {
                        Password = staff.Password,
                        Email = staff.Email,
                        Type = 4
                    };

                    OtherStaff d = new OtherStaff()
                    {
                        Name = staff.Name,
                        Phone = staff.Phone,
                        Address = staff.Address,
                        BirthDate = staff.BirthDate,
                        Salary = staff.Salary,
                        Highest_Qualification = staff.Highest_Qualification,
                        LoginID = lt.LoginId,
                        LoginTable = lt,
                        Designation=staff.Designation
                    };

                    if (staff.Department.Equals("Cardiology"))
                        d.DeptNo = 1;
                    else if (staff.Department.Equals("Orthopaedics"))
                        d.DeptNo = 2;
                    else if (staff.Department.Equals("Ears Nose Throat"))
                        d.DeptNo = 3;
                    else if (staff.Department.Equals("Physiotherapy"))
                        d.DeptNo = 4;
                    else if (staff.Department.Equals("Neurology"))
                        d.DeptNo = 5;
                    else
                        d.DeptNo = 0;


                    dbContext.otherStaff.Add(d);
                    dbContext.SaveChanges();

                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        // DELETE: api/OtherStaffs/5
        [Authorize(Roles = "1,2,3")]
        [HttpDelete]
        [Route("api/OtherStaffs/DeleteStaffById/{id}")]
        public HttpResponseMessage DeleteStaffById(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var staff = dbContext.otherStaff.Where(d => d.StaffID == id).FirstOrDefault();
                    var login = dbContext.loginTables.Where(d => d.LoginId ==staff.LoginID).FirstOrDefault();
                    if (staff == null || login==null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    dbContext.otherStaff.Remove(staff);
                    dbContext.loginTables.Remove(login);
                    
                    dbContext.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, staff);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OtherStaffExists(int id)
        {
            return db.otherStaff.Count(e => e.StaffID == id) > 0;
        }
    }
}