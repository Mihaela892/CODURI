using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MultiMediaPickerSample.MessageModels
{
    public class OneMediaFileMessage
    {
        public string Path { get; set; }
        public string PreviewPath { get; set; }
    }
}
