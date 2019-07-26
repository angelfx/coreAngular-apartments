using Microsoft.AspNetCore.Mvc;
using RealEstates.Abstract.Logic;

namespace RealEstates.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private IApartmentsImport _importLogic;

        public ImportController(IApartmentsImport ctx)
        {
            _importLogic = ctx;
        }

        [HttpPost]
        public void Import()
        {
            _importLogic.Import("import_irk.csv", ';');
        }
    }
}