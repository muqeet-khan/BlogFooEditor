using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlogFooEditor.ViewModels
{
    public class Post
    {

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public List<MediaFile> Images { get; set; }
    }
}
