using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FirstAPI.Models;

namespace FirstAPI.Controllers
{
    
    [RoutePrefix("api/student")]
    public class studentController : ApiController
    {
        public static List<student> studentList = new List<student>()
        {
            new student(1,"osama",21,"Cairo"),
            new student(2,"ahmed",22,"mansoura"),
            new student(3,"ali",19,"luxor"),
            new student(4,"mohamed",15,"alex"),
            new student(5,"sami",20,"damitta"),
            new student(6,"saad",35,"helwan")
        };

        //select all 
        
        public IHttpActionResult getAll()
        {
            if (studentList==null)
                return NotFound();
            else
                return Ok(studentList);
        }

        //select by id 
        //public HttpResponseMessage getById(int id)
        //{
        //    student s = studentList.Find(st => st.id == id);
        //    if (s==null)
        //    {
        //        HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.NotFound);
        //        return message;
        //    }
        //    else
        //    {
        //        HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK, s);
        //        return message;
        //    }

        //}

        public IHttpActionResult getById(int id)
        {
            student s = studentList.Find(st => st.id == id);
            if (s == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(s);
            }

        }

        //select by name 
        [HttpGet]
        [Route("{name:alpha}")]
        public IHttpActionResult selectByName(string name)
        {
             student s = studentList.Find(st => st.name == name);
            if (s == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(s);
            }
             
        }

        //add student
        [HttpPost]
        public IHttpActionResult addStudent(student s)
        {
            if (s == null)
            {
                return BadRequest();
            }
            else {
                studentList.Add(s);
                return Created("student list",s);
            }
            
        }

        //delete student 
        public IHttpActionResult deleteStudent(int id)
        {

            student s = studentList.Find(st => st.id == id);
            if (s==null)
            {
                return BadRequest();
            }
            else {
                studentList.Remove(s);
                return Ok(s);
            }
            
        }

        //edit student 
        public IHttpActionResult put(student s,int id)
        {
            studentList.Find(st => st.id == id).name = s.name;
            studentList.Find(st => st.id == id).age = s.age;
            studentList.Find(st => st.id == id).address = s.address;
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
