using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hik.NDist.Manager.MainTree
{
    public static class TreeviewHelper
    {
        public static object CreateHeader(string text, string bitmapImage)
        {
            var sp = new StackPanel { Orientation = Orientation.Horizontal, Height = 16, Margin = new Thickness(2) };

            var img = new Image
                          {
                              Source = new BitmapImage(new Uri(bitmapImage, UriKind.Relative)),
                              Height = 16,
                              Width = 16
                          };
            sp.Children.Add(img);

            var lbl = new Label
            {
                Content = text,
                Margin = new Thickness(0),
                Padding = new Thickness(5,0,0,0)
            };
            sp.Children.Add(lbl);

            return sp;
        }
    }
}