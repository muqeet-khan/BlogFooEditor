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
        public ShowResult(Post newPost)
        {
            
            InitializeComponent();
            ToolbarItem nav1 = new ToolbarItem("Upload", "add.png", async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new[]
                                    {
                                    new KeyValuePair<string, string>("postContent", newPost.Content),
                                    new KeyValuePair<string, string>("postTitle", newPost.Title),
                                    new KeyValuePair<string, string>("postSubtitle", newPost.SubTitle),
                                    new KeyValuePair<string, string>("value", "sam")
                                });
                    var callback = client.PostAsync("https://blog.muqeetkhan.com/home/uploaddata", content);
                    string contentResult = callback.Result.Content.ReadAsStringAsync().Result;
                    //await Navigation.PopAsync();
                    await Navigation.PushAsync(new ResultViewer(newPost.Title));
                }
            });
            ToolbarItems.Add(nav1);
            var htmlSource = new HtmlWebViewSource();
            var result = CommonMark.CommonMarkConverter.Convert(newPost.Content);            
            htmlSource.Html = result;
            browser.Source = htmlSource;
        }
    }
}
