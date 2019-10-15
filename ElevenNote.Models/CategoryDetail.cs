using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryDetail
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryTitle { get; set; }
    }
}
