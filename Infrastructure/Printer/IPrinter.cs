using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVG.FiscalAdapter.Infrastructure.Printer
{
    public interface IPrinter<>
    {
        void Print(Document entity);
    }
}
