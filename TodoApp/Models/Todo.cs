using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToDoItemID { get; set; }

        [StringLength(100)]
        public string UserEmail { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // string values for date for simplicity
        [StringLength(50)]
        public string AddedDate { get; set; }

        [StringLength(50)]
        public string DueDate { get; set; }

        public bool Done { get; set; }

        [StringLength(50)]
        public string DoneDate { get; set; }
    }
}
