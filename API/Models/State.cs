using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
