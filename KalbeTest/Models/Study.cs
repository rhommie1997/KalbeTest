using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalbeTest.Models
{
    [Table("m_study")]
    public class Study
    {
        [Key]
        public Guid id { get; set; }
        public string StudyId { get; set; }
        public int VersionId { get; set; }
        public string ProtocolTitle { get; set; }
        public string ProtocolCode { get; set; }
        public Guid MoleculesID { get; set; }
        public int StudyStatusID { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? State { get; set; }
    }
}
