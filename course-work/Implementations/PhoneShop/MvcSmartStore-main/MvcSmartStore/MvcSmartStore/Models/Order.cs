using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSmartStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Smartphone")]
        public int SmartphoneId { get; set; }

        public DateTime OrderDate { get; set; }

        public User User { get; set; }

        public Smartphone Smartphone { get; set; }
    }
}
