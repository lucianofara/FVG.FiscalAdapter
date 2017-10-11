using FVG.FiscalAdapter.Domain.Core.Validators;
using FVG.FiscalAdapter.Domain.Entities;
using Ploeh.AutoFixture;
using System;
using Xunit;

namespace FVG.FiscalAdapter.Domain.Core.Test.Validator
{
    public class OpenCommandPrintValidatorTest
    {
        [Fact]
        public void Validate_Header()
        {
            var fixture = new Fixture();
            var docBuild = fixture.Build<OpenCommandDocument>().Without(p => p.Header);
            var document = docBuild.Create();

            OpenCommandPrintValidator sut = new OpenCommandPrintValidator();
            Action execution = () => sut.Validate(document);
            Assert.Throws<ArgumentNullException>(execution);
        }

        [Fact]
        public void Validate_Commands()
        {
            var fixture = new Fixture();
            var docBuild = fixture.Build<OpenCommandDocument>().Without(p => p.Commands);
            var document = docBuild.Create<OpenCommandDocument>();

            OpenCommandPrintValidator sut = new OpenCommandPrintValidator();
            Action execution = () => sut.Validate(document);
            Assert.Throws<ArgumentNullException>(execution);
        }
    }
}