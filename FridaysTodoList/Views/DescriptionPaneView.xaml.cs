using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FridaysTodoList.Views
{
    public partial class DescriptionPaneView : ContentView
    {
        public DescriptionPaneView()
        {
            InitializeComponent();
        }
        public string Text
        {
            get
            {
                return Description.Text;
            }
            set
            {
                Description.Text = value;
            }
        }
    }
}
