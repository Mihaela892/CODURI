using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsApp.Triggers
{
    public class TransferFrameAppearing : TriggerAction<View>
    {
        public string Target1 { get; set; }
        public string Target2 { get; set; }
        protected override void Invoke(View sender)
        {
            View showMeFrame;
            Button showMeButton;
            //ContentPage page;         

           

            if (Target1 != null) 
            {
                showMeFrame = ((View)sender.Parent).FindByName<View>(Target1);
                
                 showMeButton = ((ContentPage)sender.Parent.Parent).FindByName<Button>(Target2);
                if (showMeFrame != null)
                {

                    sender.IsVisible = false;

                    Animate(showMeFrame, showMeButton);

                    ////FadeIn Entrance
                    //showMe.Opacity = 0;
                    //showMe.FadeTo(1, 3000);

                }
              
            }
            
        }
        public async void Animate(View view1, View view2) 
        {
            //Pentru buton
            view2.IsVisible = true;
            view2.IsEnabled = false;

            //Pentru frame
            view1.IsVisible = true;
            view1.Opacity = 0;          
            await view1.TranslateTo(80,0, 200);

            view1.Opacity = 1;
            await view1.TranslateTo(0, 0, 200);

            await Task.Delay(50);

            //Pt buton
            view2.IsEnabled = true;
        }
    }
}
