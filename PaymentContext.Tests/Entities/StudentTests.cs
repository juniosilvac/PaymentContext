using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    private readonly Name _name;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
      _name = new Name("Bruce", "Wayne");
      _document = new Document("56759217020", EDocumentType.CPF);
      _email = new Email("contato@v.com.br");
      _address = new Address("Rua Doze", "12", "Bairro Centro","Betim","MG","BR","21343412");
      _student = new Student(_name, _document, _email);
      _subscription = new Subscription(null);     
    }


    [TestMethod]
    public void ShoudReturnErrorWhenHadActiveSubscriptin()
    {
       var payment = new PayPalPayment("123456",DateTime.Now, DateTime.Now.AddDays(5),10,10,"Way Corp",_document, _address, _email);
      _subscription.AddPayment(payment);

      _student.AddSubscription( _subscription );
      _student.AddSubscription( _subscription );

      Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShoudReturnErrorWhenHadActiveSubscriptinHasNotPayment()
    {     
      _student.AddSubscription( _subscription );

      Assert.IsTrue(_student.Invalid);     
    }   

    [TestMethod]
    public void ShoudReturnSuccessWhenAddSubscription()
    {
       var payment = new PayPalPayment("123456",DateTime.Now, DateTime.Now.AddDays(5),10,10,"Way Corp",_document, _address, _email);
      _subscription.AddPayment(payment);

      _student.AddSubscription( _subscription );      

      Assert.IsTrue(_student.Valid);
    } 
  }
}