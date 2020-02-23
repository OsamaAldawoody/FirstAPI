using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FirstAPI.Models
{
    [DataContract]
    public class student
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public int age { get; set; }

        public student(int id ,string name , int age , string address)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.address = address;
        }
        public student()
        {

        }
    }
}