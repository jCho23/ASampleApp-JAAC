﻿using System;
using System.Windows.Input;
using Xamarin.Forms;
using ASampleApp.Data;
using ASampleApp;
using ASampleApp.View;

namespace ASampleApp.ViewModel
{
    public class AddDogPicturePageViewModel : BaseViewModel
    {
        string _displayItem, _nameOfDog, _furColorOfDog, _displayListOfDogPictures;
        string _dogPictureURL; // = "https://s-media-cache-ak0.pinimg.com/736x/a9/e5/49/a9e5491335b070025a517cf748bb317c--havanese-puppies-teacup-puppies.jpg";
        string _dogPictureSource;
        string _dogPictureFile;

        public ICommand DisplayItemCommand { get; set; }
        public ICommand DisplayListOfDogPictures { get; set; }
        public ICommand AddNewDogPicture { get; set; }

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

        public string DogPictureFile
        {
            get => _dogPictureFile;
            set { SetProperty(ref _dogPictureFile, value);
                DogPictureSource = DogPictureFile;
            }
        }

		public string DogPictureURL
		{
			get { return _dogPictureURL; }
			set { SetProperty(ref _dogPictureURL, value);
                DogPictureSource = DogPictureURL;
            }
		}

		public string DogPictureSource
        {
            get => _dogPictureSource;
            set { SetProperty(ref _dogPictureSource, value); }
        }

        public AddDogPicturePageViewModel()
        {
            DisplayItemCommand = new Command(SubmitNewDogAction);
            DisplayListOfDogPictures = new Command(GetListOfDogPictures);
            AddNewDogPicture = new Command(MyAddNewDogPicture);
        }

        private void MyAddNewDogPicture()
        {
            App.DogRepo.AddDogImageByFile(this.DogName, this.FurColorOfDog, this.DogPictureSource);
        }

        private void GetListOfDogPictures(object obj)
        {
            throw new NotImplementedException();
        }

        void SubmitNewDogAction()
        {
            App.DogRepo.AddNewDog(this.DogName, this.FurColorOfDog, this.DogPictureURL);
            //new DogRepository(ASampleApp.App.DogRepo.ToString()).AddNewDog(DogName, FurColorOfDog);
        }
    }
}