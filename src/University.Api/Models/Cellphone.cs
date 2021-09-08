using System;
using System.ComponentModel.DataAnnotations;

namespace University.Api.Models
{
    public class Cellphone
    {
        [Key]
        public Guid PhoneId { get; set; }
        public string PhoneName { get; set; }
        public string PhoneModel { get; set; }
        public int PhoneYear { get; set; }
        public string Color { get; set; }
    }
}
