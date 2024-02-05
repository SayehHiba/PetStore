namespace Domain.Models
{
    public class Animal
    {
        public int animal_id { get; set; }
        public string name { get; set; }

        public string type { get; set; }

        public DateOnly dateNaissance { get; set; }

        public Client? Client { get; set; }

    }
}
