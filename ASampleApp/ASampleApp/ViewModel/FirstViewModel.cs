using System;
using System.Windows.Input;
using Xamarin.Forms;
using ASampleApp.Data;
using ASampleApp;

namespace ASampleApp.ViewModel
{
    public class FirstViewModel : BaseViewModel
    {
        string _displayItem, _nameOfDog, _furColorOfDog;


        public ICommand DisplayItemCommand { get; set; }

        public string DisplayItem
        {
            get { return _displayItem; }
            set { SetProperty(ref _displayItem, value); }

        }

        public string DogName
        {
            get { return _nameOfDog; }
            set { SetProperty(ref _nameOfDog, value); }
        }

        public string FurColorOfDog 
        { 
            get => _furColorOfDog; 
            set => SetProperty(ref _furColorOfDog, value); 
        }

        public FirstViewModel(){
            DisplayItemCommand = new Command(SubmitNewDogAction);
        }

        void SubmitNewDogAction()
        {
            App.DogRepo.AddNewDog(this.DogName, this.FurColorOfDog);
            //new DogRepository(ASampleApp.App.DogRepo.ToString()).AddNewDog(DogName, FurColorOfDog);
        }
    }
}