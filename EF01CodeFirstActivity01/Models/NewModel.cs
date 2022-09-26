using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassActivity.Models
{
    public class NewModel
    {
        [Key]
        public int NewModelId { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public virtual ICollection<List> Lists { get; set; }
    }
}