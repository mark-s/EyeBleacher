using System;
using System.Windows.Forms;
using EyeBleacher.Subreddits;

namespace EyeBleacher
{
    public partial class Form1 : Form
    {
        private readonly IGetSubredditImage _cuteSubreddit;
        private readonly IGetSubredditImage _wholesomeSubreddit;
        private readonly IGetSubredditImage _coolSubreddit;

        public Form1()
        {
            InitializeComponent();

            _cuteSubreddit = new CuteSubredditData();
            _wholesomeSubreddit = new WholesomeSubredditData();
            _coolSubreddit = new CoolSubredditData();

        }

        private void CuteButton_Click(object sender, EventArgs e)
        {
            var returnedData = _cuteSubreddit.GetImageFromSubreddit();

            pictureBox1.ImageLocation = returnedData.ImageLink;
            titleTextBox.Text = returnedData.PostTitle;
            usernameTextBox.Text = returnedData.PostAuthor;
            subredditTextBox.Text = returnedData.SubredditName;

        }

        private void WholesomeButton_Click(object sender, EventArgs e)
        {
            var returnedData = _wholesomeSubreddit.GetImageFromSubreddit();
            pictureBox1.ImageLocation = returnedData.ImageLink;
            titleTextBox.Text = returnedData.PostTitle;
            usernameTextBox.Text = returnedData.PostAuthor;
            subredditTextBox.Text = returnedData.SubredditName;
        }

        private void CoolButton_Click(object sender, EventArgs e)
        {
            var returnedData = _coolSubreddit.GetImageFromSubreddit();
            pictureBox1.ImageLocation = returnedData.ImageLink;
            titleTextBox.Text = returnedData.PostTitle;
            usernameTextBox.Text = returnedData.PostAuthor;
            subredditTextBox.Text = returnedData.SubredditName;
        }
    }
}
