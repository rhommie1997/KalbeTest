using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalbeTest.Models
{
    [Table("m_study_status")]
    public class StudyStatus
    {
        [Key]
        public int id { get; set; }
        public string StatusName { get; set; }
        public ICollection<Study>? Studies { get; set; }
    }
}
