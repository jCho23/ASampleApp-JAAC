using System;
using Xamarin.Forms;
using ASampleApp.ViewModel;
using ASampleApp.Data;
using SQLite;
//using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using ASampleApp.View.Base;

namespace ASampleApp.View
{
    public class AddDogPicturePage : BaseContentPage<AddDogPicturePageViewModel>
    {
        Entry _dogNameEntry = new Entry { Placeholder = "Enter Name of Dog" };
        Entry _dogFurColorEntry = new Entry { Placeholder = "Enter Dog Fur Color" };
        //Entry _dogPictureURLEntry = new Entry { Text = "https://s-media-cache-ak0.pinimg.com/736x/a9/e5/49/a9e5491335b070025a517cf748bb317c--havanese-puppies-teacup-puppies.jpg" };
        Entry _dogPictureURLEntry = new Entry { Placeholder = "Type URL of Dog Picture" };

		Button _submitNameandFurColorButton = new Button { Text = "Submit" };


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

                }
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _submitNameandFurColorButton.Clicked += _submitNameandFurColorButton_Clicked;


        }

        void _submitNameandFurColorButton_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(()=>Navigation.PushAsync(new ListOfDogsPicturesPage()));
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _submitNameandFurColorButton.Clicked -= _submitNameandFurColorButton_Clicked;

        }

    }
}
