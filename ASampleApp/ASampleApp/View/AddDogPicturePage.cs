using System;
using Xamarin.Forms;
using ASampleApp.ViewModel;
using ASampleApp.Data;
using SQLite;
//using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using ASampleApp.View.Base;

namespace ASampleApp.View
{
    public class AddDogPicturePage : BaseContentPage<FirstViewModel>
    {
		Entry _dogNameEntry = new Entry { Placeholder = "Enter Name of Dog" };
        Entry _dogFurColorEntry = new Entry { Placeholder = "Enter Dog Fur Color" };
		Entry _dogPictureURL = new Entry { Text = "https://kasehavanese.files.wordpress.com/2014/10/izzyy1.jpg?w=519&h=346&crop=1" };
		Button _submitNameandFurColorButton = new Button { Text = "Submit" };


        public AddDogPicturePage()
        {

			Content = new StackLayout
			{
				Margin = 20,
				Children = {
					_dogNameEntry,
					_dogFurColorEntry,
                    _dogPictureURL,
					_submitNameandFurColorButton,
					
				}
			};

        }
    }
}
