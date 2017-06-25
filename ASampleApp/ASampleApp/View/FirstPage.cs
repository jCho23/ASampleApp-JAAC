using System;

using Xamarin.Forms;
using ASampleApp.ViewModel;
using ASampleApp.Data;
using SQLite;
//using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using ASampleApp.View.Base;

namespace ASampleApp.View
{
    public class FirstPage : BaseContentPage<FirstViewModel>
    {
        Entry _dogNameEntry = new Entry { Placeholder = "Enter Name of Dog" };
        Entry _dogFurColorEntry = new Entry { Placeholder = "Enter Dog Fur Color" };
        Button _submitNameandFurColorButton = new Button { Text = "Submit" };
        Button _getListOfDogsButton = new Button { Text = "Get Dogs" };

        Button _addDogPicture = new Button { Text = "Add Dog Picture" };
        Button _getListOfDogsPicturesButton = new Button { Text = "Get List of Dogs Pictures" };
        Button _authenticatePagesButton = new Button { Text = "Auth Pages" };

        Label _dbPath = new Label() { Text = FileAccessHelper.GetLocalFilePath("people.db3") };

        public FirstPage()
        {
            _dogFurColorEntry.SetBinding(Entry.TextProperty, "FurColorOfDog");
            _dogNameEntry.SetBinding(Entry.TextProperty, "DogName");
            _submitNameandFurColorButton.SetBinding(Button.CommandProperty, "DisplayItemCommand");

            //_getListOfDogsPicturesButton.SetBinding(Button.CommandProperty, nameof(MyViewModel.));

            Content = new StackLayout
            {
                Margin = 20,
                Children = {
                    _dogNameEntry,
                    _dogFurColorEntry,
                    _submitNameandFurColorButton,
                    _getListOfDogsButton,
                    _addDogPicture,
                    _getListOfDogsPicturesButton,
                    _authenticatePagesButton,
                }
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _getListOfDogsButton.Clicked  += _getListOfDogsButton_Clicked;
            _getListOfDogsPicturesButton.Clicked += _getListOfDogsPicturesButton_Clicked;
            _addDogPicture.Clicked += _addDogPicture_Clicked;

        }

        private void _addDogPicture_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new AddDogPicturePage()));
		}

        private void _getListOfDogsPicturesButton_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new ListOfDogsPicturesPage()));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _getListOfDogsButton.Clicked -= _getListOfDogsButton_Clicked;
            _getListOfDogsPicturesButton.Clicked -= _getListOfDogsPicturesButton_Clicked;
			_addDogPicture.Clicked -= _addDogPicture_Clicked;
		}


        void _getListOfDogsButton_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new ListOfDogsPage()));
        }
    }
}

