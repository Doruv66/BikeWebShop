namespace UniverseBikeHome
{
	partial class UpdateBikeForm
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
			this.txtImage = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtStock = new System.Windows.Forms.TextBox();
			this.pbNewBike = new System.Windows.Forms.PictureBox();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbNewBike)).BeginInit();
			this.SuspendLayout();
			// 
			// txtImage
			// 
			this.txtImage.Location = new System.Drawing.Point(228, 529);
			this.txtImage.Multiline = true;
			this.txtImage.Name = "txtImage";
			this.txtImage.ReadOnly = true;
			this.txtImage.Size = new System.Drawing.Size(301, 50);
			this.txtImage.TabIndex = 28;
			this.txtImage.DoubleClick += new System.EventHandler(this.txtImage_DoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(88, 529);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 38);
			this.label1.TabIndex = 27;
			this.label1.Text = "Image:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(369, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(394, 59);
			this.label2.TabIndex = 1;
			this.label2.Text = "Bike Universe";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(-1, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1120, 146);
			this.panel1.TabIndex = 2;
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(241, 341);
			this.txtPrice.Multiline = true;
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(289, 50);
			this.txtPrice.TabIndex = 28;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(112, 341);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 38);
			this.label3.TabIndex = 27;
			this.label3.Text = "Price:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(112, 432);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(122, 38);
			this.label4.TabIndex = 29;
			this.label4.Text = "Stock:";
			// 
			// txtStock
			// 
			this.txtStock.Location = new System.Drawing.Point(241, 432);
			this.txtStock.Multiline = true;
			this.txtStock.Name = "txtStock";
			this.txtStock.Size = new System.Drawing.Size(289, 50);
			this.txtStock.TabIndex = 30;
			// 
			// pbNewBike
			// 
			this.pbNewBike.Location = new System.Drawing.Point(629, 167);
			this.pbNewBike.Name = "pbNewBike";
			this.pbNewBike.Size = new System.Drawing.Size(453, 424);
			this.pbNewBike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbNewBike.TabIndex = 31;
			this.pbNewBike.TabStop = false;
			// 
			// btnUpdate
			// 
			this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUpdate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.Location = new System.Drawing.Point(860, 613);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(243, 109);
			this.btnUpdate.TabIndex = 27;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = false;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(43, 187);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 38);
			this.label5.TabIndex = 27;
			this.label5.Text = "Bike:";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(171, 187);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(179, 38);
			this.lblName.TabIndex = 32;
			this.lblName.Text = "BikeName";
			// 
			// UpdateBikeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1117, 742);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.pbNewBike);
			this.Controls.Add(this.txtStock);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtImage);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "UpdateBikeForm";
			this.Text = "UpdateBikeForm";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbNewBike)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtImage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtStock;
		private System.Windows.Forms.PictureBox pbNewBike;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblName;
	}
}