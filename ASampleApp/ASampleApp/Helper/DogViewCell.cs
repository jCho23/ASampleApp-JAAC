using System;
using Xamarin.Forms;

namespace ASampleApp.Helper
{
    public class DogViewCell : ViewCell
    {
        public static readonly BindableProperty DogProperty = BindableProperty.Create<DogViewCell, Dog>(p => p.Dog, new Dog());

        public Dog Dog
		{
			get { return (Dog)GetValue(DogProperty); }
			set { SetValue(DogProperty, value); }
		}

        public string MyDoggoName { get; set; }
        public string MyDoggoFurColor { get; set; }

        public DogViewCell()
        {
            //var _myImage = new Image();
            var _myDoggoName = new Label();
            var _myDoggoFurColor = new Label();
            var _myHorizontalLayout = new StackLayout(){
                Children = {
                    _myDoggoName,
                    _myDoggoFurColor
                }
            };

            //_myImage.SetBinding();


            View = _myHorizontalLayout;
        }
    }
}
