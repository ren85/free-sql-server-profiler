namespace AnfiniL.SqlExpressProfiler.Controls
{
    partial class TracePropertiesForm
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
            this.runButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabStrip = new FarsiLibrary.Win.FATabStrip();
            this.generalTabStripItem = new FarsiLibrary.Win.FATabStripItem();
            this.generalTracePropertiesControl = new AnfiniL.SqlExpressProfiler.Controls.GeneralTracePropertiesControl();
            this.eventsTabStripItem = new FarsiLibrary.Win.FATabStripItem();
            this.eventTracePropertiesControl = new AnfiniL.SqlExpressProfiler.Controls.EventTracePropertiesControl();
            this.filtersTabStripItem = new FarsiLibrary.Win.FATabStripItem();
            this.filterTracePropertiesControl = new AnfiniL.SqlExpressProfiler.Controls.FilterTracePropertiesControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip)).BeginInit();
            this.tabStrip.SuspendLayout();
            this.generalTabStripItem.SuspendLayout();
            this.eventsTabStripItem.SuspendLayout();
            this.filtersTabStripItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.Location = new System.Drawing.Point(366, 386);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(447, 386);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // tabStrip
            // 
            this.tabStrip.AlwaysShowClose = false;
            this.tabStrip.AlwaysShowMenuGlyph = false;
            this.tabStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabStrip.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tabStrip.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.generalTabStripItem,
            this.eventsTabStripItem,
            this.filtersTabStripItem});
            this.tabStrip.Location = new System.Drawing.Point(2, 2);
            this.tabStrip.Name = "tabStrip";
            this.tabStrip.SelectedItem = this.generalTabStripItem;
            this.tabStrip.Size = new System.Drawing.Size(539, 378);
            this.tabStrip.TabIndex = 0;
            this.tabStrip.Text = "faTabStrip1";
            // 
            // generalTabStripItem
            // 
            this.generalTabStripItem.CanClose = false;
            this.generalTabStripItem.Controls.Add(this.generalTracePropertiesControl);
            this.generalTabStripItem.IsDrawn = true;
            this.generalTabStripItem.Name = "generalTabStripItem";
            this.generalTabStripItem.Selected = true;
            this.generalTabStripItem.Size = new System.Drawing.Size(537, 357);
            this.generalTabStripItem.TabIndex = 0;
            this.generalTabStripItem.Title = "General";
            // 
            // generalTracePropertiesControl
            // 
            this.generalTracePropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalTracePropertiesControl.Location = new System.Drawing.Point(0, 0);
            this.generalTracePropertiesControl.Name = "generalTracePropertiesControl";
            this.generalTracePropertiesControl.Size = new System.Drawing.Size(537, 357);
            this.generalTracePropertiesControl.TabIndex = 0;
            // 
            // eventsTabStripItem
            // 
            this.eventsTabStripItem.CanClose = false;
            this.eventsTabStripItem.Controls.Add(this.eventTracePropertiesControl);
            this.eventsTabStripItem.IsDrawn = true;
            this.eventsTabStripItem.Name = "eventsTabStripItem";
            this.eventsTabStripItem.Size = new System.Drawing.Size(537, 357);
            this.eventsTabStripItem.TabIndex = 1;
            this.eventsTabStripItem.Title = "Events";
            // 
            // eventTracePropertiesControl
            // 
            this.eventTracePropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventTracePropertiesControl.Location = new System.Drawing.Point(0, 0);
            this.eventTracePropertiesControl.Name = "eventTracePropertiesControl";
            this.eventTracePropertiesControl.Size = new System.Drawing.Size(537, 357);
            this.eventTracePropertiesControl.TabIndex = 0;
            // 
            // filtersTabStripItem
            // 
            this.filtersTabStripItem.CanClose = false;
            this.filtersTabStripItem.Controls.Add(this.filterTracePropertiesControl);
            this.filtersTabStripItem.IsDrawn = true;
            this.filtersTabStripItem.Name = "filtersTabStripItem";
            this.filtersTabStripItem.Size = new System.Drawing.Size(537, 357);
            this.filtersTabStripItem.TabIndex = 3;
            this.filtersTabStripItem.Title = "Filters";
            // 
            // filterTracePropertiesControl
            // 
            this.filterTracePropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTracePropertiesControl.Location = new System.Drawing.Point(0, 0);
            this.filterTracePropertiesControl.Name = "filterTracePropertiesControl";
            this.filterTracePropertiesControl.Size = new System.Drawing.Size(537, 357);
            this.filterTracePropertiesControl.TabIndex = 0;
            // 
            // TracePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 412);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.tabStrip);
            this.MinimumSize = new System.Drawing.Size(552, 446);
            this.Name = "TracePropertiesForm";
            this.ShowInTaskbar = false;
            this.Text = "Trace Properties";
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip)).EndInit();
            this.tabStrip.ResumeLayout(false);
            this.generalTabStripItem.ResumeLayout(false);
            this.eventsTabStripItem.ResumeLayout(false);
            this.filtersTabStripItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button cancelButton;
        private FarsiLibrary.Win.FATabStrip tabStrip;
        private FarsiLibrary.Win.FATabStripItem generalTabStripItem;
        private GeneralTracePropertiesControl generalTracePropertiesControl;
        private FarsiLibrary.Win.FATabStripItem eventsTabStripItem;
        private EventTracePropertiesControl eventTracePropertiesControl;
        private FarsiLibrary.Win.FATabStripItem filtersTabStripItem;
        private FilterTracePropertiesControl filterTracePropertiesControl;
    }
}