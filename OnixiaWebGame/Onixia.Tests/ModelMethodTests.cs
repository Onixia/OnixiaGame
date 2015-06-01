using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onixia.Models;

namespace Onixia.Tests
{
    [TestClass]
    public class ModelMethodTests
    {
        [TestMethod]
        public void ResourceBanksShouldAddCorrectly()
        {
            ResourceBank rbOne = new ResourceBank(200, 200, 200, 200);
            ResourceBank rbTwo = new ResourceBank(200, 200, 200, 200);

            ResourceBank rbThree = rbTwo + rbOne;
            Assert.IsTrue(rbThree.Metal > rbTwo.Metal);

            Assert.IsTrue((rbOne + rbTwo).Metal == rbThree.Metal);
        }

        [TestMethod]
        public void ResourceBanksShouldSubstractCorrectly()
        {
            ResourceBank rbOne = new ResourceBank(200, 200, 200, 200);
            ResourceBank rbTwo = new ResourceBank(200, 200, 200, 200);

            ResourceBank rbThree = rbTwo - rbOne;
            ResourceBank nullResource = new ResourceBank();
            Assert.IsTrue(rbThree.Metal == nullResource.Metal);
            Assert.IsTrue( (rbTwo - rbTwo).Metal == 0); 
        }

        [TestMethod]
        public void ResourceBanksShouldContainCorrectly()
        {
            ResourceBank rbOne = new ResourceBank(200, 200, 200, 200);
            ResourceBank rbTwo = new ResourceBank(200, 200, 200, 200);

            Assert.IsTrue(rbTwo.HasEnoughFor(rbOne));
            rbTwo += rbOne;
            Assert.IsFalse(rbOne.HasEnoughFor(rbTwo));
            rbOne += rbTwo;
            Assert.IsTrue(rbOne.HasEnoughFor(rbTwo));
        }
    }
}
