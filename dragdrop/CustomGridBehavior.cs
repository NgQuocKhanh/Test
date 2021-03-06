﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace dragdrop
{
    class CustomGridBehavior: BaseGridBehavior
    {
        List<GridViewRowInfo> selectedRows = new List<GridViewRowInfo>();
        public List<GridViewRowInfo> SelectedRows
        {
            get
            {
                return this.selectedRows;
            }
        }
        public override bool OnMouseDown(MouseEventArgs e)
        {
            selectedRows.Clear(); bool result = base.OnMouseDown(e);
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control || (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                selectedRows.AddRange(this.GridControl.SelectedRows);
            }
            else
            {
                selectedRows.Add(this.GridControl.CurrentRow);
            }
            return result;
        }
    }
}
