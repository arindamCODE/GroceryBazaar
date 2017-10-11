using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProductGroup
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}