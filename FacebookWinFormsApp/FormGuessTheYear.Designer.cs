namespace BasicFacebookFeatures
{
    partial class FormGuessTheYear
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
            this.pictureToGuess = new System.Windows.Forms.PictureBox();
            this.buttonAnswer1 = new System.Windows.Forms.Button();
            this.buttonAnswer2 = new System.Windows.Forms.Button();
            this.buttonAnswer3 = new System.Windows.Forms.Button();
            this.buttonAnswer4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNumberOfPhotosThatLeft = new System.Windows.Forms.Label();
            this.labelNumberOfCorrectAnswers = new System.Windows.Forms.Label();
            this.labelNumberOfWrongAnswers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureToGuess)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureToGuess
            // 
            this.pictureToGuess.Location = new System.Drawing.Point(295, 12);
            this.pictureToGuess.Name = "pictureToGuess";
            this.pictureToGuess.Size = new System.Drawing.Size(250, 250);
            this.pictureToGuess.TabIndex = 0;
            this.pictureToGuess.TabStop = false;
            // 
            // buttonAnswer1
            // 
            this.buttonAnswer1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnswer1.Location = new System.Drawing.Point(223, 294);
            this.buttonAnswer1.Name = "buttonAnswer1";
            this.buttonAnswer1.Size = new System.Drawing.Size(174, 57);
            this.buttonAnswer1.TabIndex = 1;
            this.buttonAnswer1.Text = "Answer1";
            this.buttonAnswer1.UseVisualStyleBackColor = true;
            this.buttonAnswer1.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonAnswer2
            // 
            this.buttonAnswer2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnswer2.Location = new System.Drawing.Point(453, 294);
            this.buttonAnswer2.Name = "buttonAnswer2";
            this.buttonAnswer2.Size = new System.Drawing.Size(174, 57);
            this.buttonAnswer2.TabIndex = 2;
            this.buttonAnswer2.Text = "Answer2";
            this.buttonAnswer2.UseVisualStyleBackColor = true;
            this.buttonAnswer2.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonAnswer3
            // 
            this.buttonAnswer3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnswer3.Location = new System.Drawing.Point(223, 381);
            this.buttonAnswer3.Name = "buttonAnswer3";
            this.buttonAnswer3.Size = new System.Drawing.Size(174, 57);
            this.buttonAnswer3.TabIndex = 3;
            this.buttonAnswer3.Text = "Answer3";
            this.buttonAnswer3.UseVisualStyleBackColor = true;
            this.buttonAnswer3.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonAnswer4
            // 
            this.buttonAnswer4.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnswer4.Location = new System.Drawing.Point(453, 381);
            this.buttonAnswer4.Name = "buttonAnswer4";
            this.buttonAnswer4.Size = new System.Drawing.Size(174, 57);
            this.buttonAnswer4.TabIndex = 4;
            this.buttonAnswer4.Text = "Answer4";
            this.buttonAnswer4.UseVisualStyleBackColor = true;
            this.buttonAnswer4.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Photos Left:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Correct:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Wrong:";
            // 
            // labelNumberOfPhotosThatLeft
            // 
            this.labelNumberOfPhotosThatLeft.AutoSize = true;
            this.labelNumberOfPhotosThatLeft.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfPhotosThatLeft.Location = new System.Drawing.Point(143, 49);
            this.labelNumberOfPhotosThatLeft.Name = "labelNumberOfPhotosThatLeft";
            this.labelNumberOfPhotosThatLeft.Size = new System.Drawing.Size(24, 28);
            this.labelNumberOfPhotosThatLeft.TabIndex = 8;
            this.labelNumberOfPhotosThatLeft.Text = "0";
            // 
            // labelNumberOfCorrectAnswers
            // 
            this.labelNumberOfCorrectAnswers.AutoSize = true;
            this.labelNumberOfCorrectAnswers.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfCorrectAnswers.Location = new System.Drawing.Point(141, 107);
            this.labelNumberOfCorrectAnswers.Name = "labelNumberOfCorrectAnswers";
            this.labelNumberOfCorrectAnswers.Size = new System.Drawing.Size(24, 28);
            this.labelNumberOfCorrectAnswers.TabIndex = 9;
            this.labelNumberOfCorrectAnswers.Text = "0";
            // 
            // labelNumberOfWrongAnswers
            // 
            this.labelNumberOfWrongAnswers.AutoSize = true;
            this.labelNumberOfWrongAnswers.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfWrongAnswers.Location = new System.Drawing.Point(141, 168);
            this.labelNumberOfWrongAnswers.Name = "labelNumberOfWrongAnswers";
            this.labelNumberOfWrongAnswers.Size = new System.Drawing.Size(24, 28);
            this.labelNumberOfWrongAnswers.TabIndex = 10;
            this.labelNumberOfWrongAnswers.Text = "0";
            // 
            // FormGuessTheYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelNumberOfWrongAnswers);
            this.Controls.Add(this.labelNumberOfCorrectAnswers);
            this.Controls.Add(this.labelNumberOfPhotosThatLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnswer4);
            this.Controls.Add(this.buttonAnswer3);
            this.Controls.Add(this.buttonAnswer2);
            this.Controls.Add(this.buttonAnswer1);
            this.Controls.Add(this.pictureToGuess);
            this.Name = "FormGuessTheYear";
            this.Text = "FormGuessTheYear";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formGuessTheYear_FormClosed);
            this.Load += new System.EventHandler(this.formGuessTheYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureToGuess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureToGuess;
        private System.Windows.Forms.Button buttonAnswer1;
        private System.Windows.Forms.Button buttonAnswer2;
        private System.Windows.Forms.Button buttonAnswer3;
        private System.Windows.Forms.Button buttonAnswer4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNumberOfPhotosThatLeft;
        private System.Windows.Forms.Label labelNumberOfCorrectAnswers;
        private System.Windows.Forms.Label labelNumberOfWrongAnswers;
    }
}