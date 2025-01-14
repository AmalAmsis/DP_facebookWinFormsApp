using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormGuessTheYear : Form
    {
        private Form m_MainForm;
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private readonly GuessTheYearGame r_Game = new GuessTheYearGame();
        private Photo m_CurrentPhoto;

        public FormGuessTheYear()
        {
            InitializeComponent();
        }

        public Form MainForm
        {
            get { return m_MainForm; }
            set { m_MainForm = value; }
        }

        public LoginResult LoginResult
        {
            get { return m_LoginResult; }
            set
            {
                m_LoginResult = value;
                m_LoggedInUser = value?.LoggedInUser;
            }
        }

        private void formGuessTheYear_Load(object sender, EventArgs e)
        {
            if (!r_Game.LoadUserPhotos(m_LoggedInUser))
            {
                MessageBox.Show("No albums found for the logged-in user.");
                Close();
                return;
            }

            updateRemainingPhotosCount();
            displayNextQuestion();
        }

        private void displayNextQuestion()
        {
            m_CurrentPhoto = r_Game.GetNextPhoto();
            if (m_CurrentPhoto == null)
            {
                finishGame();
                return;
            }

            if (!m_CurrentPhoto.CreatedTime.HasValue)
            {
                MessageBox.Show("Photo has no creation date. Skipping...");
                displayNextQuestion();
                return;
            }

            displayPhotoInQuestion(m_CurrentPhoto);
            List<int> answerOptions = r_Game.GenerateAnswerOptions(m_CurrentPhoto.CreatedTime.Value.Year);
            displayAnswerOptions(answerOptions);
        }

        private void displayPhotoInQuestion(Photo i_Photo)
        {
            pictureToGuess.ImageLocation = i_Photo.PictureNormalURL;
            pictureToGuess.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void displayAnswerOptions(List<int> i_AnswerOptions)
        {
            for (int i = 0; i < i_AnswerOptions.Count; i++)
            {
                Controls[$"buttonAnswer{i + 1}"].Text = i_AnswerOptions[i].ToString();
            }
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int selectedAnswerIndex = int.Parse(clickedButton.Name.Replace("buttonAnswer", "")) - 1;
                handleAnswer(selectedAnswerIndex);
            }
        }

        private void handleAnswer(int i_SelectedAnswerIndex)
        {
            bool isCorrect = r_Game.CheckAnswer(i_SelectedAnswerIndex);
            updateAnswerCounters();
            highlightCorrectAnswer();
        }

        private void updateAnswerCounters()
        {
            labelNumberOfCorrectAnswers.Text = r_Game.CorrectAnswers.ToString();
            labelNumberOfWrongAnswers.Text = r_Game.WrongAnswers.ToString();
            updateRemainingPhotosCount();
        }

        private void updateRemainingPhotosCount()
        {
            labelNumberOfPhotosThatLeft.Text = r_Game.RemainingPhotos.ToString();
        }

        private void highlightCorrectAnswer()
        {
            Controls[$"buttonAnswer{r_Game.CorrectAnswerIndex + 1}"].BackColor = Color.LightGreen;

            Task.Delay(500).ContinueWith(_ =>
            {
                Invoke(new Action(() =>
                {
                    Controls[$"buttonAnswer{r_Game.CorrectAnswerIndex + 1}"].BackColor = DefaultBackColor;
                    displayNextQuestion();
                }));
            });
        }

        private void finishGame()
        {
            MessageBox.Show($"Congratulations! You've completed the challenge.\n" +
                          $"Correct Answers: {r_Game.CorrectAnswers}\n" +
                          $"Wrong Answers: {r_Game.WrongAnswers}");

            Close();
            m_MainForm?.Show();
        }

        private void formGuessTheYear_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_MainForm?.Show();
        }
    }
}


