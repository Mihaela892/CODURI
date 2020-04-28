using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsApp
{
    public class TriggerActionAnimation : TriggerAction<Button>
    {
        //public string Source { get; set; }
        public string Target { get; set; }
       
       
        protected override void Invoke(Button sender)
        {
            View showMe;
            if (Target != null)
            {
                 showMe = ((View)sender.Parent).FindByName<View>(Target);
                if (showMe != null) 
                {
                    showMe.IsVisible = true;
                    PerformAnimation(showMe);
                }           

            }
        }

        private async void PerformAnimation(View pShowMe)
        {
            await pShowMe.ScaleTo(1.05, 600, Easing.CubicIn);
            await pShowMe.ScaleTo(1, 600,Easing.CubicOut);
        }
    }
}
