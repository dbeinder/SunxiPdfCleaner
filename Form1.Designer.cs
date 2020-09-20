namespace SunxiPdfCleaner
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbRemoveJavascript = new System.Windows.Forms.CheckBox();
            this.cbReplaceText = new System.Windows.Forms.CheckBox();
            this.tbReplaceMatch = new System.Windows.Forms.TextBox();
            this.tbReplaceReplace = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cbRemoveXO = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWatermark = new System.Windows.Forms.TextBox();
            this.cbUncompressed = new System.Windows.Forms.CheckBox();
            this.tbSuffix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName});
            this.dataGridView1.Location = new System.Drawing.Point(16, 215);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(712, 324);
            this.dataGridView1.TabIndex = 1;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.HeaderText = "File Name";
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // cbRemoveJavascript
            // 
            this.cbRemoveJavascript.AutoSize = true;
            this.cbRemoveJavascript.Location = new System.Drawing.Point(19, 71);
            this.cbRemoveJavascript.Margin = new System.Windows.Forms.Padding(4);
            this.cbRemoveJavascript.Name = "cbRemoveJavascript";
            this.cbRemoveJavascript.Size = new System.Drawing.Size(152, 21);
            this.cbRemoveJavascript.TabIndex = 2;
            this.cbRemoveJavascript.Text = "Remove JavaScript";
            this.cbRemoveJavascript.UseVisualStyleBackColor = true;
            // 
            // cbReplaceText
            // 
            this.cbReplaceText.AutoSize = true;
            this.cbReplaceText.Checked = true;
            this.cbReplaceText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReplaceText.Location = new System.Drawing.Point(19, 100);
            this.cbReplaceText.Margin = new System.Windows.Forms.Padding(4);
            this.cbReplaceText.Name = "cbReplaceText";
            this.cbReplaceText.Size = new System.Drawing.Size(117, 21);
            this.cbReplaceText.TabIndex = 3;
            this.cbReplaceText.Text = "Replace Text:";
            this.cbReplaceText.UseVisualStyleBackColor = true;
            this.cbReplaceText.CheckedChanged += new System.EventHandler(this.cbReplaceText_CheckedChanged);
            // 
            // tbReplaceMatch
            // 
            this.tbReplaceMatch.Location = new System.Drawing.Point(147, 97);
            this.tbReplaceMatch.Margin = new System.Windows.Forms.Padding(4);
            this.tbReplaceMatch.Name = "tbReplaceMatch";
            this.tbReplaceMatch.Size = new System.Drawing.Size(365, 22);
            this.tbReplaceMatch.TabIndex = 4;
            this.tbReplaceMatch.Text = "nulleasitek";
            // 
            // tbReplaceReplace
            // 
            this.tbReplaceReplace.Location = new System.Drawing.Point(147, 126);
            this.tbReplaceReplace.Margin = new System.Windows.Forms.Padding(4);
            this.tbReplaceReplace.Name = "tbReplaceReplace";
            this.tbReplaceReplace.Size = new System.Drawing.Size(365, 22);
            this.tbReplaceReplace.TabIndex = 5;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(564, 180);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(164, 28);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "Process Files";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "File or Folder:";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(119, 15);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(570, 22);
            this.tbPath.TabIndex = 10;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(697, 12);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(33, 28);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cbRemoveXO
            // 
            this.cbRemoveXO.AutoSize = true;
            this.cbRemoveXO.Checked = true;
            this.cbRemoveXO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemoveXO.Location = new System.Drawing.Point(19, 158);
            this.cbRemoveXO.Margin = new System.Windows.Forms.Padding(4);
            this.cbRemoveXO.Name = "cbRemoveXO";
            this.cbRemoveXO.Size = new System.Drawing.Size(216, 21);
            this.cbRemoveXO.TabIndex = 14;
            this.cbRemoveXO.Text = "Remove XObjects containing:";
            this.cbRemoveXO.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "with:";
            // 
            // tbWatermark
            // 
            this.tbWatermark.Location = new System.Drawing.Point(243, 158);
            this.tbWatermark.Margin = new System.Windows.Forms.Padding(4);
            this.tbWatermark.Name = "tbWatermark";
            this.tbWatermark.Size = new System.Drawing.Size(269, 22);
            this.tbWatermark.TabIndex = 16;
            this.tbWatermark.Text = "Confidential";
            // 
            // cbUncompressed
            // 
            this.cbUncompressed.AutoSize = true;
            this.cbUncompressed.Location = new System.Drawing.Point(19, 187);
            this.cbUncompressed.Margin = new System.Windows.Forms.Padding(4);
            this.cbUncompressed.Name = "cbUncompressed";
            this.cbUncompressed.Size = new System.Drawing.Size(201, 21);
            this.cbUncompressed.TabIndex = 17;
            this.cbUncompressed.Text = "Output uncompressed PDF";
            this.cbUncompressed.UseVisualStyleBackColor = true;
            // 
            // tbSuffix
            // 
            this.tbSuffix.Location = new System.Drawing.Point(119, 43);
            this.tbSuffix.Margin = new System.Windows.Forms.Padding(4);
            this.tbSuffix.Name = "tbSuffix";
            this.tbSuffix.Size = new System.Drawing.Size(243, 22);
            this.tbSuffix.TabIndex = 19;
            this.tbSuffix.Text = "_cleaned.pdf";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Output suffix:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(578, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Progress:";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(611, 97);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(12, 17);
            this.lblProgress.TabIndex = 21;
            this.lblProgress.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 554);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSuffix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbUncompressed);
            this.Controls.Add(this.tbWatermark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRemoveXO);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.tbReplaceReplace);
            this.Controls.Add(this.tbReplaceMatch);
            this.Controls.Add(this.cbReplaceText);
            this.Controls.Add(this.cbRemoveJavascript);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Sunxi PDF Cleaner v0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbRemoveJavascript;
        private System.Windows.Forms.CheckBox cbReplaceText;
        private System.Windows.Forms.TextBox tbReplaceMatch;
        private System.Windows.Forms.TextBox tbReplaceReplace;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.CheckBox cbRemoveXO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWatermark;
        private System.Windows.Forms.CheckBox cbUncompressed;
        private System.Windows.Forms.TextBox tbSuffix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProgress;
    }
}

