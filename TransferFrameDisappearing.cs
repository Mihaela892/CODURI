using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsApp.Triggers
{
    public class TransferFrameDisappearing : TriggerAction<View>
    {
        public string Target1 { get; set; }
        public string Target2 { get; set; }
        protected override void Invoke(View sender)
        {
            View hideMeFrame;
            Button showMeButton;
                     

            if (Target1 != null)
            {
                hideMeFrame = ((View)sender.Parent).FindByName<View>(Target1);

                showMeButton = ((ContentPage)sender.Parent.Parent).FindByName<Button>(Target2);
                if (hideMeFrame != null)
                {                
                    sender.IsVisible = false;
               
                    Animate(hideMeFrame,showMeButton);
                  
                }
               
            }          

        }

        public async void Animate(View view1, View view2)
        {
            //Pentru buton
            view2.IsVisible = true;
            view2.IsEnabled = false;

            //Pentru frame
            await view1.TranslateTo(80, 0, 200);
            
            view1.Opacity = 0;
            view1.IsVisible = false;
            view1.Opacity = 1;
            await Task.Delay(50);

            //Pt buton
            view2.IsEnabled = true;
           
        }
    }
}
