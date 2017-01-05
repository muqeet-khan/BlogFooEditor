using Xamarin.Forms;

namespace BlogFooEditor.UI
{
    public class TitleEntry : Entry
    {
        public static readonly BindableProperty PlaceholderTextColorProperty =
            BindableProperty.Create("PlaceholderTextColor", typeof(Color), typeof(TitleEntry), Color.Default);

        public Color PlaceholderTextColor
        {
            get { return (Color)GetValue(PlaceholderTextColorProperty); }
            set { SetValue(PlaceholderTextColorProperty, value); }
        }
    }
}
