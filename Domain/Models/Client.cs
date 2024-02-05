namespace Domain.Models
{
    public class Client
    {
        public int Client_id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateOnly dateNaissance { get; set; }
    }
}
