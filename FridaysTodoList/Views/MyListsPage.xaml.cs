using System;
using System.Collections.Generic;
using FridaysTodoList.ViewModels;
using Xamarin.Forms;

namespace FridaysTodoList.Views
{
    public partial class MyListsPage : ContentPage
    {
        public MyListsPage()
        {
            InitializeComponent();
            BindingContext  = App.NotificationVm = new MyListViewModel();
             
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MyListViewModel)this.BindingContext).BindData(false);
        }
    }
}
