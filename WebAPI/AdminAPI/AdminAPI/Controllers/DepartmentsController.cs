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
    public class DepartmentsController : ApiController
    {
        Context db = new Context();
        //Roles = Admin:1, Doctor:2, Patient:3
        [Authorize(Roles = "1,2,3")]
        public HttpResponseMessage GetDepartmentInformation()
        {
            try
            {
                using (Context dbContext = new Context()) {
                    var id = dbContext.departments.Include(c=>c.Doctors).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK,id);
                    
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }


        // GET: api/Departments/
        //Roles = Admin:1, Doctor:2, Patient:3
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(int id)
        {
            Department department = db.departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Departments/5
        //Roles = Admin:1, Doctor:2, Patient:3
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartment(int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DeptNo)
            {
                return BadRequest();
            }

            db.Entry(department).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        //Roles = Admin:1, Doctor:2, Patient:3
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.departments.Add(department);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = department.DeptNo }, department);
        }

        // DELETE: api/Departments/5
        //Roles = Admin:1, Doctor:2, Patient:3
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(int id)
        {
            Department department = db.departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            db.departments.Remove(department);
            db.SaveChanges();

            return Ok(department);
        }

        
        private bool DepartmentExists(int id)
        {
            return db.departments.Count(e => e.DeptNo == id) > 0;
        }
    }
}