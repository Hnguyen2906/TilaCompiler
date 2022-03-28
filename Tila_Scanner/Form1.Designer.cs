
namespace Tila_Scanner
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OutputTxt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SyntaxBtn = new System.Windows.Forms.Button();
            this.TokenConvertBtn = new System.Windows.Forms.Button();
            this.InputTxt = new System.Windows.Forms.TextBox();
            this.Inputlbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.OutputTxt);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 262);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 188);
            this.panel3.TabIndex = 3;
            // 
            // OutputTxt
            // 
            this.OutputTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTxt.Location = new System.Drawing.Point(0, 0);
            this.OutputTxt.Multiline = true;
            this.OutputTxt.Name = "OutputTxt";
            this.OutputTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTxt.Size = new System.Drawing.Size(800, 188);
            this.OutputTxt.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SyntaxBtn);
            this.panel2.Controls.Add(this.TokenConvertBtn);
            this.panel2.Controls.Add(this.InputTxt);
            this.panel2.Controls.Add(this.Inputlbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 256);
            this.panel2.TabIndex = 2;
            // 
            // SyntaxBtn
            // 
            this.SyntaxBtn.Location = new System.Drawing.Point(652, 66);
            this.SyntaxBtn.Name = "SyntaxBtn";
            this.SyntaxBtn.Size = new System.Drawing.Size(100, 23);
            this.SyntaxBtn.TabIndex = 3;
            this.SyntaxBtn.Text = "SyntaxAnalysis";
            this.SyntaxBtn.UseVisualStyleBackColor = true;
            this.SyntaxBtn.Click += new System.EventHandler(this.SyntaxBtn_Click);
            // 
            // TokenConvertBtn
            // 
            this.TokenConvertBtn.Location = new System.Drawing.Point(652, 21);
            this.TokenConvertBtn.Name = "TokenConvertBtn";
            this.TokenConvertBtn.Size = new System.Drawing.Size(100, 23);
            this.TokenConvertBtn.TabIndex = 2;
            this.TokenConvertBtn.Text = "ConvertToTokens";
            this.TokenConvertBtn.UseVisualStyleBackColor = true;
            this.TokenConvertBtn.Click += new System.EventHandler(this.TokenConvertBtn_Click);
            // 
            // InputTxt
            // 
            this.InputTxt.Location = new System.Drawing.Point(206, 21);
            this.InputTxt.Multiline = true;
            this.InputTxt.Name = "InputTxt";
            this.InputTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.InputTxt.Size = new System.Drawing.Size(404, 181);
            this.InputTxt.TabIndex = 1;
            // 
            // Inputlbl
            // 
            this.Inputlbl.AutoSize = true;
            this.Inputlbl.Location = new System.Drawing.Point(82, 24);
            this.Inputlbl.Name = "Inputlbl";
            this.Inputlbl.Size = new System.Drawing.Size(31, 13);
            this.Inputlbl.TabIndex = 0;
            this.Inputlbl.Text = "Input";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "TilaCompiler";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Inputlbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox InputTxt;
        private System.Windows.Forms.Button TokenConvertBtn;
        private System.Windows.Forms.TextBox OutputTxt;
        private System.Windows.Forms.Button SyntaxBtn;
    }
}

