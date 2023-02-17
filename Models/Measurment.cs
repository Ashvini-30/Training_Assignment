
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication3.Models
{
    public class Measurment
    {
        [Key]
        public int MeasurmentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MeasurmentName { get; set; }

    }
}