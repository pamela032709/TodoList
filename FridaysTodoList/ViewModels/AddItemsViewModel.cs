using System;
using System.Windows.Input;
using FridaysTodoList.Models;
using FridaysTodoList.ServicesData;
using Xamarin.Forms;

namespace FridaysTodoList.ViewModels
{
    public class AddItemsViewModel : BaseViewModel
    {
        TodoInfo ex = new TodoInfo();
        public ICommand OnMoreItemsCommand { get; }
        public ICommand OnCancelCommand { get; }
        string new_items;
        NewItem yu;
        public AddItemsViewModel(NewItem arg)
        {
            yu = arg;
            OnMoreItemsCommand = new Command(AddMoreItems);
        }

        public string NewItems
        {
            get { return new_items; }
            set { new_items = value; OnPropertyChanged(); }
        }

        private async  void AddMoreItems()
        {
            if (String.IsNullOrEmpty(NewItems))
            {
                await Application.Current.MainPage.DisplayAlert("Alert ", "Please add a new item ", "OK");

            }
            else
            {
                var id = yu.ID;
                NewItem e = await ex.GetSelectedItem(id);
                // AditionalItem
                //e.AditionalItem = NewItems;

            }

        }
    }
}

