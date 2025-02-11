using BasicFacebookFeatures.Observers;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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

            r_GuessTheYearGame.AddObserver(new GameStatsDisplay(
        labelNumberOfCorrectAnswers,
        labelNumberOfWrongAnswers,
        labelNumberOfPhotosThatLeft
    ));

            r_GuessTheYearGame.AddObserver(new GameLogger());
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
            new Thread(() => displayNextQuestion()).Start();
        }

        private void displayNextQuestion()
        {
            if (!r_GuessTheYearGame.DisplayNextQuestion(message => 
            {
                this.Invoke(new Action(() => MessageBox.Show(message)));
            }))
            {
                finishGame();
                return;
            }

            displayPhotoInQuestion(r_GuessTheYearGame.CurrentPhoto);
            displayAnswerOptions(r_GuessTheYearGame.GetCurrentAnswerOptions());
        }

        private void displayPhotoInQuestion(Photo i_Photo)
        {
            pictureToGuess.Invoke(new Action(() =>
            {
                pictureToGuess.ImageLocation = i_Photo.PictureNormalURL;
                pictureToGuess.SizeMode = PictureBoxSizeMode.StretchImage;
            }));
        }

        private void displayAnswerOptions(List<int> i_AnswerOptions)
        {
            for (int i = 0; i < i_AnswerOptions.Count; i++)
            {
                Button currentButton = Controls[$"buttonAnswer{i + 1}"] as Button;
                currentButton?.Invoke(new Action(() =>
                {
                    currentButton.Text = i_AnswerOptions[i].ToString();
                    currentButton.BackColor = DefaultBackColor;
                }));
            }
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int selectedAnswerIndex = int.Parse(clickedButton.Name.Replace("buttonAnswer", "")) - 1;
                new Thread(() =>
                {
                    r_GuessTheYearGame.HandleAnswer(selectedAnswerIndex, () =>
                    {
                        updateAnswerCounters();
                        highlightCorrectAnswer();
                    });
                }).Start();
            }
        }

        private void updateAnswerCounters()
        {
            labelNumberOfCorrectAnswers.Invoke(new Action(() =>
                labelNumberOfCorrectAnswers.Text = r_GuessTheYearGame.CorrectAnswers.ToString()));
            labelNumberOfWrongAnswers.Invoke(new Action(() =>
                labelNumberOfWrongAnswers.Text = r_GuessTheYearGame.WrongAnswers.ToString()));
            updateRemainingPhotosCount();
        }

        private void updateRemainingPhotosCount()
        {
            labelNumberOfPhotosThatLeft.Invoke(new Action(() =>
                labelNumberOfPhotosThatLeft.Text = r_GuessTheYearGame.RemainingPhotos.ToString()));
        }

        private void highlightCorrectAnswer()
        {
            Button correctButton = Controls[$"buttonAnswer{r_GuessTheYearGame.CorrectAnswerIndex + 1}"] as Button;
            correctButton?.Invoke(new Action(() => correctButton.BackColor = Color.LightGreen));

            Thread.Sleep(1500); // Give user time to see the correct answer

            correctButton?.Invoke(new Action(() => correctButton.BackColor = DefaultBackColor));
            new Thread(() => displayNextQuestion()).Start();
        }

        private void finishGame()
        {
            this.Invoke(new Action(() =>
            {
                MessageBox.Show(r_GuessTheYearGame.GetGameSummary());
                Close();
                m_MainForm?.Show();
            }));
        }

        private void formGuessTheYear_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_MainForm?.Show();
        }
    }
}


