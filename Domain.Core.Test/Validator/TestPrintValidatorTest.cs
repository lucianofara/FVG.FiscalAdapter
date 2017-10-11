using FVG.FiscalAdapter.Domain.Core.Validators;
using FVG.FiscalAdapter.Domain.Entities;
using Ploeh.AutoFixture;
using System;
using Xunit;

namespace FVG.FiscalAdapter.Domain.Core.Test.Validator
{
    public class TestPrintValidatorTest
    {
        [Fact]
        public void Validate_Header()
        {
            var fixture = new Fixture();
            var docBuild = fixture.Build<TestDocument>().Without(p => p.Header);
            var document = docBuild.Create();

            TestPrintValidator sut = new TestPrintValidator();
            Action execution = () => sut.Validate(document);
            Assert.Throws<ArgumentNullException>(execution);
        }
    }
}