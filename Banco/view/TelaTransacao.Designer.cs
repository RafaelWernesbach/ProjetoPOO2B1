namespace Banco.view
{
    partial class TelaTransacao
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            textBox4 = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(66, 196);
            label5.Name = "label5";
            label5.Size = new Size(265, 15);
            label5.TabIndex = 17;
            label5.Text = "Tipo(deposito, saque, emprestimo, transferencia)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(577, 196);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 16;
            label4.Text = "Valor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(202, 139);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 15;
            label3.Text = "Numero da Origem";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(337, 193);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(461, 136);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(337, 136);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(577, 139);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 11;
            label2.Text = "Numero do Destinho";
            // 
            // button1
            // 
            button1.Location = new Point(410, 239);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Efetuar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(272, 26);
            label1.Name = "label1";
            label1.Size = new Size(300, 31);
            label1.TabIndex = 18;
            label1.Text = "Gerente De Transacoes";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(461, 193);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(398, 97);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 20;
            label6.Text = "Efetuar Transacao";
            // 
            // TelaTransacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Name = "TelaTransacao";
            Text = "TelaTransacao";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Button button1;
        private Label label1;
        private TextBox textBox4;
        private Label label6;
    }
}