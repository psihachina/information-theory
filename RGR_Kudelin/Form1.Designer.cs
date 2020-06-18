namespace RGR_Kudelin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HaffmanGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InputMessage = new System.Windows.Forms.TextBox();
            this.Avg = new System.Windows.Forms.Label();
            this.Entropy = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.EncodedMessage = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BinaryString = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.HamGrid = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ASCIIGrid = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CRCBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.DecodeBtn = new System.Windows.Forms.Button();
            this.EncodeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.InputMessage2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HaffmanGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HamGrid)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ASCIIGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 597);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Haffman";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.HaffmanGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 465);
            this.panel2.TabIndex = 5;
            // 
            // HaffmanGrid
            // 
            this.HaffmanGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.HaffmanGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.HaffmanGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HaffmanGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HaffmanGrid.Location = new System.Drawing.Point(0, 0);
            this.HaffmanGrid.Name = "HaffmanGrid";
            this.HaffmanGrid.Size = new System.Drawing.Size(786, 465);
            this.HaffmanGrid.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InputMessage);
            this.panel1.Controls.Add(this.Avg);
            this.panel1.Controls.Add(this.Entropy);
            this.panel1.Controls.Add(this.StartBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 100);
            this.panel1.TabIndex = 4;
            // 
            // InputMessage
            // 
            this.InputMessage.Location = new System.Drawing.Point(5, 3);
            this.InputMessage.Multiline = true;
            this.InputMessage.Name = "InputMessage";
            this.InputMessage.Size = new System.Drawing.Size(649, 62);
            this.InputMessage.TabIndex = 1;
            // 
            // Avg
            // 
            this.Avg.AutoSize = true;
            this.Avg.Location = new System.Drawing.Point(121, 77);
            this.Avg.Name = "Avg";
            this.Avg.Size = new System.Drawing.Size(90, 13);
            this.Avg.TabIndex = 3;
            this.Avg.Text = "Avg bit/character";
            // 
            // Entropy
            // 
            this.Entropy.AutoSize = true;
            this.Entropy.Location = new System.Drawing.Point(5, 77);
            this.Entropy.Name = "Entropy";
            this.Entropy.Size = new System.Drawing.Size(43, 13);
            this.Entropy.TabIndex = 3;
            this.Entropy.Text = "Entropy";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(661, 3);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(122, 62);
            this.StartBtn.TabIndex = 2;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel11);
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 571);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hemming";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.EncodedMessage);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(349, 332);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(440, 236);
            this.panel11.TabIndex = 14;
            // 
            // EncodedMessage
            // 
            this.EncodedMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EncodedMessage.Location = new System.Drawing.Point(0, 0);
            this.EncodedMessage.Multiline = true;
            this.EncodedMessage.Name = "EncodedMessage";
            this.EncodedMessage.Size = new System.Drawing.Size(440, 236);
            this.EncodedMessage.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(349, 312);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(440, 20);
            this.panel8.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Encoded message";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.BinaryString);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(349, 100);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(440, 212);
            this.panel7.TabIndex = 10;
            // 
            // BinaryString
            // 
            this.BinaryString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BinaryString.Location = new System.Drawing.Point(0, 0);
            this.BinaryString.Multiline = true;
            this.BinaryString.Name = "BinaryString";
            this.BinaryString.Size = new System.Drawing.Size(440, 212);
            this.BinaryString.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.HamGrid);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(168, 100);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(181, 468);
            this.panel6.TabIndex = 8;
            // 
            // HamGrid
            // 
            this.HamGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.HamGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.HamGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HamGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HamGrid.Location = new System.Drawing.Point(0, 0);
            this.HamGrid.Name = "HamGrid";
            this.HamGrid.Size = new System.Drawing.Size(181, 468);
            this.HamGrid.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.ASCIIGrid);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(165, 468);
            this.panel4.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(171, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 212);
            this.panel5.TabIndex = 8;
            // 
            // ASCIIGrid
            // 
            this.ASCIIGrid.AllowUserToAddRows = false;
            this.ASCIIGrid.AllowUserToDeleteRows = false;
            this.ASCIIGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ASCIIGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.ASCIIGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ASCIIGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ASCIIGrid.Location = new System.Drawing.Point(0, 0);
            this.ASCIIGrid.Name = "ASCIIGrid";
            this.ASCIIGrid.ReadOnly = true;
            this.ASCIIGrid.ShowCellErrors = false;
            this.ASCIIGrid.ShowCellToolTips = false;
            this.ASCIIGrid.ShowEditingIcon = false;
            this.ASCIIGrid.ShowRowErrors = false;
            this.ASCIIGrid.Size = new System.Drawing.Size(165, 468);
            this.ASCIIGrid.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.CRCBtn);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.DecodeBtn);
            this.panel3.Controls.Add(this.EncodeBtn);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.InputMessage2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 97);
            this.panel3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hamming code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Binary code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(352, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Binary string";
            // 
            // CRCBtn
            // 
            this.CRCBtn.Location = new System.Drawing.Point(271, 54);
            this.CRCBtn.Name = "CRCBtn";
            this.CRCBtn.Size = new System.Drawing.Size(75, 23);
            this.CRCBtn.TabIndex = 5;
            this.CRCBtn.Text = "CRC";
            this.CRCBtn.UseVisualStyleBackColor = true;
            this.CRCBtn.Click += new System.EventHandler(this.CRCBtn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(174, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Galleya code";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DecodeBtn
            // 
            this.DecodeBtn.Location = new System.Drawing.Point(90, 54);
            this.DecodeBtn.Name = "DecodeBtn";
            this.DecodeBtn.Size = new System.Drawing.Size(75, 23);
            this.DecodeBtn.TabIndex = 7;
            this.DecodeBtn.Text = "Decode";
            this.DecodeBtn.UseVisualStyleBackColor = true;
            this.DecodeBtn.Click += new System.EventHandler(this.DecodeBtn_Click);
            // 
            // EncodeBtn
            // 
            this.EncodeBtn.Location = new System.Drawing.Point(9, 54);
            this.EncodeBtn.Name = "EncodeBtn";
            this.EncodeBtn.Size = new System.Drawing.Size(75, 23);
            this.EncodeBtn.TabIndex = 8;
            this.EncodeBtn.Text = "Encode";
            this.EncodeBtn.UseVisualStyleBackColor = true;
            this.EncodeBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Message";
            // 
            // InputMessage2
            // 
            this.InputMessage2.Location = new System.Drawing.Point(6, 16);
            this.InputMessage2.Multiline = true;
            this.InputMessage2.Name = "InputMessage2";
            this.InputMessage2.Size = new System.Drawing.Size(772, 32);
            this.InputMessage2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 597);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HaffmanGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HamGrid)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ASCIIGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.TextBox InputMessage;
        private System.Windows.Forms.Label Entropy;
        private System.Windows.Forms.Label Avg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView HaffmanGrid;
        private System.Windows.Forms.TextBox BinaryString;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView ASCIIGrid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button CRCBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button DecodeBtn;
        private System.Windows.Forms.Button EncodeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InputMessage2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView HamGrid;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox EncodedMessage;
    }
}

