using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimRay.Data;
using SlimRay.Data.Factories;

namespace UserInterfaceTest
{
    [TestClass]
    public class utDataDefine
    {
        [TestMethod]
        public ISimpleData CreateASimpleData()
        {
            ISimpleData sd = SimpleDataFactory.Instance.NewSimpleData("Data Name");
            Assert.AreNotEqual(null, sd);

            return sd;
        }

        public void AddFieldForSimpleData()
        {
            ISimpleData sd = CreateASimpleData();

        }
    }
}
