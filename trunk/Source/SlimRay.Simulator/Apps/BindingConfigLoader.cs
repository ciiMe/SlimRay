using SlimRay.App;
using SlimRay.App.Loaders;
using SlimRay.UserData;
using SlimRay.View.Binding;
using System;
using System.Collections.Generic;

namespace SlimRay.Addins.Simulator.Apps
{
    class BindingConfigLoader : BaseApp, ISimulatorApp, IBindConfigLoader
    {
        private List<IBoundUI> _allBindingConfigData;

        public BindingConfigLoader()
        {
            _name = "View data binding config loader.";
            _key = "Simulator.Apps.BindingConfigLoader";
            _description = "Load all binding config.";
            _version = "0.1";

            _allBindingConfigData = new List<IBoundUI>();
        }

        public IBoundUI[] Get()
        {
            throw new NotImplementedException();
        }

        /* creat a simepl ui
         * this ui is user creating form.
         */
        private void initUserCreateUISimple()
        {
            IBoundUI binding;
            IUserData data;

            /*
             * this is userdata "User", the data is defined in other module.
             * here just reference it.
            data = new UserDataEntity("User", "User who can access and read/write data.");
            data.AddField(new UserFieldEntiry("ID", UserFieldType.Int64));
            data.AddField(new UserFieldEntiry("Name", UserFieldType.String));
            data.AddField(new UserFieldEntiry("LoginName", UserFieldType.String));
            data.AddField(new UserFieldEntiry("LoginPassword", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Description", UserFieldType.String));
            data.AddField(new UserFieldEntiry("Type", UserFieldType.UnInt32));
            data.AddField(new UserFieldEntiry("Status", UserFieldType.Int32));             
             */

            data = SystemApps.GetUserDataHelper().Get("user");

            binding = new BoundShapeEntiry
            {
                DataField = data.Field("loginName"),

                UIType = UICategory.AsEditableText,
                InputTitle = "Login name:",
                Tip = "This is the name used to login, only characters and numbers are allowed.",

                X = 130,
                Y = 0,
                Height = 30,
                Width = 100
            };
            _allBindingConfigData.Add(binding);

            binding = new BoundShapeEntiry
            {
                DataField = data.Field("LoginPassword"),

                UIType = UICategory.AsEditableText,
                InputTitle = "Login password:",
                Tip = "This is the login password, any characters is ok.",

                X = 130,
                Y = 50,
                Height = 30,
                Width = 100
            };
            _allBindingConfigData.Add(binding);

            binding = new BoundShapeEntiry
            {
                UIType = UICategory.AsEditableText,
                InputTitle = "Confirm password:",
                Tip = "Type your password again to confirm your input.",

                X = 130,
                Y = 50,
                Height = 30,
                Width = 100
            };
            _allBindingConfigData.Add(binding);

            binding = new BoundShapeEntiry
            {
                UIType = UICategory.AsButton,
                Text = "Submit",
                Action = new SlimRay.View.BindingUIActions.Confirm
                {
                    NextStepOnSuccess = new SlimRay.View.BindingUIActions.CheckingExists
                    {
                        NextStepOnFail = new SlimRay.View.BindingUIActions.ShowMessage(),
                        NextStepOnSuccess = new SlimRay.View.BindingUIActions.Submit()
                    }
                }
            };
            _allBindingConfigData.Add(binding);

            binding = new BoundShapeEntiry
            {
                UIType = UICategory.AsButton,
                Text = "Cancel",
                Action = new SlimRay.View.BindingUIActions.CloseCurrentForm()
            };
            _allBindingConfigData.Add(binding);

            //create a form
            binding = new BoundShapeEntiry
            {
                UIType = UICategory.AsForm,
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
