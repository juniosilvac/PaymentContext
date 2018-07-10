using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void AdicionarAssinatura()
    {
      var student = new Student("João", "Silva","12345678888","joao@contato.com.br");

    }
  }
}