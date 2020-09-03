using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FridaysTodoList.Models;
using FridaysTodoList.ServicesData;
using FridaysTodoList.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FridaysTodoList.ViewModels
{
    public class TitleViewModel : BaseViewModel
    {

        #region Properties

        public ICommand AddCommand { get; }
        public ICommand OnSaveCommand { get; }
        public ICommand OnUpdateCommand { get; }
        public ICommand OnCancelCommand { get; }
        string _today, notavailable, _date, _title, _name, _notes, _location, new_name;
        bool _usemylocation, _isdone;
        int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        public string Today
        {
            get { return _today; }
            set { _today = value; OnPropertyChanged(); }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
       

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; OnPropertyChanged(); }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; OnPropertyChanged(); }
        }

        public bool Done
        {
            get { return _isdone; }
            set { _isdone = value; OnPropertyChanged(); }
        }
        public bool UseLocation
        {
            get { return _usemylocation; }
            set { _usemylocation = value; OnPropertyChanged(); }
        }



        private DateTime bookingDate;
        public DateTime BookingDate
        {
            get { return bookingDate; }
            set
            {
                bookingDate = value;
                OnPropertyChanged("BookingDate");
            }
        }
        #endregion

       

        public TitleViewModel()
        {
            Title = "New event";
            AddCommand = new Command(AddList);
            BookingDate = DateTime.UtcNow;
            Today = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            OnSaveCommand = new Command(SaveCommand);
           // OnUpdateCommand = new Command(Update);
        }
        TodoInfo ex = new TodoInfo();
       

        private async void SaveCommand()
        {
            if (String.IsNullOrEmpty(Name))
            {
                await Application.Current.MainPage.DisplayAlert("Alert ", "Please add a name ", "OK");

            }
            else
            {

                if (UseLocation)
                {
                    try
                    {
                        var location = await Geolocation.GetLastKnownLocationAsync();
                        
                            if (location != null)
                            {
                                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                                var placemark = placemarks?.FirstOrDefault();
                                notavailable = "It seems that part(s) of your selected address is not available.Lucky for us we have google .";
                                if (placemarks != null)
                                {
                                   Location = $"{placemark.FeatureName ?? notavailable}-{placemark.Locality ?? notavailable },{placemark.SubAdminArea ?? notavailable}.";
                                }

                             }

                        Location = "Location not available at this time";

                    }
                    catch (FeatureNotSupportedException fnsEx)
                    {
                        return;   
                    }
                   
                }
                NewItem e = new NewItem()
                {
                    ItemName = this.Name,
                    ItemNotes = this.Notes,
                    IsDone = this.Done,
                    Date = this.BookingDate.Date,
                    UserLocation = this.Location,
                    


                };

                TodoInfo ex = new TodoInfo();
                var list = ex.SaveItems(e);
               
                
                await Application.Current.MainPage.DisplayAlert("Amazing! ", "List saved!! ", "OK");
                //await Application.Current.MainPage.Navigation.PushAsync(new MainNavigationPage());
                await App.Current.MainPage.Navigation.PopAsync();
                App.NotificationVm.BindData(true);


            }

        }

        async void AddList(object obj)
        {
             await Application.Current.MainPage.Navigation.PushAsync(new TodoPage(Title));
           
        }

      
    }
}

