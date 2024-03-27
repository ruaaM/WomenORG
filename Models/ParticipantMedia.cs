using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class ParticipantMedia:General
    {
        [Key]
        public int ParticipantMediaID { get; set; }
        public String? FileName { get; set; }
        public String? FilePath { get; set; }
        public virtual int? FileTypesID { get; set; }

        [ForeignKey("FileTypesID")]
        public virtual FileTypes? FileTypes { get; set; }
        public virtual int? ParticipantID { get; set; }

        [ForeignKey("ParticipantID")]
        public virtual Participant? Participant { get; set; }

    }
}
