using System;
using Xamarin.Forms;
using ASampleApp.ViewModel;

using ASampleApp.Data;
using SQLite;
//using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using ASampleApp.View.Base;
using Plugin.Media;
using System.Threading.Tasks;

namespace ASampleApp.View
{
    public class AddDogPicturePage : BaseContentPage<AddDogPicturePageViewModel>
    {
        Entry _dogNameEntry = new Entry { Placeholder = "Enter Name of Dog" };
        Entry _dogFurColorEntry = new Entry { Placeholder = "Enter Dog Fur Color" };
        //Entry _dogPictureURLEntry = new Entry { Text = "https://s-media-cache-ak0.pinimg.com/736x/a9/e5/49/a9e5491335b070025a517cf748bb317c--havanese-puppies-teacup-puppies.jpg" };
        Entry _dogPictureURLEntry = new Entry { Placeholder = "Type URL of Dog Picture" };
        Image _dogImage = new Image();

        Button _submitNameandFurColorButton = new Button { Text = "Submit" };
        Button _takeDogPictureButton = new Button { Text = "Take Dog Picture" };
        Button _saveDogPictureButton = new Button { Text = "Save Dog Picture", IsEnabled = false };

        public AddDogPicturePage()
        {
            _dogFurColorEntry.SetBinding(Entry.TextProperty, "FurColorOfDog");
            _dogNameEntry.SetBinding(Entry.TextProperty, "DogName");
            _dogPictureURLEntry.SetBinding(Entry.TextProperty, nameof(MyViewModel.DogPictureURL));
            _submitNameandFurColorButton.SetBinding(Button.CommandProperty, "DisplayItemCommand");

            Content = new StackLayout
            {
                Margin = 20,
                Children = {
                    _dogNameEntry,
                    _dogFurColorEntry,
                    _dogPictureURLEntry,
                    _submitNameandFurColorButton,
                    _takeDogPictureButton,
                    _saveDogPictureButton,
                    _dogImage
                }
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _submitNameandFurColorButton.Clicked += _submitNameandFurColorButton_Clicked;
            _takeDogPictureButton.Clicked += _takeDogPictureButton_Clicked;
        }

        void _submitNameandFurColorButton_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new ListOfDogsPicturesPage()));
        }

        async void _takeDogPictureButton_Clicked(object sender, EventArgs e)
        {
            CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                //PhotoSize = PhotoSize.Small,
                //CustomPhotoSize = 50,
                Directory = "Sample",
                Name = "test.jpg"
            });
            if (file == null)
                return;
            await DisplayAlert("File Location", file.Path, "OK");
            //_dogImage.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});
            //or:
            _dogImage.Source = ImageSource.FromFile(file.Path);
            _saveDogPictureButton.IsEnabled = true;
            file.Dispose();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _submitNameandFurColorButton.Clicked -= _submitNameandFurColorButton_Clicked;
            _takeDogPictureButton.Clicked -= _takeDogPictureButton_Clicked;
        }

    }
}
