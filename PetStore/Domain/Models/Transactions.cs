using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    [PrimaryKey(nameof(Client_id), nameof(Animal_id))]
    public class Transactions
    {
        public int Client_id { get; set; }
        public int Animal_id { get; set; }
        public DateTime DateTransaction { get; set; }
    }
}
