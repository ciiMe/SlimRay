using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SlimRay.Data;
using SlimRay.Data.Factories;

namespace FunctionTest.Data
{
    class utDataSaveLoadProvider
    {
        public IData PreparedSimpleData()
        {
            string dataName = "Data for sample";

            string field1 = "ID";
            string field2 = "Name";
            string field3 = "Age";
            string field4 = "BirthDay";
            string field5 = "isLikeMusic";

            IData data = SimpleDataFactory.Instance.NewSimpleData(dataName);

            IField f1 = SimpleDataFactory.Instance.NewSimpleField(field1, SlimRay.DataType.String);
            IField f2 = SimpleDataFactory.Instance.NewSimpleField(field2, SlimRay.DataType.String);
            IField f3 = SimpleDataFactory.Instance.NewSimpleField(field3, SlimRay.DataType.UnInt32);
            IField f4 = SimpleDataFactory.Instance.NewSimpleField(field4, SlimRay.DataType.Date);
            IField f5 = SimpleDataFactory.Instance.NewSimpleField(field5, SlimRay.DataType.Boolean);

            data.AddField(f1);
            data.AddField(f2);
            data.AddField(f3);
            data.AddField(f4);
            data.AddField(f5);

            return data;        
        }

        public IDataEntity PreparedDataEntiry()
        {
            IData data = PreparedSimpleData();

            IDataEntity entiry = new DataEntity(data);

            IField fID = entiry.Fields[0];
            IField fName = entiry.Fields[1];
            IField fAge = entiry.Fields[2];
            IField fBirthDay = entiry.Fields[3];
            IField fIsLikeMusic = entiry.Fields[4];

            entiry.SetValue(fID, "00001");
            entiry.SetValue(fName, "Tom jack");
            entiry.SetValue(fAge, "25");
            entiry.SetValue(fBirthDay, "2001-08-15");
            entiry.SetValue(fIsLikeMusic, "Yes");

            return entiry;
        }
    }
}
