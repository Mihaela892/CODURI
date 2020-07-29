using MultiMediaPickerSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MultiMediaPickerSample.ViewModels
{
    
    public class FullImageViewModel
    {
        public ObservableCollection<MediaFile> Media1 { get; set; } = new ObservableCollection<MediaFile>();
        public FullImageViewModel() 
        {
            var bb = new MediaFile()
            {
                Path = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/IMG-20200725-WA0002_37.jpg",
                PreviewPath = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/IMG-20200725-WA0002-THUMBNAIL_37.jpg"
            };

            var cc = new MediaFile()
            {
                Path = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/IMG-20200724-WA0004_2.jpg",
                PreviewPath = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/IMG-20200724-WA0004-THUMBNAIL_2.jpg"
            };

            var dd = new MediaFile()
            {
                Path = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/20200718_104804_1.jpg",
                PreviewPath = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/20200718_104804-THUMBNAIL_1.jpg"
            };

            var ee = new MediaFile()
            {
                Path = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/20200714_171640.jpg",
                PreviewPath = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/20200714_171640-THUMBNAIL.jpg"
            };

            Media1.Add(bb);
            Media1.Add(cc);
            Media1.Add(dd);
            Media1.Add(ee);

        }
       
    }
}
