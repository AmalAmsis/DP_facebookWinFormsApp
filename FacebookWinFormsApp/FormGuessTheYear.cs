using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormGuessTheYear : Form
    {
        private Form m_MainForm;
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private readonly FacebookObjectCollection<Photo> r_PhotoCollection = new FacebookObjectCollection<Photo>();
        private readonly Random r_RandomGenerator = new Random();
        private int m_CorrectAnswerButtonIndex;

        public FormGuessTheYear()
        {
            InitializeComponent();
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

        public LoginResult LoginResult
        {
            get
            {
                return m_LoginResult;
            }
            set
            {
                m_LoginResult = value;
                m_LoggedInUser = value?.LoggedInUser;
            }
        }

        private void formGuessTheYear_Load(object sender, EventArgs e)
        {
            if (!loadUserPhotos())
            {
                return;
            }

            updateRemainingPhotosCount();
            displayNextQuestion();
        }

        private bool loadUserPhotos()
        {
            bool loadedSuccessfully;

            if (m_LoggedInUser?.Albums == null || !m_LoggedInUser.Albums.Any())
            {
                MessageBox.Show("No albums found for the logged-in user.");
                Close();

                loadedSuccessfully = false;
            }
            else
            {
                foreach (Album album in m_LoggedInUser.Albums)
                {
                    foreach (Photo photo in album.Photos)
                    {
                        r_PhotoCollection.Add(photo);
                    }
                }

                loadedSuccessfully = true;
            }
            
            return loadedSuccessfully;
        }

        private void displayNextQuestion()
        {
            if (!tryGetNextPhoto(out Photo o_NextPhoto))
            {
                finishGame();
                return;
            }

            if (!o_NextPhoto.CreatedTime.HasValue)
            {
                MessageBox.Show("Photo has no creation date. Skipping...");
                displayNextQuestion();
                return;
            }

            setupQuestionForPhoto(o_NextPhoto);
        }

        private bool tryGetNextPhoto(out Photo o_Photo)
        {
            bool succeedGettingNextPhoto;

            if (r_PhotoCollection.Count > 0)
            {
                o_Photo = r_PhotoCollection[0];
                r_PhotoCollection.RemoveAt(0);
                succeedGettingNextPhoto = true;
            }
            else
            {
                o_Photo = null;
                succeedGettingNextPhoto = false;
            }

            return succeedGettingNextPhoto;
        }

        private void setupQuestionForPhoto(Photo i_Photo)
        {
            int photoYear = i_Photo.CreatedTime.Value.Year;
            int lowerBound = Math.Max(photoYear - 5, DateTime.MinValue.Year);
            int upperBound = Math.Min(photoYear + 5, DateTime.Now.Year);

            displayPhotoInQuestion(i_Photo);
            assignYearsToAnswerButtons(photoYear, lowerBound, upperBound);
        }

        private void displayPhotoInQuestion(Photo i_Photo)
        {
            pictureToGuess.ImageLocation = i_Photo.PictureNormalURL;
            pictureToGuess.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void assignYearsToAnswerButtons(int i_CorrectYear, int i_LowerBound, int i_UpperBound)
        {
            m_CorrectAnswerButtonIndex = r_RandomGenerator.Next(1, 5);

            List<int> usedYears = new List<int>();

            for (int buttonIndex = 1; buttonIndex <= 4; buttonIndex++)
            {
                if (buttonIndex == m_CorrectAnswerButtonIndex)
                {
                    setButtonText(buttonIndex, i_CorrectYear.ToString());
                }
                else
                {
                    int randomYear;
                    do
                    {
                        randomYear = r_RandomGenerator.Next(i_LowerBound, i_UpperBound + 1);
                    } 
                    while (usedYears.Contains(randomYear) || randomYear == i_CorrectYear);

                    usedYears.Add(randomYear);
                    setButtonText(buttonIndex, randomYear.ToString());
                }
            }
        }

        private void setButtonText(int i_ButtonIndex, string i_Text)
        {
            Controls[$"buttonAnswer{i_ButtonIndex}"].Text = i_Text;
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int selectedAnswerIndex = int.Parse(clickedButton.Name.Replace("buttonAnswer", ""));
                handleAnswer(selectedAnswerIndex);
            }
        }

        private void handleAnswer(int i_SelectedAnswerIndex)
        {
            bool isCorrect = i_SelectedAnswerIndex == m_CorrectAnswerButtonIndex;
            updateAnswerCounters(isCorrect);
            highlightCorrectAnswer();
        }

        private void updateAnswerCounters(bool i_IsCorrect)
        {
            Label labelToUpdate = i_IsCorrect ? labelNumberOfCorrectAnswers : labelNumberOfWrongAnswers;

            if (int.TryParse(labelToUpdate.Text, out int currentCount))
            {
                labelToUpdate.Text = (currentCount + 1).ToString();
            }

            updateRemainingPhotosCount();
        }

        private void updateRemainingPhotosCount()
        {
            labelNumberOfPhotosThatLeft.Text = r_PhotoCollection.Count.ToString();
        }

        private void highlightCorrectAnswer()
        {
            Controls[$"buttonAnswer{m_CorrectAnswerButtonIndex}"].BackColor = Color.LightGreen;

            Task.Delay(500).ContinueWith(_ =>
            {
                Invoke(new Action(() =>
                {
                    Controls[$"buttonAnswer{m_CorrectAnswerButtonIndex}"].BackColor = DefaultBackColor;
                    displayNextQuestion();
                }));
            });
        }

        private void finishGame()
        {
            MessageBox.Show($"Congratulations! You've completed the challenge.\n" +
                            $"Correct Answers: {labelNumberOfCorrectAnswers.Text}\n" +
                            $"Wrong Answers: {labelNumberOfWrongAnswers.Text}");

            Close();
            m_MainForm?.Show();
        }

        private void formGuessTheYear_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_MainForm?.Show();
        }
    }
}
