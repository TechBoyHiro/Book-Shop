using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Book
    {
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BookId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string imgpath { get; set; }
        
    }
}
