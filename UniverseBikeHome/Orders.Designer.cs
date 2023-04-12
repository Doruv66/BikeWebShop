namespace UniverseBikeHome
{
    partial class Orders
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.OrderPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.cbStatus = new System.Windows.Forms.ComboBox();
			this.lblSort = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
			this.panel1.Controls.Add(this.lblTitle);
			this.panel1.Location = new System.Drawing.Point(1, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1383, 134);
			this.panel1.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(577, 37);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(208, 59);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Orders";
			// 
			// OrderPanel
			// 
			this.OrderPanel.AutoScroll = true;
			this.OrderPanel.Location = new System.Drawing.Point(1, 270);
			this.OrderPanel.Name = "OrderPanel";
			this.OrderPanel.Size = new System.Drawing.Size(1383, 923);
			this.OrderPanel.TabIndex = 2;
			// 
			// cbStatus
			// 
			this.cbStatus.FormattingEnabled = true;
			this.cbStatus.Items.AddRange(new object[] {
            "placed",
            "shipped"});
			this.cbStatus.Location = new System.Drawing.Point(1160, 217);
			this.cbStatus.Name = "cbStatus";
			this.cbStatus.Size = new System.Drawing.Size(202, 33);
			this.cbStatus.TabIndex = 9;
			this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
			// 
			// lblSort
			// 
			this.lblSort.AutoSize = true;
			this.lblSort.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSort.Location = new System.Drawing.Point(1201, 158);
			this.lblSort.Name = "lblSort";
			this.lblSort.Size = new System.Drawing.Size(100, 38);
			this.lblSort.TabIndex = 10;
			this.lblSort.Text = "Sort:";
			// 
			// Orders
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1387, 1194);
			this.Controls.Add(this.lblSort);
			this.Controls.Add(this.cbStatus);
			this.Controls.Add(this.OrderPanel);
			this.Controls.Add(this.panel1);
			this.Name = "Orders";
			this.Text = "Orders";
			this.Load += new System.EventHandler(this.Orders_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel OrderPanel;
		private System.Windows.Forms.ComboBox cbStatus;
		private System.Windows.Forms.Label lblSort;
	}
}