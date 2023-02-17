
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication3.Models
{
    public class Quantity
    {
        [Key]
        public int QuantityId { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int MeasurmentId { get; set; }
      
        public virtual Measurment Measurment { get; set; }


    }
}