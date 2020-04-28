using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsApp
{
    public class TriggerActionAnimationHide : TriggerAction<Button>
    {
        //public string Source { get; set; }
        public string Target { get; set; }
        protected override void Invoke(Button sender)
        {
            View hideMe;
            if (Target != null)
            {
                hideMe = ((View)sender.Parent).FindByName<View>(Target);
                if (hideMe != null)
                {                  
                    hideMe.IsVisible = false;
                    
                }


            }
        }

    }
}
