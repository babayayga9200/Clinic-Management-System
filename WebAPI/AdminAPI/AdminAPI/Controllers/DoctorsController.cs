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
using System.Collections;

namespace AdminAPI.Controllers
{
    public class DoctorsController : ApiController
    {
        // GET: api/Doctors
        //Roles = Admin:1, Doctor:2, Patient:3
        [Authorize(Roles = "1,2,3")]
        public HttpResponseMessage Getdoctors()
        {
            try
            {
                    using (Context dbContext = new Context())
                    {
                        var entity = dbContext.doctors.ToList();
                        if (entity == null)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor's list not available");
                        }
                        return Request.CreateResponse(HttpStatusCode.OK,entity);
                    }
            }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, e);
                }
        }

        //Roles = Admin:1, Doctor:2, Patient:3
        [HttpGet]
        [Route("api/Doctors/GetDoctorById/{id}")]
        [Authorize(Roles = "1,2,3")]
        public HttpResponseMessage GetdoctorById(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var entity = dbContext.doctors.Include(c => c.Department).Where(c=>c.DoctorID==id).ToList();
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

        // GET: api/Doctors/5
        [ResponseType(typeof(Doctor))]
        [Route("api/Doctors/GetDoctorByDId")]
        [Authorize(Roles = "1,2,3")]
        public HttpResponseMessage GetdoctorsByDId()
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    List<int> l = new List<int>();
                    for (int i = 1; i <= 5; i++)
                    {
                        var entity = dbContext.doctors.Where(x => x.DeptNo == i).Count();

                        l.Add(entity);
                    }

                    if (l == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor's list not available");
                    }
                        return Request.CreateResponse(HttpStatusCode.OK, l);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpGet]
        [Route("api/Doctors/GetDoctorCount")]
        [Authorize(Roles = "1,2,3")]
        public IHttpActionResult GetDoctorCount()
        {
            try
            {
                using (Context dbContext = new Context())
                {

                    var entity = dbContext.doctors.Count();
                    Hashtable i = new Hashtable();
                    i.Add("Count", entity);

                    return Ok(i);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        // POST: api/Doctors
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(Doctor))]
        public HttpResponseMessage PostDoctor(AddDoctorViewModel home)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                using (Context dbContext = new Context())
                {
                    

                    LoginTable lt = new LoginTable()
                    {
                        Password = home.Password,
                        Email = home.Email,
                        Type = 2
                    };

                    Doctor d = new Doctor()
                    {
                        Name=home.Name,
                        Phone=home.Phone,
                        Address=home.Address,
                        BirthDate=home.BirthDate,
                        Charges_Per_Visit=home.Charges_Per_Visit,
                        MonthlySalary=home.MonthlySalary,
                        ReputeIndex=0.00,
                        Patients_Treated=5,
                        Qualification=home.Qualification,
                        Specialization=home.Specialization,
                        Work_Experience=home.Work_Experience,
                        status=1,
                        LoginId=lt.LoginId,
                        LoginTable=lt,
                        Email=home.Email
                    };

                    if (home.Department.Equals("Cardiology"))
                    {
                        d.DeptNo = 1;
                        d.DeptName = "Cardiology";
                    }
                    else if (home.Department.Equals("Orthopaedics"))
                    {
                        d.DeptNo = 2;
                        d.DeptName = "Orthopaedics";
                    }
                    else if (home.Department.Equals("Ears Nose Throat"))
                    {
                        d.DeptNo = 3;
                        d.DeptName = "Ears Nose Throat";
                    }
                    else if (home.Department.Equals("Physiotherapy"))
                    {
                        d.DeptNo = 4;
                        d.DeptName = "Physiotherapy";
                    }
                    else if (home.Department.Equals("Neurology"))
                    {
                        d.DeptNo = 5;
                        d.DeptName = "Neurology";
                    }
                    else
                    {
                        d.DeptNo = 0;
                        d.DeptName = "";
                    }


                        Department dep = dbContext.departments.FirstOrDefault(x => x.DeptNo == d.DeptNo);

                    
                    d.Department = dep;

                    dbContext.doctors.Add(d);
                    dbContext.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
          
        }
        [Authorize(Roles = "1,2,3")]
        [Route("api/Doctors/GetDoctor_ByDeptId/{id}")]
        public HttpResponseMessage GetDoctor_ByDeptId(int id)
        {
            
                try
                {
                    using (Context db = new Context())
                    {

                        var entity = db.doctors.Where(z => z.DeptNo == id).ToList();
                        if (entity == null)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Date Not Found");
                        }
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }


                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, e);
                }
        }


        [HttpDelete]
        [Authorize(Roles = "1,2,3")]
        [Route("api/Doctors/DeleteDoctorById/{id}")]
        public HttpResponseMessage DeletedoctorById(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var doctor = dbContext.doctors.Where(d => d.DoctorID == id).FirstOrDefault();
                    var appointment = dbContext.appointments.Where(d => d.DoctorID == id).ToList();
                    var login = dbContext.loginTables.Where(d => d.LoginId == doctor.LoginId).FirstOrDefault();
                    if (doctor == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    dbContext.doctors.Remove(doctor);
                    dbContext.loginTables.Remove(login);
                    foreach(var app in appointment)
                    {
                        dbContext.appointments.Remove(app);
                    }
                    dbContext.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, doctor);
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        
       


    }
}