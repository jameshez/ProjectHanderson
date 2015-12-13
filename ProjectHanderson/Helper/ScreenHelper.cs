using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace ProjectHanderson.Helper
{
    static class ScreenHelper
    {

        public static Size CurrentScreenSize()
        {
            Size screen = new Size();

            screen.Width = Window.Current.Bounds.Width;
            screen.Height = Window.Current.Bounds.Height;

            return screen;
        }

    }
}
