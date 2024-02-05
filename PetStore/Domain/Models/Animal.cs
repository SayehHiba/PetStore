using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Animal
    {
        [Key]
        public int Animal_id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateNaissance { get; set; }

    }
}
