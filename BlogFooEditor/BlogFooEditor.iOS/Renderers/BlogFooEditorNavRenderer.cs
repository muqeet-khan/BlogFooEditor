using BlogFooEditor.iOS.Renderers;
using System.Collections.Generic;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(NavigationPage), typeof(BlogFooEditorNavRenderer))]
namespace BlogFooEditor.iOS.Renderers
{
    class BlogFooEditorNavRenderer : NavigationRenderer
    {
        public override void PushViewController(UIViewController viewController, bool animated)
        {
            base.PushViewController(viewController, animated);


            var list = new List<UIBarButtonItem>();

            foreach (var item in TopViewController.NavigationItem.RightBarButtonItems)
            {
                if (string.IsNullOrEmpty(item.Title))
                {
                    continue;
                }

                if (item.Title.ToLower() == "done")
                {
                    var newItem = new UIBarButtonItem(UIBarButtonSystemItem.Add)
                    {
                        Action = item.Action,
                        Target = item.Target
                    };

                    list.Add(newItem);
                }

                if (item.Title.ToLower() == "upload")
                {
                    var newItem = new UIBarButtonItem(UIBarButtonSystemItem.Save)
                    {
                        Action = item.Action,
                        Target = item.Target
                    };

                    list.Add(newItem);
                }

                TopViewController.NavigationItem.RightBarButtonItems = list.ToArray();
            }
        }
    }
}