namespace AnfiniL.SqlExpressProfiler.Controls
{
    partial class EventTracePropertiesControl
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
            this.captionLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.selectUnSelectCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Location = new System.Drawing.Point(4, 4);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(258, 13);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "Preview selected events and event columns to trace.";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(7, 21);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(408, 306);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView_CurrentCellDirtyStateChanged);
            // 
            // selectUnSelectCheckBox
            // 
            this.selectUnSelectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectUnSelectCheckBox.AutoSize = true;
            this.selectUnSelectCheckBox.Location = new System.Drawing.Point(7, 332);
            this.selectUnSelectCheckBox.Name = "selectUnSelectCheckBox";
            this.selectUnSelectCheckBox.Size = new System.Drawing.Size(151, 17);
            this.selectUnSelectCheckBox.TabIndex = 2;
            this.selectUnSelectCheckBox.Text = "Select/Unselect all events";
            this.selectUnSelectCheckBox.UseVisualStyleBackColor = true;
            this.selectUnSelectCheckBox.CheckedChanged += new System.EventHandler(this.selectUnSelectCheckBox_CheckedChanged);
            // 
            // EventTracePropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectUnSelectCheckBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.captionLabel);
            this.Name = "EventTracePropertiesControl";
            this.Size = new System.Drawing.Size(423, 352);
            this.Load += new System.EventHandler(this.EventTracePropertiesControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox selectUnSelectCheckBox;
    }
}
