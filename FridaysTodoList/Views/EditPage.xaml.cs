using System;
using System.Collections.Generic;
using FridaysTodoList.Models;
using FridaysTodoList.ViewModels;
using Xamarin.Forms;

namespace FridaysTodoList.Views
{
    public partial class EditPage 
    {
       
        public EditPage(NewItem arg)
        {
            BindingContext = new EditViewModel(arg);
            InitializeComponent();
        }
    }
}
