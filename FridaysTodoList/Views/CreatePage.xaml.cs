﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FridaysTodoList.Views
{
    public partial class CreatePage : ContentPage
    {
        bool isExpanded = true;
        Rectangle expandedRect; // bounds for expanded image view
        Rectangle detailsRect;  // bounds for details image view

        public CreatePage()
        {
            InitializeComponent();
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (isExpanded)
                AnimateIn();
            else
                AnimateOut();

            isExpanded = !isExpanded;
        }

        private void AnimateIn()
        {
            MainImage.LayoutTo(detailsRect, 1200, Easing.SpringOut);
            BottomFrame.TranslateTo(0, 0, 1200, Easing.SpringOut);
            Title.TranslateTo(0, 0, 1200, Easing.SpringOut);
            ExpandBar.FadeTo(.01, 250, Easing.SinInOut);
        }

        private void AnimateOut()
        {
            MainImage.LayoutTo(expandedRect, 1200, Easing.SpringOut);
            BottomFrame.TranslateTo(0, BottomFrame.Height, 1200, Easing.SpringOut);
            Title.TranslateTo(-Title.Width, 0, 1200, Easing.SpringOut);
            ExpandBar.FadeTo(1, 250, Easing.SinInOut);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            detailsRect = new Rectangle(0, 0, width, BottomFrame.Bounds.Top + 20);
            expandedRect = new Rectangle(0, 0, width, height);

            if (isExpanded)
            {
                MainImage.Layout(expandedRect);
                BottomFrame.TranslationY = BottomFrame.Height;
                Title.TranslationX = -Title.Width;
            }
            else
            {
                MainImage.Layout(detailsRect);
                BottomFrame.TranslationY = 0;
                Title.TranslationX = 0;
            }
        }
    }
}
