using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsApp.Triggers
{
    public class PressButton : TriggerAction<View>
    {
       
        protected override void Invoke(View sender)
        {
            Animate(sender);
        }
        private async void Animate(View view) 
        {
            await view.ScaleTo(0.90, 280);
            await view.ScaleTo(1, 280);
        }
    }
   
}
