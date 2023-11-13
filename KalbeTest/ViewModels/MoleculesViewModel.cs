using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KalbeTest.ViewModels
{
    public class MoleculesViewModel
    {
        public Guid id { get; set; }
        public string MoleculesName { get; set; }
        public string MolDescription { get; set; }
        public bool isActive { get; set; }
        public string State { get; set; }

    }

    public class MoleculesSaveViewModel
    {
        public Guid id { get; set; }
        public string MoleculesName { get; set; }
        public string MolDescription { get; set; }
        public bool isActive { get; set; }

    }
}
