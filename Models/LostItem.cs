using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFound.Models
{
    public class LostItem
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select an Image")]
        public string PhotoURL { get; set; }
        [Required(ErrorMessage = "Item Name is required")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please select the Item category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Enter Description of the item")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter the Lost Area")]
        public string LostArea { get; set; }
        [Required(ErrorMessage = "Please Select the Lost Time")]
        public DateTime Date { get; set; }
      

    }
}
