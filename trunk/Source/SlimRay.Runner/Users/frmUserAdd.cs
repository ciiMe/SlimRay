using SlimRay.App;
using SlimRay.UserData;
using SlimRay.View.Binding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SlimRay.Runner.Users
{
    public partial class frmUserAdd : Form
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }

        private object loadBindingUI()
        {
            var loader = AppGate.Instance.GetUIBindingLoader();

            var uiItems = loader.Get();

            return uiItems;
        }

        private string getFieldData(IBoundUI bindData)
        {
            IUserDataValueLoader loader = App.AppGate.Instance.Get("IUserDataValueLoader") as IUserDataValueLoader;

            return loader.Load(bindData.DataField);
        }
    }
}
