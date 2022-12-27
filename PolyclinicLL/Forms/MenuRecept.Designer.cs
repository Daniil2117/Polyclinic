﻿namespace PolyclinicLL.Forms
{
    partial class MenuRecept
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonViewReception = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonDepart = new System.Windows.Forms.Button();
            this.buttonViewPatient = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(150)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.pictureIcon);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 114);
            this.panel1.TabIndex = 4;
            // 
            // pictureIcon
            // 
            this.pictureIcon.Image = global::PolyclinicLL.Properties.Resources.icons;
            this.pictureIcon.Location = new System.Drawing.Point(13, 13);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(153, 94);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureIcon.TabIndex = 1;
            this.pictureIcon.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Comic Sans MS", 22F);
            this.labelTitle.Location = new System.Drawing.Point(297, 34);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(450, 42);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Поликлиника \"Линия Жизни\"";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(150)))), ((int)(((byte)(235)))));
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelTime);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 508);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 50);
            this.panel2.TabIndex = 13;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.labelDate.Location = new System.Drawing.Point(601, 15);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(56, 26);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(528, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Дата:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.labelTime.Location = new System.Drawing.Point(164, 15);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(68, 26);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "Время";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(4, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 29);
            this.label5.TabIndex = 3;
            this.label5.Text = "Время по МСК:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.label1.Location = new System.Drawing.Point(35, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 38);
            this.label1.TabIndex = 16;
            this.label1.Text = "Сотрудник регистратуры, ";
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.labelFIO.Location = new System.Drawing.Point(373, 135);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(76, 38);
            this.labelFIO.TabIndex = 17;
            this.labelFIO.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.label2.Location = new System.Drawing.Point(223, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 33);
            this.label2.TabIndex = 18;
            this.label2.Text = "Добро пожаловать в систему!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.label3.Location = new System.Drawing.Point(633, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 33);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ваше Фото";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(584, 291);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // buttonViewReception
            // 
            this.buttonViewReception.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.buttonViewReception.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonViewReception.Location = new System.Drawing.Point(20, 253);
            this.buttonViewReception.Name = "buttonViewReception";
            this.buttonViewReception.Size = new System.Drawing.Size(227, 74);
            this.buttonViewReception.TabIndex = 22;
            this.buttonViewReception.Text = "Просмотреть приёмы";
            this.buttonViewReception.UseVisualStyleBackColor = false;
            this.buttonViewReception.Click += new System.EventHandler(this.buttonViewReception_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.buttonBack.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(20, 442);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(147, 51);
            this.buttonBack.TabIndex = 24;
            this.buttonBack.Text = "Выйти";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonDepart
            // 
            this.buttonDepart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.buttonDepart.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDepart.Location = new System.Drawing.Point(151, 345);
            this.buttonDepart.Name = "buttonDepart";
            this.buttonDepart.Size = new System.Drawing.Size(225, 69);
            this.buttonDepart.TabIndex = 25;
            this.buttonDepart.Text = "Просмотреть отделения";
            this.buttonDepart.UseVisualStyleBackColor = false;
            this.buttonDepart.Click += new System.EventHandler(this.buttonDepart_Click);
            // 
            // buttonViewPatient
            // 
            this.buttonViewPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.buttonViewPatient.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonViewPatient.Location = new System.Drawing.Point(279, 258);
            this.buttonViewPatient.Name = "buttonViewPatient";
            this.buttonViewPatient.Size = new System.Drawing.Size(227, 69);
            this.buttonViewPatient.TabIndex = 26;
            this.buttonViewPatient.Text = "Посмотреть пациентов";
            this.buttonViewPatient.UseVisualStyleBackColor = false;
            this.buttonViewPatient.Click += new System.EventHandler(this.buttonViewPatient_Click);
            // 
            // MenuRecept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 557);
            this.Controls.Add(this.buttonViewPatient);
            this.Controls.Add(this.buttonDepart);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonViewReception);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuRecept";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuRecept";
            this.Load += new System.EventHandler(this.MenuRecept_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureIcon;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonViewReception;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonDepart;
        private System.Windows.Forms.Button buttonViewPatient;
    }
}