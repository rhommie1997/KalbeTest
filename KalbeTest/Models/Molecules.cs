using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalbeTest.Models
{
    [Table("m_molecules")]
    public class Molecules
    {
        [Key]
        public Guid id { get; set; }
        public string MoleculesName { get; set; }
        public string? MolDescription { get; set; }
        public bool isActive { get; set; }
        public string? State { get; set; }
        public ICollection<Study>? Studies { get; set; }
    }
}
