using System;
using System.Windows.Forms;
using EyeBleacher.Helpers;
using EyeBleacher.Subreddits;
using EyeBleacher.UrlCollections;

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

            _cuteSubreddit = new EyeBleachGetter(new CuteUrls(), randomiser);
            _wholesomeSubreddit = new EyeBleachGetter(new WholesomeUrls(), randomiser);
            _coolSubreddit = new EyeBleachGetter(new CoolUrls(), randomiser);

        }

        private async void CuteButton_Click(object sender, EventArgs e)
        {
            var cuteStuff = await _cuteSubreddit.GetImageFromSubredditAsync();
            UpdateUi(cuteStuff);
        }

        private async void WholesomeButton_Click(object sender, EventArgs e)
        {
            var wholesomeStuff = await _wholesomeSubreddit.GetImageFromSubredditAsync();
            UpdateUi(wholesomeStuff);
        }

        private async void CoolButton_Click(object sender, EventArgs e)
        {
            var coolStuff = await _coolSubreddit.GetImageFromSubredditAsync();
            UpdateUi(coolStuff);
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
