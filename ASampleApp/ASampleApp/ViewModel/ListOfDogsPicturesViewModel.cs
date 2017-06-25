using System;
using System.Collections;
using System.Collections.Generic;
using ASampleApp.Data;
using System.Collections.ObjectModel;

namespace ASampleApp.ViewModel
{
    public class ListOfDogsPicturesViewModel :BaseViewModel
    {

		ObservableCollection<Dog> _listOfDoggos;

        public ListOfDogsPicturesViewModel()
		{

			var list = new List<Dog> { };
			list = App.DogRepo.GetAllDogs();
			_listOfDoggos = new ObservableCollection<Dog>();
			foreach (var item in list)
				_listOfDoggos.Add(item);
		}

		//public IList<Dog> ListOfDoggos
		public ObservableCollection<Dog> ListOfDoggos
		{
			get { return _listOfDoggos; }
			set { SetProperty(ref _listOfDoggos, value); }
		}
	}
}