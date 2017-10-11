using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProductInfo
    {
        public int ID { get; set; }

        public int GroupID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Rate { get; set; }
    }
}