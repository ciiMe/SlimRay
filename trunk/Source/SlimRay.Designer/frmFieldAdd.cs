using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlimRay.UserData;

namespace SlimRay.Designer
{
    public partial class frmFieldAdd : Form
    {
        List<UserFieldType> _allFieldTypes;

        public bool IsReadOnly
        {
            get
            {
                return !(textBox1.ReadOnly && textBox2.ReadOnly && comboBox1.Enabled);
            }
            set
            {
                textBox1.ReadOnly = !value;
                textBox2.ReadOnly = !value;
                comboBox1.Enabled = !value;
            }
        }

        /// <summary>
        /// the name of data user typed in the dialog.
        /// </summary>
        public string FieldName
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        public UserFieldType FieldType
        {
            get { return (UserFieldType)comboBox1.SelectedItem; }
            set { comboBox1.SelectedIndex = _allFieldTypes.IndexOf(value); }
        }

        public string FieldDescription
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public frmFieldAdd()
        {
            InitializeComponent();

            _allFieldTypes = new List<UserFieldType>();

            var data = new UserFieldType[] {
            UserFieldType.Bit,
            UserFieldType.Byte,

            UserFieldType.Int32,
            UserFieldType.UnInt32,
            UserFieldType.Int64,
            UserFieldType.UnInt64,

            UserFieldType.Float,

            UserFieldType.Emun,

            UserFieldType.Boolean,
            UserFieldType.Char,
            UserFieldType.String,
            UserFieldType.Time,
            UserFieldType.Date,
            UserFieldType.DateTime,
            UserFieldType.Linked
            };

            _allFieldTypes.AddRange(data);

            this.comboBox1.DataSource = _allFieldTypes;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text.Trim();
            this.textBox2.Text = this.textBox2.Text.Trim();

            this.DialogResult = DialogResult.OK;
        }
    }
}
