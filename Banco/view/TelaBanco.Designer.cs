namespace Banco
{
    partial class TelaBanco
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(197, 26);
            label1.Name = "label1";
            label1.Size = new Size(98, 31);
            label1.TabIndex = 0;
            label1.Text = "Banco ";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(63, 137);
            button1.Name = "button1";
            button1.Size = new Size(166, 35);
            button1.TabIndex = 1;
            button1.Text = "Gerenciar Clientes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(63, 200);
            button2.Name = "button2";
            button2.Size = new Size(166, 35);
            button2.TabIndex = 2;
            button2.Text = "Gerenciar Contas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(63, 263);
            button3.Name = "button3";
            button3.Size = new Size(166, 35);
            button3.TabIndex = 3;
            button3.Text = "Gerenciar Transacoes";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(266, 137);
            button4.Name = "button4";
            button4.Size = new Size(166, 35);
            button4.TabIndex = 4;
            button4.Text = "Listar Clientes";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(461, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(338, 449);
            dataGridView1.TabIndex = 5;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(266, 200);
            button5.Name = "button5";
            button5.Size = new Size(166, 35);
            button5.TabIndex = 6;
            button5.Text = "Listar Contas";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(266, 263);
            button6.Name = "button6";
            button6.Size = new Size(166, 35);
            button6.TabIndex = 7;
            button6.Text = "Listar Transações";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // TelaBanco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "TelaBanco";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private Button button5;
        private Button button6;
    }
}
