using KalbeTest.ViewModels;

namespace KalbeTest.Services.Abstract
{
    public interface IMoleculesService
    {
        List<MoleculesViewModel> GetAllData();

        MoleculesSaveViewModel GetOne(Guid id);
        Task<bool> CreatingOne(MoleculesSaveViewModel data);
        Task<bool> UpdateThis(MoleculesSaveViewModel data);
        Task<bool> DeleteOne(Guid id);

    }
}
