using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Adapters;
using System.Drawing;
using System.Collections.Generic;

namespace BasicFacebookFeatures
{
    public partial class FormGuessTheYear : Form
    {
        private Form m_MainForm;
        private IGuessTheYearGame m_CurrentGame;

        public FormGuessTheYear()
        {
            InitializeComponent();
        }

        public Form MainForm
        {
            get { return m_MainForm; }
            set { m_MainForm = value; }
        }

        private void formGuessTheYear_Load(object sender, EventArgs e)
        {
            // Form load initialization if needed
        }

        public void LoadGame(IGuessTheYearGame i_Game)
        {
            m_CurrentGame = i_Game;
            m_CurrentGame.Start();
            displayNextQuestion();
        }

        private void displayNextQuestion()
        {
            PhotoInfo currentPhoto = m_CurrentGame.GetCurrentPhoto();
            if (currentPhoto == null)
            {
                m_CurrentGame.End();
                MessageBox.Show(m_CurrentGame.GetGameSummary());
                Close();
                return;
            }

            pictureToGuess.ImageLocation = currentPhoto.ImageUrl;
            displayAnswerOptions(m_CurrentGame.GetAnswerOptions());
            labelNumberOfCorrectAnswers.Text = m_CurrentGame.Score.ToString();
        }

        private void displayAnswerOptions(List<int> i_AnswerOptions)
        {
            buttonAnswer1.Text = i_AnswerOptions[0].ToString();
            buttonAnswer2.Text = i_AnswerOptions[1].ToString();
            buttonAnswer3.Text = i_AnswerOptions[2].ToString();
            buttonAnswer4.Text = i_AnswerOptions[3].ToString();
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int selectedAnswerIndex = int.Parse(clickedButton.Name.Replace("buttonAnswer", "")) - 1;
                bool isCorrect = m_CurrentGame.CheckAnswer(selectedAnswerIndex);
                highlightCorrectAnswer();

                Timer timer = new Timer { Interval = 1500 };
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    displayNextQuestion();
                };
                timer.Start();
            }
        }

        private void highlightCorrectAnswer()
        {
            int correctIndex = m_CurrentGame.GetCorrectAnswerIndex();
            Button correctButton = Controls[$"buttonAnswer{correctIndex + 1}"] as Button;
            if (correctButton != null)
            {
                correctButton.BackColor = Color.LightGreen;
            }
        }

        private void formGuessTheYear_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm?.Show();
        }
    }
}


