using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void ShouldReturnErroWhenCNPJIsInvalid()
    {
      var doc = new Document("123", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
      var doc = new Document("42687790000175", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Valid);
    }
    
    [TestMethod]
    public void ShouldReturnErroWhenCPFIsInvalid()
    {
      var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCPFIsValid()
    {
      var doc = new Document("69926422004", EDocumentType.CPF);
       Assert.IsTrue(doc.Valid);
    }
  }
}