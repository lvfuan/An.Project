using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest.AspNetCoreDemo.Models
{
    public class BlogModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? CreateUser { get; set; }
        public bool? Status { get; set; }
    }
}
