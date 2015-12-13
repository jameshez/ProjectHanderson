using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
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
            Offset = (float)(e.NewValue / 100 * (Window.Current.Bounds.Width- bitmapTiger.Size.Width));
            myWidget.Invalidate();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            this.myWidget.RemoveFromVisualTree();
            this.myWidget = null;
        }

        CanvasSolidColorBrush redBrush;


        private float Offset
        {
            get
            {
                return offsetWidth;
            }
            set
            {
                offsetWidth = (float)value;
            }
        }


        async void myWidget_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            ////var bitmapTiger = await CanvasBitmap.LoadAsync(sender, "Images/card.jpg");
            ////args.DrawingSession.DrawImage(bitmapTiger);
            //if (count % 2 == 0)
            //{
            //    args.DrawingSession.DrawImage(blur1);

            //}
            //else
            //{
            //    args.DrawingSession.DrawImage(blur);
            //}
            //count++;
            
            args.DrawingSession.DrawImage(bitmapTiger,Offset,0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //CanvasDevice device = CanvasDevice.GetSharedDevice();
            //float height = 600;
            //float width = 600;
            //CanvasRenderTarget offscreen = new CanvasRenderTarget(device, width, height, 96);

            //using (CanvasDrawingSession ds = offscreen.CreateDrawingSession())
            //{
            //    ds.Clear(Colors.FloralWhite);
            //    ds.DrawImage(blur);
            //}
            


        }

        int count = 0;
        GaussianBlurEffect blur;
        GaussianBlurEffect blur1;
        private async void myWidget_CreateResources(CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {

            bitmapTiger = await CanvasBitmap.LoadAsync(sender, "Monster/1.png");
            bitmapTiger1 = await CanvasBitmap.LoadAsync(sender, "Monster/2.png");
            //CanvasCommandList cl = new CanvasCommandList(sender);
            //using (CanvasDrawingSession clds = cl.CreateDrawingSession())
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        clds.DrawText("Hello, World!", RndPosition(), Color.FromArgb(255, RndByte(), RndByte(), RndByte()));
            //        clds.DrawCircle(RndPosition(), RndRadius(), Color.FromArgb(255, RndByte(), RndByte(), RndByte()));
            //        clds.DrawLine(RndPosition(), RndPosition(), Color.FromArgb(255, RndByte(), RndByte(), RndByte()));
            //    }
            //}

            //blur = new GaussianBlurEffect()
            //{
            //    Source = cl,
            //    BlurAmount = 10.0f
            //};

            //blur1 = new GaussianBlurEffect()
            //{
            //    Source = cl,
            //    BlurAmount = 0.0f
            //};

        }

        Random rnd = new Random();
        private float offsetWidth;
        private CanvasBitmap bitmapTiger;
        private CanvasBitmap bitmapTiger1;

        private Vector2 RndPosition()
        {
            double x = rnd.NextDouble() * 500f;
            double y = rnd.NextDouble() * 500f;
            return new Vector2((float)x, (float)y);
        }

        private float RndRadius()
        {
            return (float)rnd.NextDouble() * 150f;
        }

        private byte RndByte()
        {
            return (byte)rnd.Next(256);
        }
    }
}
