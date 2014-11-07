using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimRay.Data;
using SlimRay.Data.Store;

namespace UserInterfaceTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class utDataSaveLoad
    {
        private utDataSaveLoadProvider _provider;

        public utDataSaveLoad()
        {
            _provider = new utDataSaveLoadProvider();
        }

        [TestMethod]
        public void InsertDataToXML()
        {
            IDataEntity entity = _provider.PreparedDataEntiry();

            StorageAddress address = new StorageAddress()
            {
                Type = StorageType.XML,
                Address = "d:\\temp\\MyData.xml"
            };

            SimpleStore.Instance.AssignStorageType(entity, address);

            SimpleStore.Instance.InsertNewRecord(entity);
        }

        [TestMethod]
        public void InsertDataToMSSQL()
        {
            IDataEntity entity = _provider.PreparedDataEntiry();

            StorageAddress address = new StorageAddress()
            {
                Type = StorageType.MSSQLServer
            };

            address.SetParameterValue("HostName", "192.168.1.1");
            address.SetParameterValue("dbUser", "sa");
            address.SetParameterValue("dbPwd", "sa");

            SimpleStore.Instance.AssignStorageType(entity, address);

            SimpleStore.Instance.InsertNewRecord(entity);
        }

        [TestMethod]
        public void LoadData()
        {
            string dataName = "Data Name";
            string id = "ID:2014110605";
            ISimpleData data = SimpleStore.Instance.LoadRecord(dataName, id);
        }

        [TestMethod]
        public void LoadDataByExpression()
        {
            string dataName = "Data Name";
            string id = "ID:2014110605";

            ISimpleData data = _provider.PreparedSimpleData();

            Assert.Fail("expression cannot link with data.");
            Expression expression = new Expression();

            expression.Field = data.Fields[0];
            expression.Operator = ExpressionOperator.ValueEqual;
            Assert.Fail("expression can not set value.");
            expression.Sub = null;

            IDataEntity entiry = SimpleStore.Instance.LoadRecord(expression);
        }
    }
}
