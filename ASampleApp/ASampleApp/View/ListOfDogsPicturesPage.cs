using System;
using Xamarin.Forms;
using ASampleApp.Data;
using ASampleApp.Helper;
using ASampleApp.View.Base;
using ASampleApp.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ASampleApp.View
{
    public class ListOfDogsPicturesPage : BaseContentPage<ListOfDogsPicturesViewModel>
    {
        ListView _dogList;

        public ListOfDogsPicturesPage()
        {
            _dogList = new ListView();
            _dogList.SetBinding(ListView.ItemsSourceProperty, nameof(MyViewModel.ListOfDoggos));

            var myTemplate = new DataTemplate(typeof(ImageCell));
            var model = BindingContext as Dog;
            myTemplate.SetBinding(ImageCell.TextProperty, nameof(model.Name));
            myTemplate.SetBinding(ImageCell.DetailProperty, nameof(model.FurColor));

            //myTemplate.SetValue(ImageCell.ImageSourceProperty, new Uri("https://kasehavanese.files.wordpress.com/2014/10/izzyy1.jpg?w=519&h=346&crop=1"));
            myTemplate.SetBinding(ImageCell.ImageSourceProperty, nameof(model.DogPictureURL));

			_dogList.ItemTemplate = myTemplate;

            Content = new StackLayout
            {
                Margin = 20,
                Children = {
                    _dogList
                }
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Hack1-simply set properties each time page appears
            //MyViewModel.ListOfDoggos = App.DogRepo.GetAllDogs();
        }
    }
}
