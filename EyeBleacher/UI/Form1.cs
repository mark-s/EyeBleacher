using System;
using System.Windows.Forms;
using EyeBleacher.Interfaces;
using EyeBleacher.Services;
using EyeBleacher.UrlCollections;

namespace EyeBleacher.UI
{
    public partial class Form1 : Form
    {
        private readonly IGetSubredditImages _cuteSubreddit;
        private readonly IGetSubredditImages _wholesomeSubreddit;
        private readonly IGetSubredditImages _coolSubreddit;

        public Form1()
        {
            InitializeComponent();

            _cuteSubreddit = new EyeBleachService(new CuteUrls());
            _wholesomeSubreddit = new EyeBleachService(new WholesomeUrls());
            _coolSubreddit = new EyeBleachService(new CoolUrls());
        }

        private async void CuteButton_Click(object sender, EventArgs e)
        {
            var cuteStuff = await _cuteSubreddit.GetImageAsync();
            UpdateUi(cuteStuff);
        }

        private async void WholesomeButton_Click(object sender, EventArgs e)
        {
            var wholesomeStuff = await _wholesomeSubreddit.GetImageAsync();
            UpdateUi(wholesomeStuff);
        }

        private async void CoolButton_Click(object sender, EventArgs e)
        {
            var coolStuff = await _coolSubreddit.GetImageAsync();
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
