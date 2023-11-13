using KalbeTest.DataContext;
using KalbeTest.Models;
using KalbeTest.Services.Abstract;
using KalbeTest.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KalbeTest.Services.Services
{
    public class MoleculesService : IMoleculesService
    {
        public BaseContext dbContext;

        public MoleculesService(BaseContext dbc)
        {
            dbContext = dbc;
        }

        public Task<bool> CreatingOne(MoleculesSaveViewModel data)
        {
            var result = true;

            try
            {
                var newOne = new Molecules() {
                    id = Guid.NewGuid(),
                    MoleculesName = data.MoleculesName,
                    MolDescription = data.MolDescription,
                    isActive = data.isActive,
                };

                dbContext.Molecules.Add(newOne);
                dbContext.SaveChanges();

            }catch(Exception)
            {
                result = false;
            }


            return Task.FromResult(result);
        }

      

        public List<MoleculesViewModel> GetAllData()
        {
            var result = dbContext.Molecules.Select(x => new MoleculesViewModel() {
                id = x.id,
                MoleculesName = x.MoleculesName,
                MolDescription = x.MolDescription ?? "",
                isActive = x.isActive,
                State = x.State ?? ""
            }).ToList();



            return result;
        }

        public MoleculesSaveViewModel GetOne(Guid id)
        {
            var result = dbContext.Molecules.Where(x => x.id == id).Select(x => new MoleculesSaveViewModel() { 
                id = x.id,
                MoleculesName = x.MoleculesName,
                MolDescription = x.MolDescription ?? "",
                isActive = x.isActive
            }).FirstOrDefault();

            return result ?? new MoleculesSaveViewModel();
        }

        public Task<bool> UpdateThis(MoleculesSaveViewModel data)
        {
            var result = true;

            try
            {
                var mol = dbContext.Molecules.FirstOrDefault(x => x.id == data.id) ?? new Molecules();
                mol.MoleculesName = data.MoleculesName;
                mol.MolDescription = data.MolDescription ?? "";
                mol.isActive = data.isActive;

                dbContext.Molecules.Update(mol);
                dbContext.SaveChanges();

            }
            catch (Exception)
            {
                result = false;
            }


            return Task.FromResult(result);
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            var result = true;
            try
            {
                var mol = await  dbContext.Molecules.FirstOrDefaultAsync(x => x.id == id);
                if (mol != null)
                {
                    dbContext.Molecules.Remove(mol);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }


    }
}
