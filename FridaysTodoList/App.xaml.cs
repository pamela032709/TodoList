using System;
using FridaysTodoList.ViewModels;
using FridaysTodoList.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FridaysTodoList
{
    public partial class App : Application
    {
        public static MyListViewModel NotificationVm { get; set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainNavigationPage())
            //{
            //    BarBackgroundColor = Color.FromHex("#791AE5"),
            //    BarTextColor = Color.White,
            //};
            MainPage = new NavigationPage(new MainNavigationPage());
           

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
