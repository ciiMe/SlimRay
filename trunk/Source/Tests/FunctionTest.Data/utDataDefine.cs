﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimRay.Data;
using SlimRay.Data.Factories;
using SlimRay.Data.Store;

namespace FunctionTest.Data
{
    /*
     * this class tests:
     * 1. how the data is defined,
     * 2. how the fields are bind to the data,
     * 3. how the field value is set.
     * 4. how the field value is get
     */
    [TestClass]
    public class utDataDefine
    {
        [TestMethod]
        public IData CreateASimpleData()
        {
            string dataName = "Data Name";

            IData data = SimpleDataFactory.Instance.NewSimpleData(dataName);
            Assert.AreNotEqual(null, data);

            return data;
        }

        [TestMethod]
        public IData AddFieldForSimpleData()
        {
            IData data = CreateASimpleData();

            string fieldName1 = "Field1";

            IField f1 = SimpleDataFactory.Instance.NewSimpleField(fieldName1, SlimRay.DataType.UnInt32);

            data.AddField(f1);

            Assert.AreEqual(data.Fields.Length, 1);

            Assert.AreEqual(data.Fields[0].Name, "Field1");

            return data;
        }
        
        [TestMethod]
        public IDataEntity UpdateFieldValue()
        {
            IData data = AddFieldForSimpleData();

            DataEntity entity = new DataEntity(data);

            string id = "ID:2014110605";

            entity.SetValue(entity.Fields[0], id);

            Assert.AreEqual(entity.ValueString(entity.Fields[0]), id);

            return entity;
        }

    }
}
