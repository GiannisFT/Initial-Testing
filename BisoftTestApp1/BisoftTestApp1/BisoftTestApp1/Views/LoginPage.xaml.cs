using ServiceReference1;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace BisoftTestApp1.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            txt_ucid.Text = Preferences.Get("UcidValue", null);
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        //public void PaintBackground()
        //{
        //    SKCanvasView canvasView = new SKCanvasView();
        //    canvasView.PaintSurface += OnCanvasViewPaintSurface;
        //    Content = canvasView;
        //}
        //void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        //{
        //    SKImageInfo info = args.Info;
        //    SKSurface surface = args.Surface;
        //    SKCanvas canvas = surface.Canvas;

        //    canvas.Clear();

        //    using (SKPaint paint = new SKPaint())
        //    {
        //        // Create gradient for background
        //        paint.Shader = SKShader.CreateLinearGradient(
        //                            new SKPoint(0, 0),
        //                            new SKPoint(info.Width, info.Height),
        //                            new SKColor[] { new SKColor(255, 255, 255),
        //                                        new SKColor(120, 120, 120) },
        //                            null,
        //                            SKShaderTileMode.Clamp);

        //        // Draw background
        //        canvas.DrawRect(info.Rect, paint);
        //    }
        //}

    }
}
