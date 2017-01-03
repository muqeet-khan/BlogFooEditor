using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BlogFooEditor
{
    public partial class ResultViewer : ContentPage
    {
        public ResultViewer(string postTitle)
        {
            InitializeComponent();
            browser.Source = $"http://blog.muqeetkhan.com/home/b/{postTitle.Replace(" ","-")}";
        }
    }
}
