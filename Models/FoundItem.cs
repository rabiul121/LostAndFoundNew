using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFound.Models
{
    public class FoundItem
    {
        [Key]
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string LostArea { get; set; }
        public DateTime Date { get; set; }

    }
}
