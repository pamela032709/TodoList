using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FridaysTodoList.Views
{
    public partial class ExpandBarView : ContentView
    {
        public ExpandBarView()
        {
            InitializeComponent();
        }
        public bool IsLabelVisible
        {
            get { return ExpandLabel.IsVisible; }
            set { ExpandLabel.IsVisible = value; }

        }
    }
}
