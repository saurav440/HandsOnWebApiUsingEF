using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandsOnWebApiUsingEF.Models;
namespace HandsOnWebApiUsingEF.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        [Route("GetAll")]
        public IEnumerable<Employee> Get()
        {
            using (CTSDBEntities db = new CTSDBEntities())
            {
                return db.Employees.ToList();
            }
        }

        // GET: api/Employee/5
        [Route("Employee/Search/{id}")]
        public Employee Get(int id)
        {
            using (CTSDBEntities db = new CTSDBEntities())
            {
                return db.Employees.Find(id);
            }
        }

        // POST: api/Employee
        [Route("Employee/Add")]
        public void Post(Employee item)
        {
            using (CTSDBEntities db = new CTSDBEntities())
            {
                db.Employees.Add(item);
                db.SaveChanges();
            }
        }

        // PUT: api/Employee/5
        public void Put(Employee item)
        {
            using (CTSDBEntities db = new CTSDBEntities())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            using (CTSDBEntities db = new CTSDBEntities())
            {
                db.Employees.Remove(db.Employees.Find(id));
                db.SaveChanges();
            }
        }
    }
}
