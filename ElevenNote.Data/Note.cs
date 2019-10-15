using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        [Required]
        [Display(Name = "Your ID")]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Your Note")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Note Content")]
        public string Content { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [DefaultValue(false)]
        public bool IsStarred { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
