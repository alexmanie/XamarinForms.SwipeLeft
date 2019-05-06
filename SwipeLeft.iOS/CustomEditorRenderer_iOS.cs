using System;
using SwipeLeft;
using SwipeLeft.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer_iOS))]
namespace SwipeLeft.iOS
{
    public class CustomEditorRenderer_iOS : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.BackgroundColor = Color.Transparent.ToUIColor();
                this.Control.ScrollEnabled = false;
                this.Control.Layer.CornerRadius = 10;
                this.Control.Layer.BorderColor = Color.FromRgb(139, 163, 176).ToCGColor();
                this.Control.ContentInset = new UIKit.UIEdgeInsets(10, 25, 10, 25);
                this.Control.InputAccessoryView = null;
            }
        }
    }
}