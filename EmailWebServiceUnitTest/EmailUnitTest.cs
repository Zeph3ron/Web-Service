using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFServiceWebRole1;

namespace EmailWebServiceUnitTest
{
    [TestClass]
    public class EmailUnitTest
    {
        private EmailService _emailService;

        [TestInitialize]
        public void TestSetup()
        {
            _emailService = new EmailService();
        }

        [TestMethod]
        public void TestSendEmail()
        {
            bool sent = false;
            sent = _emailService.CreateEmailAndSend("zeph3ron@gmail.com", "Unit-Test-Email", "This is a test");
            Assert.IsTrue(sent);
        }
    }
}
