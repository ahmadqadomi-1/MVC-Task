using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniSchool.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClassName { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

        public Class()
        {
            Students = new List<Student>();
            Assignments = new List<Assignment>();
        }
    }
}