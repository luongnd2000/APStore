
namespace APStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public string AlterImage { get; set; }
        [NotMapped]
        public string CategoryNameDisplay { get; set; }
    }
}
