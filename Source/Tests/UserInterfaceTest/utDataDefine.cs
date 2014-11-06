using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimRay.Data;
using SlimRay.Data.Factories;
using SlimRay.Data.Store;

namespace UserInterfaceTest
{
    [TestClass]
    public class utDataDefine
    {
        [TestMethod]
        public ISimpleData CreateASimpleData()
        {
            string dataName = "Data Name";

            ISimpleData data = SimpleDataFactory.Instance.NewSimpleData(dataName);
            Assert.AreNotEqual(null, data);

            return data;
        }

        [TestMethod]
        public ISimpleData AddFieldForSimpleData()
        {
            ISimpleData data = CreateASimpleData();

            string fieldName1 = "Field1";

            ISimpleField f1 = SimpleDataFactory.Instance.NewSimpleField(fieldName1, SlimRay.DataType.UnInt32);

            data.AddField(f1);

            Assert.AreEqual(data.Fields.Length, 1);

            Assert.AreEqual(data.Fields[0].Name, "Field1");

            return data;
        }

        [TestMethod]
        public ISimpleData SetKeyField()
        {
            ISimpleData data = AddFieldForSimpleData();

            data.SetFieldKeyFlag(data.Fields[0], true);

            return data;
        }

        [TestMethod]
        public IDataEntity UpdateFieldValue()
        {
            ISimpleData data = SetKeyField();

            DataEntity entity = new DataEntity(data);

            string id = "ID:2014110605";

            entity.SetValue(entity.Fields[0], id);

            Assert.AreEqual(entity.ValueString(entity.Fields[0]), id);

            return entity;
        }

        [TestMethod]
        public void InsertDataToXML()
        {
            IDataEntity entity = UpdateFieldValue();

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
            IDataEntity entity = UpdateFieldValue();

            StorageAddress address = new StorageAddress()
            {
                Type = StorageType.MSSQLServer,
                Address = "192.168.1.1,sa,sa"
            };

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
    }
}
