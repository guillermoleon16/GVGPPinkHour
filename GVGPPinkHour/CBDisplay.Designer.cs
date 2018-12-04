namespace GVGPPinkHour
{
    partial class CBDisplay
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.StateImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CaseList = new System.Windows.Forms.ListBox();
            this.ActionList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StateImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.StateImage);
            this.splitContainer1.Size = new System.Drawing.Size(484, 261);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 0;
            // 
            // StateImage
            // 
            this.StateImage.Location = new System.Drawing.Point(3, 3);
            this.StateImage.Name = "StateImage";
            this.StateImage.Size = new System.Drawing.Size(313, 255);
            this.StateImage.TabIndex = 0;
            this.StateImage.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CaseList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ActionList, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(155, 255);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CaseList
            // 
            this.CaseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaseList.FormattingEnabled = true;
            this.CaseList.Location = new System.Drawing.Point(3, 3);
            this.CaseList.Name = "CaseList";
            this.CaseList.Size = new System.Drawing.Size(149, 121);
            this.CaseList.TabIndex = 0;
            this.CaseList.SelectedIndexChanged += new System.EventHandler(this.CaseList_SelectedIndexChanged);
            // 
            // ActionList
            // 
            this.ActionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionList.FormattingEnabled = true;
            this.ActionList.Location = new System.Drawing.Point(3, 130);
            this.ActionList.Name = "ActionList";
            this.ActionList.Size = new System.Drawing.Size(149, 122);
            this.ActionList.TabIndex = 1;
            // 
            // CBDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CBDisplay";
            this.Text = "CBDisplay";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StateImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox CaseList;
        private System.Windows.Forms.PictureBox StateImage;
        private System.Windows.Forms.ListBox ActionList;
    }
}