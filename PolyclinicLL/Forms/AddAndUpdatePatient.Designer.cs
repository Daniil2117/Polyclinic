namespace PolyclinicLL.Forms
{
    partial class AddAndUpdatePatient
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.dateBirthday = new System.Windows.Forms.DateTimePicker();
            this.textBoxNumPassport = new System.Windows.Forms.TextBox();
            this.textBoxSeriaPassport = new System.Windows.Forms.TextBox();
            this.labelTitleP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonAddRecPat = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(150)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.pictureIcon);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 114);
            this.panel1.TabIndex = 26;
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
            this.labelTitle.Location = new System.Drawing.Point(344, 34);
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
            this.panel2.Location = new System.Drawing.Point(0, 587);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 50);
            this.panel2.TabIndex = 27;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.labelDate.Location = new System.Drawing.Point(810, 15);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(56, 26);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(737, 15);
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.textBoxLastName.Location = new System.Drawing.Point(361, 191);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(311, 41);
            this.textBoxLastName.TabIndex = 28;
            this.textBoxLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLastName_KeyPress);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.textBoxName.Location = new System.Drawing.Point(361, 267);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(311, 41);
            this.textBoxName.TabIndex = 29;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.textBoxPatronymic.Location = new System.Drawing.Point(361, 336);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(311, 41);
            this.textBoxPatronymic.TabIndex = 30;
            this.textBoxPatronymic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPatronymic_KeyPress);
            // 
            // dateBirthday
            // 
            this.dateBirthday.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.dateBirthday.Location = new System.Drawing.Point(361, 405);
            this.dateBirthday.Name = "dateBirthday";
            this.dateBirthday.Size = new System.Drawing.Size(311, 41);
            this.dateBirthday.TabIndex = 35;
            // 
            // textBoxNumPassport
            // 
            this.textBoxNumPassport.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.textBoxNumPassport.Location = new System.Drawing.Point(480, 513);
            this.textBoxNumPassport.Name = "textBoxNumPassport";
            this.textBoxNumPassport.Size = new System.Drawing.Size(192, 41);
            this.textBoxNumPassport.TabIndex = 36;
            this.textBoxNumPassport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumPassport_KeyPress);
            // 
            // textBoxSeriaPassport
            // 
            this.textBoxSeriaPassport.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.textBoxSeriaPassport.Location = new System.Drawing.Point(361, 513);
            this.textBoxSeriaPassport.Name = "textBoxSeriaPassport";
            this.textBoxSeriaPassport.Size = new System.Drawing.Size(103, 41);
            this.textBoxSeriaPassport.TabIndex = 37;
            this.textBoxSeriaPassport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSeriaPassport_KeyPress);
            // 
            // labelTitleP
            // 
            this.labelTitleP.AutoSize = true;
            this.labelTitleP.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.labelTitleP.Location = new System.Drawing.Point(273, 128);
            this.labelTitleP.Name = "labelTitleP";
            this.labelTitleP.Size = new System.Drawing.Size(477, 38);
            this.labelTitleP.TabIndex = 38;
            this.labelTitleP.Text = "Изменение данных о пользователе";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.label1.Location = new System.Drawing.Point(209, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 33);
            this.label1.TabIndex = 39;
            this.label1.Text = "Фамилия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.label2.Location = new System.Drawing.Point(264, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 33);
            this.label2.TabIndex = 40;
            this.label2.Text = "Имя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.label3.Location = new System.Drawing.Point(207, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 33);
            this.label3.TabIndex = 41;
            this.label3.Text = "Отчество:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.label9.Location = new System.Drawing.Point(142, 413);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 33);
            this.label9.TabIndex = 42;
            this.label9.Text = "Дата рождения:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.label6.Location = new System.Drawing.Point(207, 516);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 33);
            this.label6.TabIndex = 43;
            this.label6.Text = "Паспорт:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.label7.Location = new System.Drawing.Point(372, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 33);
            this.label7.TabIndex = 44;
            this.label7.Text = "Серия";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.label8.Location = new System.Drawing.Point(520, 463);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 33);
            this.label8.TabIndex = 45;
            this.label8.Text = "Номер";
            // 
            // buttonAddRecPat
            // 
            this.buttonAddRecPat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.buttonAddRecPat.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddRecPat.Location = new System.Drawing.Point(742, 191);
            this.buttonAddRecPat.Name = "buttonAddRecPat";
            this.buttonAddRecPat.Size = new System.Drawing.Size(219, 63);
            this.buttonAddRecPat.TabIndex = 46;
            this.buttonAddRecPat.Text = "Добавить";
            this.buttonAddRecPat.UseVisualStyleBackColor = false;
            this.buttonAddRecPat.Click += new System.EventHandler(this.buttonAddRecPat_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.buttonUpdate.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdate.Location = new System.Drawing.Point(742, 285);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(219, 63);
            this.buttonUpdate.TabIndex = 47;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.buttonExit.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(742, 486);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(219, 63);
            this.buttonExit.TabIndex = 48;
            this.buttonExit.Text = "Назад";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // AddAndUpdatePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 635);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAddRecPat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitleP);
            this.Controls.Add(this.textBoxSeriaPassport);
            this.Controls.Add(this.textBoxNumPassport);
            this.Controls.Add(this.dateBirthday);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAndUpdatePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPatient";
            this.Load += new System.EventHandler(this.AddAndUpdatePatient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.DateTimePicker dateBirthday;
        private System.Windows.Forms.TextBox textBoxNumPassport;
        private System.Windows.Forms.TextBox textBoxSeriaPassport;
        private System.Windows.Forms.Label labelTitleP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonAddRecPat;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonExit;
    }
}