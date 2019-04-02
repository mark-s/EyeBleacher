using System;
using System.Windows.Forms;
using EyeBleacher.Subreddits;

namespace EyeBleacher
{
    public partial class Form1 : Form
    {
        private readonly CuteSubredditData _cuteSubreddit;
        private readonly WholesomeSubredditData _wholesomeSubreddit;
        private readonly CoolSubredditData _coolSubreddit;

        public Form1()
        {
            InitializeComponent();

            _cuteSubreddit = new CuteSubredditData();
            _wholesomeSubreddit = new WholesomeSubredditData();
            _coolSubreddit = new CoolSubredditData();

        }

        private void cuteButton_Click(object sender, EventArgs e)
        {
                var returnedData = _cuteSubreddit.GetRandomEyebleachUrl();
                var imageLink = returnedData[0];
                var postTitle = returnedData[1];
                var postAuthor = returnedData[2];
                var subredditName = returnedData[3];

                pictureBox1.ImageLocation = imageLink;
                titleTextBox.Text = postTitle;
                usernameTextBox.Text = postAuthor;
                subredditTextBox.Text = subredditName;

        }

        private void wholesomeButton_Click(object sender, EventArgs e)
        {
                var returnedData =_wholesomeSubreddit.GetRandomWholesomeUrl();
                var imageLink = returnedData[0];
                var postTitle = returnedData[1];
                var postAuthor = returnedData[2];
                var subredditName = returnedData[3];

                pictureBox1.ImageLocation = imageLink;
                titleTextBox.Text = postTitle;
                usernameTextBox.Text = postAuthor;
                subredditTextBox.Text = subredditName;
        }

        private void coolButton_Click(object sender, EventArgs e)
        {
                var returnedData = _coolSubreddit.GetRandomCoolUrl();
                var imageLink = returnedData[0];
                var postTitle = returnedData[1];
                var postAuthor = returnedData[2];
                var subredditName = returnedData[3];

                pictureBox1.ImageLocation = imageLink;
                titleTextBox.Text = postTitle;
                usernameTextBox.Text = postAuthor;
                subredditTextBox.Text = subredditName;
        }
    }
}
