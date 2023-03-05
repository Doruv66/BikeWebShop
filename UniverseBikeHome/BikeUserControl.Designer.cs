namespace UniverseBikeHome
{
	partial class BikeUserControl
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
			this.pbBike = new System.Windows.Forms.PictureBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.lblPrice = new System.Windows.Forms.Label();
			this.lblBrand = new System.Windows.Forms.Label();
			this.lblStock = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblB = new System.Windows.Forms.Label();
			this.lblP = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbBike)).BeginInit();
			this.SuspendLayout();
			// 
			// pbBike
			// 
			this.pbBike.Location = new System.Drawing.Point(29, 13);
			this.pbBike.Name = "pbBike";
			this.pbBike.Size = new System.Drawing.Size(423, 239);
			this.pbBike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbBike.TabIndex = 0;
			this.pbBike.TabStop = false;
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Verdana", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.Location = new System.Drawing.Point(338, 260);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(126, 72);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUpdate.Font = new System.Drawing.Font("Verdana", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.Location = new System.Drawing.Point(197, 260);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(135, 72);
			this.btnUpdate.TabIndex = 6;
			this.btnUpdate.Text = "update";
			this.btnUpdate.UseVisualStyleBackColor = false;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// lblPrice
			// 
			this.lblPrice.AutoSize = true;
			this.lblPrice.Location = new System.Drawing.Point(101, 282);
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.Size = new System.Drawing.Size(70, 25);
			this.lblPrice.TabIndex = 7;
			this.lblPrice.Text = "label1";
			// 
			// lblBrand
			// 
			this.lblBrand.AutoSize = true;
			this.lblBrand.Location = new System.Drawing.Point(101, 257);
			this.lblBrand.Name = "lblBrand";
			this.lblBrand.Size = new System.Drawing.Size(70, 25);
			this.lblBrand.TabIndex = 8;
			this.lblBrand.Text = "label2";
			// 
			// lblStock
			// 
			this.lblStock.AutoSize = true;
			this.lblStock.Location = new System.Drawing.Point(101, 307);
			this.lblStock.Name = "lblStock";
			this.lblStock.Size = new System.Drawing.Size(70, 25);
			this.lblStock.TabIndex = 9;
			this.lblStock.Text = "label2";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 307);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 25);
			this.label2.TabIndex = 12;
			this.label2.Text = "Stock:";
			// 
			// lblB
			// 
			this.lblB.AutoSize = true;
			this.lblB.Location = new System.Drawing.Point(5, 255);
			this.lblB.Name = "lblB";
			this.lblB.Size = new System.Drawing.Size(75, 25);
			this.lblB.TabIndex = 11;
			this.lblB.Text = "Brand:";
			// 
			// lblP
			// 
			this.lblP.AutoSize = true;
			this.lblP.Location = new System.Drawing.Point(5, 282);
			this.lblP.Name = "lblP";
			this.lblP.Size = new System.Drawing.Size(67, 25);
			this.lblP.TabIndex = 10;
			this.lblP.Text = "Price:";
			// 
			// BikeUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblB);
			this.Controls.Add(this.lblP);
			this.Controls.Add(this.lblStock);
			this.Controls.Add(this.lblBrand);
			this.Controls.Add(this.lblPrice);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.pbBike);
			this.ForeColor = System.Drawing.Color.Black;
			this.Name = "BikeUserControl";
			this.Size = new System.Drawing.Size(477, 346);
			this.Load += new System.EventHandler(this.BikeUserControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbBike)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pbBike;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Label lblPrice;
		private System.Windows.Forms.Label lblBrand;
		private System.Windows.Forms.Label lblStock;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblB;
		private System.Windows.Forms.Label lblP;
	}
}
