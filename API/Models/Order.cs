using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int CustomerId { get; set; }
        [ForeignKey("Stock")]
        public int StockId { get; set; }
        [ForeignKey("Status")]
        public int OrderStatus { get; set; }
        public virtual User User { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual State State { get; set; }


    }
}
