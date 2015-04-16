using System;

using SlimRay.UserData;

namespace SlimRay.Designer.DataDefinition
{
    public class SystemData : ISystemData
    {
        private IField _id;
        public IField _name;
        public IField _description;

        public IField _createDate;
        public IField _createUserID;
        public IField _createUserAccount;

        public SystemData()
        {

        }
    }
}
