using FVG.FiscalAdapter.Domain.Core.Printer;
using FVG.FiscalAdapter.Domain.Entities;
using Xunit;

namespace FVG.FiscalAdapter.Domain.Core.Test.Printer
{
    public class TestPrintTest
    {
        [Theory]
        [InlineData("10.32.9.102", 102, "P-441F")]
        public void Print_Valid(string ip, int port, string model)
        {
            TestDocument document = new TestDocument()
            {
                Header = new Header()
                {
                    Ip = ip,
                    Port = port,
                    PrinterModel = model
                }
            };
            TestPrintHandler sut = new TestPrintHandler();
            var result = sut.Print(document);
            Assert.Equal(1, result.Success);
            Assert.Empty(result.Error);
        }

        [Theory]
        [InlineData("10.32.9.90", 102, "P-441F")]
        public void Print_Fail(string ip, int port, string model)
        {
            TestDocument document = new TestDocument()
            {
                Header = new Header()
                {
                    Ip = ip,
                    Port = port,
                    PrinterModel = model
                }
            };
            TestPrintHandler sut = new TestPrintHandler();
            var result = sut.Print(document);
            Assert.Equal(0, result.Success);
            Assert.NotNull(result.Error);
        }
    }
}