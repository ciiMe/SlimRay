using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimRay.UserData;

namespace SlimRay.Designer.Demo
{
    internal class SystemDataFiller
    {
        public List<IData> getAllSystemData()
        {
            List<IData> dList = new List<IData>();

            Data data = new Data("Data", "List of all data which is used only in the internal modules.");
            data.AddField(new Field("ID", FieldType.Int64));
            data.AddField(new Field("Name", FieldType.String));
            data.AddField(new Field("Description", FieldType.String));
            dList.Add(data);

            data = new Data("Fields", "Field list for all data");
            data.AddField(new Field("DataID", "Id of data which it belongs to.", FieldType.Int64));
            data.AddField(new Field("ID", FieldType.Int64));
            data.AddField(new Field("Name", FieldType.String));
            data.AddField(new Field("Description", FieldType.String));
            data.AddField(new Field("Type", FieldType.UnInt32));
            dList.Add(data);

            //link data and fields.
            dList[0].Link(dList[1].Fields[0], FieldLinkRelation.FieldofList);

            data = new Data("Group", "Group for users.");
            data.AddField(new Field("ID", FieldType.Int64));
            data.AddField(new Field("Name", FieldType.String));
            data.AddField(new Field("Description", FieldType.String));
            dList.Add(data);

            data = new Data("User", "User who can access and read/write data.");
            data.AddField(new Field("ID", FieldType.Int64));
            data.AddField(new Field("Name", FieldType.String));
            data.AddField(new Field("LoginName", FieldType.String));
            data.AddField(new Field("LoginPassword", FieldType.String));
            data.AddField(new Field("Description", FieldType.String));
            data.AddField(new Field("Type", FieldType.UnInt32));
            dList.Add(data);

            data = new Data("UserGroup", "Links between user and group.");
            data.AddField(new Field("UserID", FieldType.Int64));
            data.AddField(new Field("GroupID", FieldType.Int64));
            dList.Add(data);

            //User group setting should be able to load all detail data of user and group.
            dList[4].Link(dList[2].Fields[0], FieldLinkRelation.AnotherPartofData);
            dList[4].Link(dList[3].Fields[0], FieldLinkRelation.AnotherPartofData);
                        
            return dList;
        }

        private void fillFields_Data(IData data)
        {

            int index = 0;
            foreach (IField field in data.Fields)
            {
                field.ID = index;
                index++;
            }
        }
    }
}
