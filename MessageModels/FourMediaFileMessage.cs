using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MultiMediaPickerSample.MessageModels
{
    public class FourMediaFileMessage
    {
       ObservableCollection<string> Paths { get; set; }
       ObservableCollection<string> PreviewPaths { get; set; }


    }
}
