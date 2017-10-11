using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Entities;
using FVG.FiscalAdapter.Presentation.API.Helpers;
using System.Threading.Tasks;
using System.Web.Http;

namespace FVG.FiscalAdapter.Presentation.API.Controllers
{
    public class TestPrintController : ApiController
    {
        private IPrintProcessor _processor;

        public TestPrintController(IPrintProcessor processor) => _processor = processor;

        [HttpPost]
        public async Task<Result> Post([FromBody]TestDocument testDocument) => await Task.Run<Result>(() => _processor.Print<TestDocument>(testDocument));
    }
}