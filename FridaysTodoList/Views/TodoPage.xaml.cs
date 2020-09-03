using System;
using System.Collections.Generic;
using FridaysTodoList.Models;
using FridaysTodoList.ViewModels;
using Xamarin.Forms;

namespace FridaysTodoList.Views
{
    public partial class TodoPage : ContentPage
    {
        public TodoPage(string v)
        {
            InitializeComponent();
        }

        async void OnCancel(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

       
      


    }
}
