
namespace ClassCreator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_mdc = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uc_mdc1 = new ClassCreator.MySQL_Dapper_CSharp.uc_mdc();
            this.tabControl1.SuspendLayout();
            this.tab_mdc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_mdc);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(930, 567);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_mdc
            // 
            this.tab_mdc.Controls.Add(this.uc_mdc1);
            this.tab_mdc.Location = new System.Drawing.Point(4, 24);
            this.tab_mdc.Name = "tab_mdc";
            this.tab_mdc.Padding = new System.Windows.Forms.Padding(3);
            this.tab_mdc.Size = new System.Drawing.Size(922, 539);
            this.tab_mdc.TabIndex = 0;
            this.tab_mdc.Text = "MySQL + Dapper + C#";
            this.tab_mdc.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(922, 539);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uc_mdc1
            // 
            this.uc_mdc1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc_mdc1.Location = new System.Drawing.Point(3, 3);
            this.uc_mdc1.Name = "uc_mdc1";
            this.uc_mdc1.Size = new System.Drawing.Size(913, 530);
            this.uc_mdc1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 591);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "ClassCreator";
            this.tabControl1.ResumeLayout(false);
            this.tab_mdc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_mdc;
        private System.Windows.Forms.TabPage tabPage2;
        private MySQL_Dapper_CSharp.uc_mdc uc_mdc1;
    }
}

