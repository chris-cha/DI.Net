using System;
using Moq;
using chap1_adapter_console.HelloDI.CommandLine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExclaimWillWriteCorrectMessageToMessageWriter()
        {
            var writeMock = new Mock<IMessageWriter>();
            var sut = new Salutation(writeMock.Object);
            sut.Exclaim();
            writeMock.Verify(w => w.Write("Hello DI!"));
        }
    }
}
