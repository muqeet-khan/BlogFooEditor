using BlogFooEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BlogFooEditor
{
    public partial class ShowResult : ContentPage
    {
        private readonly Post _newpost;

        public ShowResult(Post newPost)
        {
            
            InitializeComponent();
            _newpost = newPost;
            Upload.Clicked += Upload_Clicked;
            var htmlSource = new HtmlWebViewSource();
            var result = CommonMark.CommonMarkConverter.Convert(newPost.Content);            
            htmlSource.Html = result;
            browser.Source = htmlSource;
        }

        private async void Upload_Clicked(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                                {
                                    new KeyValuePair<string, string>("postContent", _newpost.Content),
                                    new KeyValuePair<string, string>("postTitle", _newpost.Title),
                                    new KeyValuePair<string, string>("postSubtitle", _newpost.SubTitle),
                                    new KeyValuePair<string, string>("value", "sam")
                                });
                var callback = client.PostAsync("https://blog.muqeetkhan.com/home/uploaddata", content);
                string contentResult = callback.Result.Content.ReadAsStringAsync().Result;
                //await Navigation.PopAsync();
                await Navigation.PushAsync(new ResultViewer(_newpost.Title));
            }
        }
    }
}
