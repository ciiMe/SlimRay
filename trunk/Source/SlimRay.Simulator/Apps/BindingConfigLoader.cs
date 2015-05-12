using SlimRay.App;
using SlimRay.UserData;
using SlimRay.View;
using System;
using System.Collections.Generic;

namespace SlimRay.Simulator.Apps
{
    class BindingConfigLoader : ISimulatorApp, IBindingConfigLoader
    {
        private const string _name = "View data binding config loader.";
        private List<IBindingShape> _allBindingConfigData;

        public string Name
        {
            get { return _name; }
        }

        public string SerialKey
        {
            get { return AppKeys.BingdingConfigLoader; }
        }

        public BindingConfigLoader()
        {
            _allBindingConfigData = new List<IBindingShape>();
        }

        public IBindingShape[] Get()
        {
            throw new NotImplementedException();
        }

        /* creat a simepl ui
         * this ui is user creating form.
         */
        private void initUserCreateUISimple()
        {
            IBindingShape binding;
            IUserData data;

            /*
             * init data binding for user
             * user data:
            data = new UserDataEntity("User", "User who can access and read/write data.");
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.AddField(new UserFieldEntiry("LoginName", UserFieldType.String));
            data.AddField(new UserFieldEntiry("LoginPassword", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Description", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Type", UserFieldType.UnInt32));
            data.AddField(new UserFieldEntiry("Status", UserFieldType.Int32));             
             */

            data = AppGate.GetUserDataLoader().Get("user");

            binding = new BindingShapeEntiry
            {
                DataField = data.Field("loginName"),

                UIType = UIBehaviorType.AsEditableText,
                InputTitle = "Login name:",
                Tip = "This is the name used to login, only characters and numbers are allowed.",

                X = 130,
                Y = 0,
                Height = 30,
                Width = 100
            };
            _allBindingConfigData.Add(binding);

            binding = new BindingShapeEntiry
            {
                DataField = data.Field("LoginPassword"),

                UIType = UIBehaviorType.AsEditableText,
                InputTitle = "Login password:",
                Tip = "This is the login password, any characters is ok.",

                X = 130,
                Y = 50,
                Height = 30,
                Width = 100
            };
            _allBindingConfigData.Add(binding);

            binding = new BindingShapeEntiry
            {
                UIType = UIBehaviorType.AsEditableText,
                InputTitle = "Confirm password:",
                Tip = "Type your password again to confirm your input.",

                X = 130,
                Y = 50,
                Height = 30,
                Width = 100
            };
            _allBindingConfigData.Add(binding);

            binding = new BindingShapeEntiry
            {
                UIType = UIBehaviorType.AsButton,
                Text = "Submit",
                Action = null
            };
            _allBindingConfigData.Add(binding);

            binding = new BindingShapeEntiry
            {
                UIType = UIBehaviorType.AsButton,
                Text = "Cancel",
                Action = null
            };
            _allBindingConfigData.Add(binding);

            //create a form
            binding = new BindingShapeEntiry
            {
                UIType = UIBehaviorType.AsForm,
                Text = "Create new user",

                Width = 400,
                Height = 300,

                Items = _allBindingConfigData.ToArray()
            };
            //set the form as the only ui that contains all others.
            _allBindingConfigData.Clear();
            _allBindingConfigData.Add(binding);

        }
    }
}
