using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.Entity.Models
{
    [Table("ToDoDatas")]
    public class ToDoData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime InsertDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsRead { get; set; }

    }
}
