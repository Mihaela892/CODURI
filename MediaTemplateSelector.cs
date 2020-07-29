using MultiMediaPickerSample.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MultiMediaPickerSample
{
    public class MediaTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OneMediaFileMessageTemplate { get; set; }
        public DataTemplate FourMediaFileMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is MediaFile) return FourMediaFileMessageTemplate;
            else return FourMediaFileMessageTemplate;

        }
    }
}
