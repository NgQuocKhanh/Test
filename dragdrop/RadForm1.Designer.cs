namespace dragdrop
{
    partial class RadForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.rightGrid = new dragdrop.DragAndDropRadGrid();
            this.leftGrid = new dragdrop.DragAndDropRadGrid();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(277, 314);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "radButton1";
            this.radButton1.Click += new System.EventHandler(this.btnUnbound_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(499, 314);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 2;
            this.radButton2.Text = "radButton2";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(22, 314);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(110, 24);
            this.radButton3.TabIndex = 3;
            this.radButton3.Text = "radButton3";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // rightGrid
            // 
            this.rightGrid.Location = new System.Drawing.Point(355, 12);
            // 
            // 
            // 
            this.rightGrid.MasterTemplate.MultiSelect = true;
            this.rightGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rightGrid.Name = "rightGrid";
            this.rightGrid.Size = new System.Drawing.Size(299, 287);
            this.rightGrid.TabIndex = 1;
            this.rightGrid.Text = "dragAndDropRadGrid2";
            // 
            // leftGrid
            // 
            this.leftGrid.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.leftGrid.MasterTemplate.MultiSelect = true;
            this.leftGrid.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.leftGrid.Name = "leftGrid";
            this.leftGrid.Size = new System.Drawing.Size(299, 287);
            this.leftGrid.TabIndex = 0;
            this.leftGrid.Text = "dragAndDropRadGrid1";
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 350);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.rightGrid);
            this.Controls.Add(this.leftGrid);
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadForm1";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DragAndDropRadGrid leftGrid;
        private DragAndDropRadGrid rightGrid;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton3;
    }
}