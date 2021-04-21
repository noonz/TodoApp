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
        public int TodoItemID { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        // string values for date for simplicity
        [Display(Name = "Date Added")]
        [StringLength(50)]
        public string AddedDate { get; set; }

        [Display(Name = "Date Due")]
        [StringLength(50)]
        public string DueDate { get; set; }

        public bool Done { get; set; }

        [Display(Name = "Date Complete")]
        [StringLength(50)]
        public string DoneDate { get; set; }
    }
}
