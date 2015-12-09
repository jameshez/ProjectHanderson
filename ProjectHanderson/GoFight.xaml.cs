using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectHanderson
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GoFight : Page
    {
        public GoFight()
        {
            this.InitializeComponent();

            //leftbox.ManipulationStarted += Leftbox_ManipulationStarted;
            //leftbox.ManipulationDelta += Leftbox_ManipulationDelta;

            leftbox.AddHandler(UIElement.ManipulationStartedEvent, 
                new ManipulationStartedEventHandler(Leftbox_ManipulationStarted), true);
            leftbox.AddHandler(UIElement.ManipulationDeltaEvent,
                new ManipulationDeltaEventHandler(Leftbox_ManipulationDelta), true);
        }

        private double position = 0;

        private void Leftbox_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            //throw new NotImplementedException();
            position = e.Position.Y;
            Debug.WriteLine("current position: {0}", position);
        }

        private void Leftbox_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            //throw new NotImplementedException();
            position = e.Position.Y;
            Debug.WriteLine("current position: {0}", position);

        }


        private void updatePosition(double position)
        {
            //bt.Margin.Left
        }

    }
}
