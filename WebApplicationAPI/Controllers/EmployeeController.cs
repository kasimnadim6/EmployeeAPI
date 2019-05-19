using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationAPI.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        EmployeeDBEntities context = new EmployeeDBEntities();

        [HttpGet]
        [Route("AllEmployees")]
        public IQueryable<tbl_Emplyee> GetAllEmployee()
        {
            try
            {
                return context.tbl_Emplyee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("EmployeeByID")]
        public IHttpActionResult GetEmployeeByID(int id)
        {
            tbl_Emplyee employee =  context.tbl_Emplyee.Find(id);
            try
            {
                if (employee == null)
                    return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IHttpActionResult CreateEmployee(tbl_Emplyee employee)
        {
            try
            {
                context.tbl_Emplyee.Add(employee);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IHttpActionResult UpdateEmployee(int id,tbl_Emplyee employee)
        {
            tbl_Emplyee data = context.tbl_Emplyee.Find(id);
            try
            {
                if (data != null)
                {
                    data.FullName = employee.FullName;
                    data.EMPCode = employee.EMPCode;
                    data.Mobile = employee.Mobile;
                    data.Position = employee.Position;
                }
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            tbl_Emplyee employee =  context.tbl_Emplyee.Find(id);
            try
            {
                if (employee == null)
                    return NotFound();
                context.tbl_Emplyee.Remove(employee);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
            
        }

        [HttpGet]
        [Route("EmployeeByEMPCode")]
        public IHttpActionResult GetEmployeeByEMPCode(string EmpCode)
        {
            tbl_Emplyee employee = context.tbl_Emplyee.FirstOrDefault(x => x.EMPCode == EmpCode);
            try
            {
                if (employee == null)
                    return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }
    }
}
