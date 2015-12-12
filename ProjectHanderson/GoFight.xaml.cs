using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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

            //leftpanel.AddHandler(UIElement.ManipulationStartedEvent, 
            //    new ManipulationStartedEventHandler(Leftbox_ManipulationStarted), true);

            //leftpanel.AddHandler(UIElement.ManipulationDeltaEvent,
            //    new ManipulationDeltaEventHandler(Leftbox_ManipulationDelta), true);

            //Debug.WriteLine("current position: {0}", position);

            //leftpanel.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
        }

       
        private double position = 0;

        private void Leftbox_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            position = e.Position.X;
            Debug.WriteLine("current position Delta: {0}", position);

            updatePosition(position);
        }

        private void Leftbox_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            position = e.Position.X;
            Debug.WriteLine("current position Start: {0}", position);
        }


        private void updatePosition(double position)
        {
            ////bt.Margin.Left
            //Thickness currentpos = bt.Margin;
            //currentpos.Left = position;
            //bt.Margin = currentpos;
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            //var bounds = Window.Current.Bounds;
            //var width = bounds.Width;

            //Thickness currentpos = bt.Margin;
            //currentpos.Left = e.NewValue / 120 * width;
            //bt.Margin = currentpos;

            
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            this.myWidget.RemoveFromVisualTree();
            this.myWidget = null;
        }

        CanvasSolidColorBrush redBrush;





        async void myWidget_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            var bitmapTiger = await CanvasBitmap.LoadAsync(sender, "Images/card.jpg");
            args.DrawingSession.DrawImage(bitmapTiger);
        }

    }
}
