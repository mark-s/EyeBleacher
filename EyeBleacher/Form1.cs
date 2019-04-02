using System;
using System.Windows.Forms;
using EyeBleacher.Helpers;
using EyeBleacher.Subreddits;
using EyeBleacher.SubredditUrlProviders;

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

            var randomiser = new RandomHelper();

            _cuteSubreddit = new CuteSubredditData(new Cute(), randomiser);
            _wholesomeSubreddit = new WholesomeSubredditData(new Wholesome(), randomiser);
            _coolSubreddit = new CoolSubredditData(new Cool(), randomiser);

        }

        private void CuteButton_Click(object sender, EventArgs e)
        {
            var returnedData = _cuteSubreddit.GetImageFromSubreddit();
            UpdateUi(returnedData);
        }

        private void WholesomeButton_Click(object sender, EventArgs e)
        {
            var returnedData = _wholesomeSubreddit.GetImageFromSubreddit();
            UpdateUi(returnedData);
        }

        private void CoolButton_Click(object sender, EventArgs e)
        {
            var returnedData = _coolSubreddit.GetImageFromSubreddit();
            UpdateUi(returnedData);
        }

        private void UpdateUi(SubredditImageInfo returnedData)
        {
            pictureBox1.ImageLocation = returnedData.ImageLink;
            titleTextBox.Text = returnedData.PostTitle;
            usernameTextBox.Text = returnedData.PostAuthor;
            subredditTextBox.Text = returnedData.SubredditName;
        }
    }
}
