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
            /*
            string field1 = "ID";
            string field2 = "Name";
            string field3 = "Age";
            string field4 = "BirthDay";
            string field5 = "isLikeMusic";
             */

            string maxAge = "20";
            string isLikeMusic = "Yes";

            ISimpleData data = _provider.PreparedSimpleData();
            ISimpleField fieldAge = data.Fields[2];
            ISimpleField fieldLikeMusic = data.Fields[4];

            Expression expression = new Expression(fieldAge, ExpressionOperator.ValueSmallerOrEqual, maxAge);
            expression = expression & new Expression(fieldLikeMusic, ExpressionOperator.ValueEqual, isLikeMusic);
            
            IDataEntity entiry = SimpleStore.Instance.LoadRecord(expression);
        }
    }
}
