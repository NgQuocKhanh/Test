﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace dragdrop
{
    class DragAndDropRadGrid : RadGridView
    {
        public DragAndDropRadGrid()
        {
            this.MultiSelect = true;

            //handle drag and drop events for the grid through the DragDrop service
            RadDragDropService svc =
                this.GridViewElement.GetService<RadDragDropService>();
            svc.PreviewDragStart += svc_PreviewDragStart;
            svc.PreviewDragDrop += svc_PreviewDragDrop;
            svc.PreviewDragOver += svc_PreviewDragOver;

            //register the custom row selection behavior
            var gridBehavior = this.GridBehavior as BaseGridBehavior;
            gridBehavior.UnregisterBehavior(typeof(GridViewDataRowInfo));
            gridBehavior.RegisterBehavior(typeof(GridViewDataRowInfo), new RowSelectionGridBehavior());
        }

        public override string ThemeClassName
        {
            get
            {
                return typeof(RadGridView).FullName;
            }
        }
        //initiates drag and drop service for clicked rows
        public class RowSelectionGridBehavior : GridDataRowBehavior
        {
            protected override bool OnMouseDownLeft(MouseEventArgs e)
            {
                GridDataRowElement row = this.GetRowAtPoint(e.Location) as GridDataRowElement;
                if (row != null)
                {
                    RadGridViewDragDropService svc = this.GridViewElement.GetService<RadGridViewDragDropService>();
                    svc.AllowAutoScrollColumnsWhileDragging = false;
                    svc.AllowAutoScrollRowsWhileDragging = false;
                    svc.Start(row);
                }
                return base.OnMouseDownLeft(e);
            }
        }
        //required to initiate drag and drop when grid is in bound mode
        private void svc_PreviewDragStart(object sender, PreviewDragStartEventArgs e)
        {
            e.CanStart = true;
        }
        private void svc_PreviewDragOver(object sender, RadDragOverEventArgs e)
        {
            if (e.DragInstance is GridDataRowElement)
            {
                e.CanDrop = e.HitTarget is GridDataRowElement ||
                            e.HitTarget is GridTableElement ||
                            e.HitTarget is GridSummaryRowElement;
            }
        }
        //gather drag/source grid and target/destination information and initiate the move of selected rows
        private void svc_PreviewDragDrop(object sender, RadDropEventArgs e)
        {
            var rowElement = e.DragInstance as GridDataRowElement;
            if (rowElement == null)
            {
                return;
            }
            e.Handled = true;

            var dropTarget = e.HitTarget as RadItem;
            var targetGrid = dropTarget.ElementTree.Control as RadGridView;
            if (targetGrid == null)
            {
                return;
            }

            var dragGrid = rowElement.ElementTree.Control as RadGridView;
            if (targetGrid != dragGrid)
            {
                e.Handled = true;
                //append dragged rows to the end of the target grid
                //int index = targetGrid.RowCount;

                GridDataRowElement dropTargetRow = dropTarget as GridDataRowElement;
                int index = dropTargetRow != null ? this.GetTargetRowIndex(dropTargetRow, e.DropLocation) : targetGrid.RowCount;

                //Grab every selected row from the source grid, including the current row
                List<GridViewRowInfo> rows =
                    dragGrid.SelectedRows.ToList<GridViewRowInfo>();
                if (dragGrid.CurrentRow != null)
                {
                    GridViewRowInfo row = dragGrid.CurrentRow;
                    if (!rows.Contains(row))
                        rows.Add(row);
                }
                this.MoveRows(targetGrid, dragGrid, rows, index);
            }
            else
            {
                e.Handled = true;
                //append dragged rows to the end of the target grid
                //int index = targetGrid.RowCount;

                GridDataRowElement dropTargetRow = dropTarget as GridDataRowElement;
                int index = dropTargetRow != null ? this.GetTargetRowIndex(dropTargetRow, e.DropLocation) : targetGrid.RowCount;

                //Grab every selected row from the source grid, including the current row
                List<GridViewRowInfo> rows =
                    dragGrid.SelectedRows.ToList<GridViewRowInfo>();
                if (dragGrid.CurrentRow != null)
                {
                    GridViewRowInfo row = dragGrid.CurrentRow;
                    if (!rows.Contains(row))
                        rows.Add(row);
                }
                this.MoveRows(targetGrid, dragGrid, rows, index);
            }
        }
        private void MoveRows(RadGridView targetGrid, RadGridView dragGrid,
    IList<GridViewRowInfo> dragRows, int index)
        {
            dragGrid.BeginUpdate();
            targetGrid.BeginUpdate();
            for (int i = dragRows.Count - 1; i >= 0; i--)
            {
                GridViewRowInfo row = dragRows[i];
                if (row is GridViewSummaryRowInfo)
                {
                    continue;
                }
                if (targetGrid.DataSource == null)
                {
                    //unbound scenario
                    GridViewRowInfo newRow = targetGrid.Rows.NewRow();
                    foreach (GridViewCellInfo cell in row.Cells)
                    {
                        if (newRow.Cells[cell.ColumnInfo.Name] != null)
                            newRow.Cells[cell.ColumnInfo.Name].Value = cell.Value;
                    }

                    targetGrid.Rows.Insert(index, newRow);

                    row.IsSelected = false;
                    dragGrid.Rows.Remove(row);
                }
                else if (typeof(DataSet).IsAssignableFrom(targetGrid.DataSource.GetType()))
                {
                    //bound to a dataset scenario
                    var sourceTable = ((DataSet)dragGrid.DataSource).Tables[0];
                    var targetTable = ((DataSet)targetGrid.DataSource).Tables[0];

                    var newRow = targetTable.NewRow();
                    foreach (GridViewCellInfo cell in row.Cells)
                    {
                        newRow[cell.ColumnInfo.Name] = cell.Value;
                    }

                    sourceTable.Rows.Remove(((DataRowView)row.DataBoundItem).Row);
                    targetTable.Rows.InsertAt(newRow, index);
                }
                else if (typeof(IList).IsAssignableFrom(targetGrid.DataSource.GetType()))
                {
                    //bound to a list of objects scenario
                    var targetCollection = (IList)targetGrid.DataSource;
                    var sourceCollection = (IList)dragGrid.DataSource;
                    sourceCollection.Remove(row.DataBoundItem);
                    targetCollection.Add(row.DataBoundItem);
                }
                else
                {
                    throw new ApplicationException("Unhandled Scenario");
                }
                index++;
            }
            dragGrid.EndUpdate(true);
            targetGrid.EndUpdate(true);
        }
        private int GetTargetRowIndex(GridDataRowElement row, Point dropLocation)
        {
            int halfHeight = row.Size.Height / 2;
            int index = row.RowInfo.Index;
            if (dropLocation.Y > halfHeight)
            {
                index++;
            }
            return index;
        }
    }
}
