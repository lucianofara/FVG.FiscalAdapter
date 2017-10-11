﻿using FVG.FiscalAdapter.Domain.Core.Printer;
using FVG.FiscalAdapter.Domain.Entities;
using Xunit;

namespace FVG.FiscalAdapter.Domain.Core.Test.Printer
{
    public class CommandTest
    {
        [Theory]
        [InlineData("10.32.9.102", 102, "P-441F")]
        public void Print_Valid(string ip, int port, string model)
        {
            CommandDocument document = new CommandDocument()
            {
                Header = new Header()
                {
                    Ip = ip,
                    Port = port,
                    PrinterModel = model
                },
                Commands = new string[] { }
            };
            CommandPrintHandler sut = new CommandPrintHandler();
            var result = sut.Print(document);

            Assert.Equal(1, result.Success);
            Assert.Empty(result.Error);
            Assert.Null(result.Comprobante);
        }

        [Theory]
        [InlineData("10.32.9.30", 102, "P-441F")]
        public void Print_Fail(string ip, int port, string model)
        {
            CommandDocument document = new CommandDocument()
            {
                Header = new Header()
                {
                    Ip = ip,
                    Port = port,
                    PrinterModel = model
                },
                Commands = new string[] { }
            };
            CommandPrintHandler sut = new CommandPrintHandler();
            var result = sut.Print(document);

            Assert.Equal(0, result.Success);
            Assert.NotEmpty(result.Error);
            Assert.Null(result.Comprobante);
        }
    }
}