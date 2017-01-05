using BlogFooEditor.ViewModels;
using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BlogFooEditor
{
    public partial class MainPage : ContentPage
    {
        private Post _post;
        public MainPage()
        {
            InitializeComponent();
            InternetConnection.IsVisible = false;
            PostTitle.PlaceholderTextColor = Color.Blue;
            Done.Clicked += Done_Activated;
            Photo.Clicked += Photo_Clicked;
            _post = new Post()
            {
                Content = PostContent.Text,
                Title = PostTitle.Text,
                SubTitle = PostSubTitle.Text,
                Images = new List<MediaFile>(),
                Tags = ""
            };

            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                InternetConnection.IsVisible = true;
            };

        }

        private async void Photo_Clicked(object sender, EventArgs e)
        {

            var photoOption = await DisplayActionSheet("Photo Options:", "Cancel", null, "Take a Photo", "Pick a Photo");

            switch (photoOption)
            {
                case "Take a Photo":
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        AllowCropping = true,
                        CustomPhotoSize = 80,
                        CompressionQuality = 90,
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                        SaveToAlbum = true,
                        Directory = "Sample",
                        Name = "test.jpg"
                    });

                    var addedImage = file;

                    if (file == null)
                        return;

                    //await DisplayAlert("File Location", file.Path, "OK");

                    Image newImage = new Image();
                    newImage.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        //file.Dispose();
                        return stream;
                    });
                    PostContent.Text += Environment.NewLine + "[image](https://www.muqeetkhan.com/someImage)";
                    ImageStack.Children.Add(newImage);
                    _post.Images.Add(addedImage);
                    break;
                case "Pick a Photo":
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    var pickedFile = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                        CustomPhotoSize = 80,
                        CompressionQuality = 90
                    });

                    if (pickedFile == null)
                        return;

                    //await DisplayAlert("File Location", pickedFile.Path, "OK");
                    var pickedImageToAdd = pickedFile;
                    Image pickedImage = new Image();


                    pickedImage.Source = ImageSource.FromStream(() =>
                    {
                        var stream = pickedFile.GetStream();
                        //pickedFile.Dispose();
                        return stream;
                    });
                    PostContent.Text += Environment.NewLine + "[image](https://www.muqeetkhan.com/someImage)";
                    ImageStack.Children.Add(pickedImage);
                    _post.Images.Add(pickedImageToAdd);
                    break;
                default:
                    break;
            }


        }

        private async void Done_Activated(object sender, EventArgs e)
        {
            _post.Content = PostContent.Text;
            _post.Title = PostTitle.Text;
            _post.SubTitle = PostSubTitle.Text;
            await Navigation.PushAsync(new ShowResult(_post));
        }
    }
}
