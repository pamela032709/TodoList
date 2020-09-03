using System;
using System.Windows.Input;
using FridaysTodoList.Models;
using FridaysTodoList.ServicesData;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace FridaysTodoList.ViewModels
{
    public class EditViewModel : BaseViewModel
    {
        TodoInfo ex = new TodoInfo();
        public ICommand OnUpdateCommand { get; }
        public ICommand OnCancelCommand { get; }
        string new_name;
        NewItem yu;
        public EditViewModel(NewItem arg)
        {
            yu = arg;
            OnUpdateCommand = new Command(Update);
            OnCancelCommand = new Command(Cancel);
        }

        private async void Cancel()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        public string NewName
        {
            get { return new_name; }
            set { new_name = value; OnPropertyChanged(); }
        }



        private async void Update()
        {
            if (String.IsNullOrEmpty(NewName))
            {
                await Application.Current.MainPage.DisplayAlert("Alert ", "Please add a new title ", "OK");

            }
            else
            {
                
                var id = yu.ID;
                

                NewItem e = await ex.GetSelectedItem(id);
                e.ItemName = NewName;
                 
                var list = ex.Update(e);
                await Application.Current.MainPage.DisplayAlert("Awsome! ", "Title has been updated ", "OK");
                await PopupNavigation.Instance.PopAsync();


            }
        }
    }
}
