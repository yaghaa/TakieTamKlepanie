using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PageReplacementAlgorithm;
using PageReplacementAlgorithm.Interfaces;

namespace PRA.Tests.PageReplacementAlgorithm
{   
    [TestFixture]
    class KlasaDoTestowaniaTests
    {

        private Mock<IPageReplacementAlgorithm> _algorithmnMock;
        private int count = 0;

        [SetUp]
        public void SetUp()
        {
            _algorithmnMock = new Mock<IPageReplacementAlgorithm>();
            
        }

        [Test]
        public void MetodaDoTestów_ReturnTrue_IfGoodValues()
        {
            //Arrange
            var a = 0;
            var b = 1;
            count = 0;
            _algorithmnMock.Setup(x=> x.Simulation(It.IsAny<List<int>>(),It.IsAny<int[]>())).Callback(()=> count++);
            var testObject = new KlasaDoTestowania(_algorithmnMock.Object);
            //Act

            var result = testObject.MetodaDoTestów(a,b);

            //ASSERT

            Assert.AreEqual(result.Result, true);
            Assert.IsInstanceOf<bool>(result.Result);
            Assert.AreEqual(count, 1);

        }


        [Test]
        public void MetodaDoTestów_AlgorithmThrowsException_IsCatched()
        {
            //Arrange
            var a = 0;
            var b = 1;
            var list = new List<int>();
            _algorithmnMock.Setup(x => x.Simulation(list, It.IsAny<int[]>())).Throws(new SuccessException("test"));
            var testObject = new KlasaDoTestowania(_algorithmnMock.Object);
            //Act

            var result = testObject.MetodaDoTestów(a, b);

            //ASSERT

            Assert.AreEqual(result.HasException, true);
            Assert.AreEqual(result.exception.Message,"testowy błąd");
            Assert.IsInstanceOf<SuccessException>(result.HasException);

        }
    }
}
