namespace OLA_Lab7_Semantica
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TestProgCode = new System.Windows.Forms.Button();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TestProgCode
            // 
            this.TestProgCode.Location = new System.Drawing.Point(12, 272);
            this.TestProgCode.Name = "TestProgCode";
            this.TestProgCode.Size = new System.Drawing.Size(752, 61);
            this.TestProgCode.TabIndex = 0;
            this.TestProgCode.Text = "Проверить код программы";
            this.TestProgCode.UseVisualStyleBackColor = true;
            this.TestProgCode.Click += new System.EventHandler(this.TestProgCode_Click);
            // 
            // RTB
            // 
            this.RTB.Location = new System.Drawing.Point(12, 12);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(752, 254);
            this.RTB.TabIndex = 1;
            this.RTB.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 345);
            this.Controls.Add(this.RTB);
            this.Controls.Add(this.TestProgCode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TestProgCode;
        private System.Windows.Forms.RichTextBox RTB;
    }
}

