namespace UniverseBikeHome
{
	partial class HomePage
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
			this.btnAddBike = new System.Windows.Forms.Button();
			this.btnRefreh = new System.Windows.Forms.Button();
			this.BikeContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
			this.panel1.Controls.Add(this.lblTitle);
			this.panel1.Location = new System.Drawing.Point(-2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1493, 134);
			this.panel1.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(590, 23);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(394, 59);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Bike Universe";
			// 
			// btnAddBike
			// 
			this.btnAddBike.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
			this.btnAddBike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddBike.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddBike.Location = new System.Drawing.Point(1223, 146);
			this.btnAddBike.Name = "btnAddBike";
			this.btnAddBike.Size = new System.Drawing.Size(243, 109);
			this.btnAddBike.TabIndex = 2;
			this.btnAddBike.Text = "Add new Bike";
			this.btnAddBike.UseVisualStyleBackColor = false;
			this.btnAddBike.Click += new System.EventHandler(this.btnAddBike_Click);
			// 
			// btnRefreh
			// 
			this.btnRefreh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
			this.btnRefreh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefreh.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRefreh.Location = new System.Drawing.Point(967, 147);
			this.btnRefreh.Name = "btnRefreh";
			this.btnRefreh.Size = new System.Drawing.Size(243, 109);
			this.btnRefreh.TabIndex = 3;
			this.btnRefreh.Text = "Refresh";
			this.btnRefreh.UseVisualStyleBackColor = false;
			this.btnRefreh.Click += new System.EventHandler(this.btnRefreh_Click);
			// 
			// BikeContainer
			// 
			this.BikeContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
			this.BikeContainer.Location = new System.Drawing.Point(-2, 266);
			this.BikeContainer.Name = "BikeContainer";
			this.BikeContainer.Size = new System.Drawing.Size(1477, 812);
			this.BikeContainer.TabIndex = 4;
			// 
			// btnNext
			// 
			this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNext.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNext.Location = new System.Drawing.Point(1320, 1093);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(146, 32);
			this.btnNext.TabIndex = 5;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = false;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
			this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrevious.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPrevious.Location = new System.Drawing.Point(1148, 1093);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(146, 32);
			this.btnPrevious.TabIndex = 6;
			this.btnPrevious.Text = "Previous";
			this.btnPrevious.UseVisualStyleBackColor = false;
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// HomePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1492, 1151);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.BikeContainer);
			this.Controls.Add(this.btnRefreh);
			this.Controls.Add(this.btnAddBike);
			this.Controls.Add(this.panel1);
			this.Name = "HomePage";
			this.Text = "Home Page";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnAddBike;
		private System.Windows.Forms.Button btnRefreh;
		private System.Windows.Forms.FlowLayoutPanel BikeContainer;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrevious;
	}
}

