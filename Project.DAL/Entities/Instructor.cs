﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    public class Instructor :BaseEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InstructorId { get; set; }
        public string Name { get; set;}
        public int Age { get; set;}
        public string City { get; set;}
        public string Street { get; set;}
        public string Gender { get; set;}
        public int Salary { get; set;}
        public int UserId { get; set; }


        public int BrandId { get; set; }
        public int CourseId { get; set; }

        public List<Course> Courses { get; set; }
        public Branch Branch { get; set; }


    }
}
