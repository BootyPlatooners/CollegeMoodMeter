namespace RatchetMeter
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
            this.buttonGenerateCode = new System.Windows.Forms.Button();
            this.checkBoxSp13 = new System.Windows.Forms.CheckBox();
            this.checkBoxAu13 = new System.Windows.Forms.CheckBox();
            this.checkBoxSp14 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonGenerateCode
            // 
            this.buttonGenerateCode.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGenerateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonGenerateCode.Location = new System.Drawing.Point(27, 241);
            this.buttonGenerateCode.Name = "buttonGenerateCode";
            this.buttonGenerateCode.Size = new System.Drawing.Size(229, 36);
            this.buttonGenerateCode.TabIndex = 0;
            this.buttonGenerateCode.Text = "Generate Analysis";
            this.buttonGenerateCode.UseVisualStyleBackColor = false;
            this.buttonGenerateCode.Click += new System.EventHandler(this.buttonGenerateCode_Click);
            // 
            // checkBoxSp13
            // 
            this.checkBoxSp13.AutoSize = true;
            this.checkBoxSp13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSp13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.checkBoxSp13.Location = new System.Drawing.Point(36, 94);
            this.checkBoxSp13.Name = "checkBoxSp13";
            this.checkBoxSp13.Size = new System.Drawing.Size(134, 29);
            this.checkBoxSp13.TabIndex = 1;
            this.checkBoxSp13.Text = "Spring 2013";
            this.checkBoxSp13.UseVisualStyleBackColor = true;
            // 
            // checkBoxAu13
            // 
            this.checkBoxAu13.AutoSize = true;
            this.checkBoxAu13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAu13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.checkBoxAu13.Location = new System.Drawing.Point(36, 144);
            this.checkBoxAu13.Name = "checkBoxAu13";
            this.checkBoxAu13.Size = new System.Drawing.Size(139, 29);
            this.checkBoxAu13.TabIndex = 2;
            this.checkBoxAu13.Text = "August 2013";
            this.checkBoxAu13.UseVisualStyleBackColor = true;
            // 
            // checkBoxSp14
            // 
            this.checkBoxSp14.AutoSize = true;
            this.checkBoxSp14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSp14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.checkBoxSp14.Location = new System.Drawing.Point(36, 192);
            this.checkBoxSp14.Name = "checkBoxSp14";
            this.checkBoxSp14.Size = new System.Drawing.Size(134, 29);
            this.checkBoxSp14.TabIndex = 3;
            this.checkBoxSp14.Text = "Spring 2014";
            this.checkBoxSp14.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(280, 295);
            this.Controls.Add(this.checkBoxSp14);
            this.Controls.Add(this.checkBoxAu13);
            this.Controls.Add(this.checkBoxSp13);
            this.Controls.Add(this.buttonGenerateCode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateCode;
        private System.Windows.Forms.CheckBox checkBoxSp13;
        private System.Windows.Forms.CheckBox checkBoxAu13;
        private System.Windows.Forms.CheckBox checkBoxSp14;
    }
}

