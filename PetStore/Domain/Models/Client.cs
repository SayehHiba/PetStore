using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Client
    {
        [Key]
        public int Client_id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
    }
}
