using System;
using System.Collections.Generic;
using FridaysTodoList.Models;
using FridaysTodoList.ViewModels;
using Xamarin.Forms;

namespace FridaysTodoList.Views
{
    public partial class AddItemsPage 
    {
        public AddItemsPage(NewItem arg)
        {
            BindingContext = new AddItemsViewModel(arg);
            InitializeComponent();
        }
    }
}
