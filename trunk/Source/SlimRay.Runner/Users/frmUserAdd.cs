﻿using SlimRay.App;
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
    }
}
