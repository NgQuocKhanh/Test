using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace dragdrop
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
            leftGrid.ShowGroupPanel = false;
            rightGrid.ShowGroupPanel = false;
            leftGrid.AllowAddNewRow = false;
            rightGrid.AllowAddNewRow = false;
            leftGrid.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            rightGrid.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            GridViewSummaryRowItem summaryItem = new GridViewSummaryRowItem();
            summaryItem.Add(new GridViewSummaryItem("Number 1", "Total {0}", GridAggregateFunction.Sum));
            this.leftGrid.MasterTemplate.SummaryRowsBottom.Add(summaryItem);
            this.rightGrid.MasterTemplate.SummaryRowsBottom.Add(summaryItem);
        }

        private void ResetGrids()
        {
            leftGrid.DataSource = null;
            leftGrid.Rows.Clear();
            leftGrid.Columns.Clear();
            rightGrid.DataSource = null;
            rightGrid.Rows.Clear();
            rightGrid.Columns.Clear();
        }
        private void btnUnbound_Click(object sender, EventArgs e)
        {
            ResetGrids();
            PrepareUnboundGrid(leftGrid);
            leftGrid.Rows.Add("Carey", "Payette",2);
            leftGrid.Rows.Add("Michael", "Crump",4);
            leftGrid.Rows.Add("Jeff", "Fritz",1);
            PrepareUnboundGrid(rightGrid);
            rightGrid.Rows.Add("Phil", "Japikse",3);
            rightGrid.Rows.Add("Jesse", "Liberty",5);
            rightGrid.Rows.Add("Iris", "Classon",6);
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

        private void radButton2_Click(object sender, EventArgs e)
        {
            RadForm2 frm = new RadForm2();
            frm.Show();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            GridViewRowInfo row = leftGrid.Rows.NewRow();
            leftGrid.Rows.Insert(2, row);
        }
    }
}
