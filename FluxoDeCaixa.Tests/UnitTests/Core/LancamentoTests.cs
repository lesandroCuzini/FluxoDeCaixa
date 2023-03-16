using FluentAssertions;
using FluxoDeCaixa.Core;

namespace FluxoDeCaixa.Tests.UnitTests.Core
{
    public class LancamentoTests
    {
        [Fact]
        public void WhenTipoIsInvalid_ShouldThrowArgumentException()
        {
            Action act = () => new Lancamento(new DateTime(2023, 3, 15), 40, "F");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenValorIsZero_ShouldThrowArgumentException()
        {
            Action act = () => new Lancamento(new DateTime(2023, 3, 15), 0, "C");
            act.Should().Throw<ArgumentException>();
        }
    }
}
