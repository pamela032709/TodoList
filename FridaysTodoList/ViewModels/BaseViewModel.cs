using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FridaysTodoList.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        #region PropertyChange
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Object.Equals(property, value))
            {
                property = value;
                OnPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public BaseViewModel()
        {
        }
    }
}
