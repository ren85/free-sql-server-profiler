namespace AnfiniL.SqlExpressProfiler.Controls
{
    partial class TraceViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dataGridStyledPanel = new Attech.FlightMonitor.UI.Controls.StyledPanel();
            this.traceDataGridView = new System.Windows.Forms.DataGridView();
            this.detailsStyledPanel = new Attech.FlightMonitor.UI.Controls.StyledPanel();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.dataGridStyledPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traceDataGridView)).BeginInit();
            this.detailsStyledPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 210);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(750, 3);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // dataGridStyledPanel
            // 
            this.dataGridStyledPanel.BorderColor = System.Drawing.Color.Gray;
            this.dataGridStyledPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridStyledPanel.Controls.Add(this.traceDataGridView);
            this.dataGridStyledPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridStyledPanel.GradientColor1 = System.Drawing.Color.Empty;
            this.dataGridStyledPanel.GradientColor2 = System.Drawing.Color.Empty;
            this.dataGridStyledPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.dataGridStyledPanel.Location = new System.Drawing.Point(0, 0);
            this.dataGridStyledPanel.Name = "dataGridStyledPanel";
            this.dataGridStyledPanel.Size = new System.Drawing.Size(750, 210);
            this.dataGridStyledPanel.TabIndex = 9;
            this.dataGridStyledPanel.UseGradientBackColor = false;
            // 
            // traceDataGridView
            // 
            this.traceDataGridView.AllowUserToAddRows = false;
            this.traceDataGridView.AllowUserToDeleteRows = false;
            this.traceDataGridView.AllowUserToOrderColumns = true;
            this.traceDataGridView.AllowUserToResizeRows = false;
            this.traceDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.traceDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.traceDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.traceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.traceDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.traceDataGridView.Location = new System.Drawing.Point(1, 1);
            this.traceDataGridView.Name = "traceDataGridView";
            this.traceDataGridView.ReadOnly = true;
            this.traceDataGridView.RowHeadersVisible = false;
            this.traceDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.traceDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.traceDataGridView.Size = new System.Drawing.Size(748, 208);
            this.traceDataGridView.TabIndex = 5;
            this.traceDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.traceDataGridView_RowsAdded);
            this.traceDataGridView.SelectionChanged += new System.EventHandler(this.traceDataGridView_SelectionChanged);
            // 
            // detailsStyledPanel
            // 
            this.detailsStyledPanel.BorderColor = System.Drawing.Color.Gray;
            this.detailsStyledPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsStyledPanel.Controls.Add(this.detailsTextBox);
            this.detailsStyledPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.detailsStyledPanel.GradientColor1 = System.Drawing.Color.Empty;
            this.detailsStyledPanel.GradientColor2 = System.Drawing.Color.Empty;
            this.detailsStyledPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.detailsStyledPanel.Location = new System.Drawing.Point(0, 213);
            this.detailsStyledPanel.Name = "detailsStyledPanel";
            this.detailsStyledPanel.Size = new System.Drawing.Size(750, 223);
            this.detailsStyledPanel.TabIndex = 8;
            this.detailsStyledPanel.Text = "styledPanel1";
            this.detailsStyledPanel.UseGradientBackColor = false;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsTextBox.Location = new System.Drawing.Point(1, 1);
            this.detailsTextBox.MaxLength = 327679999;
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.ReadOnly = true;
            this.detailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailsTextBox.Size = new System.Drawing.Size(748, 221);
            this.detailsTextBox.TabIndex = 0;
            // 
            // TraceViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridStyledPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.detailsStyledPanel);
            this.Name = "TraceViewControl";
            this.Size = new System.Drawing.Size(750, 436);
            this.dataGridStyledPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.traceDataGridView)).EndInit();
            this.detailsStyledPanel.ResumeLayout(false);
            this.detailsStyledPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView traceDataGridView;
        private Attech.FlightMonitor.UI.Controls.StyledPanel detailsStyledPanel;
        private Attech.FlightMonitor.UI.Controls.StyledPanel dataGridStyledPanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox detailsTextBox;
    }
}
