using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstates.Abstract.Logic;
using Microsoft.Extensions.Configuration;

namespace AngularApp2.Controllers
{
    [Route("api/[controller]/[action]")]
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
