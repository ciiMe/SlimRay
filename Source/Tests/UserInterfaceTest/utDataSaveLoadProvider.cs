using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SlimRay.Data;
using SlimRay.Data.Factories;

namespace UserInterfaceTest
{
    class utDataSaveLoadProvider
    {
        public ISimpleData PreparedSimpleData()
        {
            string dataName = "Data for sample";

            string field1 = "ID";
            string field2 = "Name";
            string field3 = "Age";
            string field4 = "BirthDay";
            string field5 = "isLikeMusic";

            ISimpleData data = SimpleDataFactory.Instance.NewSimpleData(dataName);

            ISimpleField f1 = SimpleDataFactory.Instance.NewSimpleField(field1, SlimRay.DataType.String);
            ISimpleField f2 = SimpleDataFactory.Instance.NewSimpleField(field2, SlimRay.DataType.String);
            ISimpleField f3 = SimpleDataFactory.Instance.NewSimpleField(field3, SlimRay.DataType.UnInt32);
            ISimpleField f4 = SimpleDataFactory.Instance.NewSimpleField(field4, SlimRay.DataType.Date);
            ISimpleField f5 = SimpleDataFactory.Instance.NewSimpleField(field5, SlimRay.DataType.Boolean);

            return data;        
        }

        public IDataEntity PreparedDataEntiry()
        {
            ISimpleData data = PreparedSimpleData();

            IDataEntity entiry = new DataEntity(data);

            ISimpleField fID = entiry.Fields[0];
            ISimpleField fName = entiry.Fields[1];
            ISimpleField fAge = entiry.Fields[2];
            ISimpleField fBirthDay = entiry.Fields[3];
            ISimpleField fIsLikeMusic = entiry.Fields[4];

            entiry.SetValue(fID, "00001");
            entiry.SetValue(fName, "Tom jack");
            entiry.SetValue(fAge, "25");
            entiry.SetValue(fBirthDay, "2001-08-15");
            entiry.SetValue(fIsLikeMusic, "Yes");

            return entiry;
        }
    }
}
