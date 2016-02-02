namespace CryptLab4PANAMA
{
    partial class MainForm
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
            this.button1encode = new System.Windows.Forms.Button();
            this.textBox1key = new System.Windows.Forms.TextBox();
            this.button1decode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1param = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1hash = new System.Windows.Forms.Button();
            this.textBox1hash = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1encode
            // 
            this.button1encode.Location = new System.Drawing.Point(43, 144);
            this.button1encode.Margin = new System.Windows.Forms.Padding(4);
            this.button1encode.Name = "button1encode";
            this.button1encode.Size = new System.Drawing.Size(100, 28);
            this.button1encode.TabIndex = 0;
            this.button1encode.Text = "Encrypt";
            this.button1encode.UseVisualStyleBackColor = true;
            this.button1encode.Click += new System.EventHandler(this.button1encode_Click);
            // 
            // textBox1key
            // 
            this.textBox1key.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBox1key.Location = new System.Drawing.Point(43, 45);
            this.textBox1key.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1key.Name = "textBox1key";
            this.textBox1key.Size = new System.Drawing.Size(355, 24);
            this.textBox1key.TabIndex = 1;
            // 
            // button1decode
            // 
            this.button1decode.Location = new System.Drawing.Point(151, 144);
            this.button1decode.Margin = new System.Windows.Forms.Padding(4);
            this.button1decode.Name = "button1decode";
            this.button1decode.Size = new System.Drawing.Size(100, 28);
            this.button1decode.TabIndex = 2;
            this.button1decode.Text = "Decrypt";
            this.button1decode.UseVisualStyleBackColor = true;
            this.button1decode.Click += new System.EventHandler(this.button1encode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Key:";
            // 
            // textBox1param
            // 
            this.textBox1param.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBox1param.Location = new System.Drawing.Point(43, 98);
            this.textBox1param.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1param.Name = "textBox1param";
            this.textBox1param.Size = new System.Drawing.Size(355, 24);
            this.textBox1param.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parameter:";
            // 
            // button1hash
            // 
            this.button1hash.Location = new System.Drawing.Point(43, 264);
            this.button1hash.Margin = new System.Windows.Forms.Padding(4);
            this.button1hash.Name = "button1hash";
            this.button1hash.Size = new System.Drawing.Size(100, 28);
            this.button1hash.TabIndex = 6;
            this.button1hash.Text = "Hash";
            this.button1hash.UseVisualStyleBackColor = true;
            this.button1hash.Click += new System.EventHandler(this.button1hash_Click);
            // 
            // textBox1hash
            // 
            this.textBox1hash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBox1hash.Location = new System.Drawing.Point(43, 223);
            this.textBox1hash.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1hash.Name = "textBox1hash";
            this.textBox1hash.ReadOnly = true;
            this.textBox1hash.Size = new System.Drawing.Size(355, 24);
            this.textBox1hash.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hash:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 307);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1hash);
            this.Controls.Add(this.button1hash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1param);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1decode);
            this.Controls.Add(this.textBox1key);
            this.Controls.Add(this.button1encode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panama";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1encode;
        private System.Windows.Forms.TextBox textBox1key;
        private System.Windows.Forms.Button button1decode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1param;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1hash;
        private System.Windows.Forms.TextBox textBox1hash;
        private System.Windows.Forms.Label label3;
    }
}

