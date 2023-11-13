using KalbeTest.Services.Abstract;
using KalbeTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KalbeTest.Controllers
{
    public class MoleculesController : Controller
    {
        private readonly IMoleculesService moleculesService;

        public MoleculesController(IMoleculesService _ms)
        {
            moleculesService = _ms;
        }
        public IActionResult Index()
        {
            var data = moleculesService.GetAllData();
            return View(data);
        }

        public async Task<IActionResult> Add()
        {
            return View("_Add");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var OneData = moleculesService.GetOne(id);

            return View("_Edit", OneData);
        }


        public async Task<IActionResult> Save(string Type, MoleculesSaveViewModel data)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = true;

                if (Type == "Add")
                {
                    isSuccess = await moleculesService.CreatingOne(data);
                }
                else
                {
                    isSuccess = await moleculesService.UpdateThis(data);
                }

                if (isSuccess)
                {
                    if (Type == "Add")
                    {
                        TempData["Success"] = "Molecule successfully created";
                    }
                    else
                    {
                        TempData["Success"] = "Molecule successfully updated";
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    if (Type == "Add")
                    {
                        TempData["Success"] = "Molecule failed to created";
                    }
                    else
                    {
                        TempData["Success"] = "Molecule failed to updated";
                    }
                }
            }

            return View(data);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            bool res = await moleculesService.DeleteOne(id);
            if (res)
            {
                TempData["Success"] = "Molecule successfully deleted";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Molecule failed to deleted";
            }


            return NotFound();
        }



    }
}
