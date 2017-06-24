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
    public class ListOfDogsPage : BaseContentPage<ListOfDogsViewModel>
    {
        ListView _dogList;
        ///var _cellColor;

        public ListOfDogsPage()
        {
            _dogList = new ListView();
			_dogList.SetBinding(ListView.ItemsSourceProperty, nameof(MyViewModel.ListOfDoggos));

			var myTemplate = new DataTemplate(typeof(TextCell));
            var model = BindingContext as Dog;
            myTemplate.SetBinding(TextCell.TextProperty, nameof(model.Name));
            myTemplate.SetBinding(TextCell.DetailProperty, nameof(model.FurColor));

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
