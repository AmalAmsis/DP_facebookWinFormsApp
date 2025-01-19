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
        private readonly GuessTheYearGame r_GuessTheYearGame;

        public FormGuessTheYear(GuessTheYearGame i_GuessTheYearGame)
        {
            InitializeComponent();
            r_GuessTheYearGame = i_GuessTheYearGame;
        }

        public Form MainForm
        {
            get 
            { 
                return m_MainForm; 
            }
            set 
            {
                m_MainForm = value; 
            }
        }

        private void formGuessTheYear_Load(object sender, EventArgs e)
        {
            updateRemainingPhotosCount();
            displayNextQuestion();
        }

        private void displayNextQuestion()
        {
            if (!r_GuessTheYearGame.DisplayNextQuestion(message => MessageBox.Show(message)))
            {
                finishGame();
                return;
            }

            displayPhotoInQuestion(r_GuessTheYearGame.CurrentPhoto);
            displayAnswerOptions(r_GuessTheYearGame.GetCurrentAnswerOptions());
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
                r_GuessTheYearGame.HandleAnswer(selectedAnswerIndex, () =>
                {
                    updateAnswerCounters();
                    highlightCorrectAnswer();
                });
            }
        }

        private void updateAnswerCounters()
        {
            labelNumberOfCorrectAnswers.Text = r_GuessTheYearGame.CorrectAnswers.ToString();
            labelNumberOfWrongAnswers.Text = r_GuessTheYearGame.WrongAnswers.ToString();
            updateRemainingPhotosCount();
        }

        private void updateRemainingPhotosCount()
        {
            labelNumberOfPhotosThatLeft.Text = r_GuessTheYearGame.RemainingPhotos.ToString();
        }

        private void highlightCorrectAnswer()
        {
            Controls[$"buttonAnswer{r_GuessTheYearGame.CorrectAnswerIndex + 1}"].BackColor = Color.LightGreen;

            Task.Delay(500).ContinueWith(_ =>
            {
                Invoke(new Action(() =>
                {
                    Controls[$"buttonAnswer{r_GuessTheYearGame.CorrectAnswerIndex + 1}"].BackColor = DefaultBackColor;
                    displayNextQuestion();
                }));
            });
        }

        private void finishGame()
        {
            MessageBox.Show(r_GuessTheYearGame.GetGameSummary());
            Close();
            m_MainForm?.Show();
        }

        private void formGuessTheYear_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_MainForm?.Show();
        }
    }
}


