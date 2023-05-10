namespace UniverseBikeHome
{
    partial class ReturnUserControl
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
            this.lblComment = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblBike = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(153, 91);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(70, 25);
            this.lblComment.TabIndex = 36;
            this.lblComment.Text = "label1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 25);
            this.label8.TabIndex = 35;
            this.label8.Text = "Comment:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 34;
            this.label1.Text = "Reason:";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(684, 22);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(70, 25);
            this.lblReason.TabIndex = 32;
            this.lblReason.Text = "label2";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(12, 22);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(60, 25);
            this.lblB.TabIndex = 30;
            this.lblB.Text = "Bike:";
            // 
            // lblBike
            // 
            this.lblBike.AutoSize = true;
            this.lblBike.Location = new System.Drawing.Point(144, 22);
            this.lblBike.Name = "lblBike";
            this.lblBike.Size = new System.Drawing.Size(70, 25);
            this.lblBike.TabIndex = 28;
            this.lblBike.Text = "label2";
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Location = new System.Drawing.Point(1022, 91);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(222, 50);
            this.btnApprove.TabIndex = 37;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // ReturnUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblBike);
            this.Name = "ReturnUserControl";
            this.Size = new System.Drawing.Size(1340, 162);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblBike;
        private System.Windows.Forms.Button btnApprove;
    }
}
