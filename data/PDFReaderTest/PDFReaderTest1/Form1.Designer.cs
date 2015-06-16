namespace PDFReaderTest1
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
            this.txtPdfFile = new System.Windows.Forms.TextBox();
            this.rTxtRef = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetRef = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rTxtAllRefs = new System.Windows.Forms.RichTextBox();
            this.ofdPDF = new System.Windows.Forms.OpenFileDialog();
            this.rTxtSplitRef = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPdfFile
            // 
            this.txtPdfFile.Location = new System.Drawing.Point(161, 43);
            this.txtPdfFile.Name = "txtPdfFile";
            this.txtPdfFile.Size = new System.Drawing.Size(473, 20);
            this.txtPdfFile.TabIndex = 0;
            // 
            // rTxtRef
            // 
            this.rTxtRef.Location = new System.Drawing.Point(161, 69);
            this.rTxtRef.Name = "rTxtRef";
            this.rTxtRef.Size = new System.Drawing.Size(473, 202);
            this.rTxtRef.TabIndex = 1;
            this.rTxtRef.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pdf File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Actual Refs";
            // 
            // btnGetRef
            // 
            this.btnGetRef.Location = new System.Drawing.Point(161, 572);
            this.btnGetRef.Name = "btnGetRef";
            this.btnGetRef.Size = new System.Drawing.Size(75, 23);
            this.btnGetRef.TabIndex = 4;
            this.btnGetRef.Text = "Get Ref";
            this.btnGetRef.UseVisualStyleBackColor = true;
            this.btnGetRef.Click += new System.EventHandler(this.btnGetRef_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Matched Refs";
            // 
            // rTxtAllRefs
            // 
            this.rTxtAllRefs.Location = new System.Drawing.Point(161, 277);
            this.rTxtAllRefs.Name = "rTxtAllRefs";
            this.rTxtAllRefs.Size = new System.Drawing.Size(473, 207);
            this.rTxtAllRefs.TabIndex = 5;
            this.rTxtAllRefs.Text = "";
            // 
            // rTxtSplitRef
            // 
            this.rTxtSplitRef.Location = new System.Drawing.Point(161, 490);
            this.rTxtSplitRef.Name = "rTxtSplitRef";
            this.rTxtSplitRef.Size = new System.Drawing.Size(473, 59);
            this.rTxtSplitRef.TabIndex = 7;
            this.rTxtSplitRef.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 504);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Splitted Ref";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 631);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rTxtSplitRef);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rTxtAllRefs);
            this.Controls.Add(this.btnGetRef);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rTxtRef);
            this.Controls.Add(this.txtPdfFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPdfFile;
        private System.Windows.Forms.RichTextBox rTxtRef;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetRef;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rTxtAllRefs;
        private System.Windows.Forms.OpenFileDialog ofdPDF;
        private System.Windows.Forms.RichTextBox rTxtSplitRef;
        private System.Windows.Forms.Label label4;
    }
}

