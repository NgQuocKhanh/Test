using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace dragdrop
{
    public partial class RadForm2 : Telerik.WinControls.UI.RadForm
    {
        public RadForm2()
        {
            InitializeComponent();

            grv.ShowGroupPanel = false;
            grv.AllowAddNewRow = false;
            grv.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            PrepareUnboundGrid(grv);
            grv.Rows.Add("Carey", "Payette", 2);
            grv.Rows.Add("Michael", "Crump", 4);
            grv.Rows.Add("Jeff", "Fritz", 1);
        }
        private void PrepareUnboundGrid(RadGridView grid)
        {
            //setup columns
            GridViewTextBoxColumn firstName = new GridViewTextBoxColumn("FirstName", "FirstName");
            firstName.HeaderText = "First Name";
            GridViewTextBoxColumn lastName = new GridViewTextBoxColumn("LastName", "LastName");
            lastName.HeaderText = "Last Name";
            GridViewTextBoxColumn so1 = new GridViewTextBoxColumn("Number 1", "Number1");
            grid.Columns.AddRange(firstName, lastName,so1);
        }
    }
}
