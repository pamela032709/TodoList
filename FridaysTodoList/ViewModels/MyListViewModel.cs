using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using FridaysTodoList.Models;
using FridaysTodoList.ServicesData;
using FridaysTodoList.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace FridaysTodoList.ViewModels
{
    public class MyListViewModel : BaseViewModel
    {
        TodoInfo ex = new TodoInfo();
        ObservableCollection<NewItem> _listData = new ObservableCollection<NewItem>();
        public ObservableCollection<NewItem> ListData
        {
            get { return _listData; }
            set { _listData = value; OnPropertyChanged(); }
        }

        string _count;
        public string Count
        {
            get { return _count; }
            set { _count = value; OnPropertyChanged(); }
        }

        bool _isdone;
        public TextDecorations Decoration
        {
            get
            {
                return  TextDecorations.Strikethrough;
            }
            
        }


        public ICommand EditItem
        {
            get
            {
                return new Command<NewItem>(async(arg) =>
                {
                    try
                    {
                        if (arg != null)
                        {
                          
                            await AskOkCancel(arg);
                            
                           // BindData(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Debug.Write(ex);
                    }

                });
            }
        }

        public static async Task<bool> AskOkCancel(NewItem arg)
        {
            //await Application.Current.MainPage.DisplayAlert("Amazing! ", "List saved!! ", "OK");
            var result = await Application.Current.MainPage.DisplayActionSheet("What would you like to do", "Cancel", null, "Edit Title", "Add Items", "Mark as done");
            switch (result)
            {
                case "Cancel":

                    // Do Something when 'Cancel' Button is pressed

                    break;

                case "Edit Title":


                  await  PopupNavigation.Instance.PushAsync(new EditPage(arg));
                    // ex.UpdateSelectedName(name);

                    // Do Something when 'Button1' Button is pressed

                    break;

                case "Mark as done":

                    
                    // Do Something when 'Button2' Button is pressed

                    break;
                case "Add Items":

                    await PopupNavigation.Instance.PushAsync(new AddItemsPage(arg));
                    // Do Something when 'Button3' Button is pressed

                    break;

            }

            return true;
        }

        

       

        public ICommand DeleteCommand
        {
            get
            {
                return new Command<NewItem>((arg) =>
                {
                    try
                    {
                        if (arg != null)
                        {
                            ex.DeleteItem(arg);
                             BindData(false);
                        }
                    }
                    catch (Exception ex)
                    {
                       // Debug.Write(ex);
                    }

                });
            }
        }

        public  void BindData(bool showBadge = true)
        {
            try
            {
                /// Retrive notifications from Local DB
                ///  TodoInfo ex = new TodoInfo();
                //var list = ex.SaveItems(e);
                

                var DisplayData = ex.GetAllNotification();
                if (DisplayData != null && DisplayData.Result.Count > 0)
                {
                    ListData = new ObservableCollection<NewItem>(DisplayData.Result);
                }
                else
                {
                    ListData = new ObservableCollection<NewItem>();
                }

                if (!showBadge)
                {
                    RemoveBadege();
                    return;
                }

                switch (ListData.Count)
                {
                    case 0:
                        Count = null;
                        break;
                    case 1:
                        Count = "1";
                        break;
                    case 2:
                        Count = "2";
                        break;
                    default:
                        Count = "2+";
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        public void RemoveBadege()
        {
            Count = null;
        }

        public MyListViewModel()
        {
           
        }
    }
}
