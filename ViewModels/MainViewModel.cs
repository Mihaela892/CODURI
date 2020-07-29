using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using MultiMediaPickerSample.MessageModels;
using MultiMediaPickerSample.Models;
using MultiMediaPickerSample.Services;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace MultiMediaPickerSample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        IMultiMediaPickerService _multiMediaPickerService;
       
        public ObservableCollection<MediaFile> Media { get; set; }

       // public ObservableCollection<MediaFile> Media1 { get; set; } = new ObservableCollection<MediaFile>();

        public ObservableCollection<FourMediaFileModel> MediaToBeGrouped { get; set; } = new ObservableCollection<FourMediaFileModel>();

        //public ObservableCollection<Message> MessageList { get; set; }

        private string numberOfHiddenPhotos;

        public string NumberOfHiddenPhotos
        {
            get { return numberOfHiddenPhotos; }
            set {
                numberOfHiddenPhotos = value;
                
                OnPropertyChanged();
            } 
        }

      


        public ICommand PageAppearingCommand { get; set; }
        public ICommand PageDisappearingCommand { get; set; }
        public ICommand SelectImagesCommand { get; set; }
        public ICommand SelectVideosCommand { get; set; }
        public ICommand ShowFullImageCommand { get; set; }

        public MainViewModel( IMultiMediaPickerService multiMediaPickerService)
        {
            //Am nevoie de un singur element in lista, pentru

            numberOfHiddenPhotos = "+0";


            var aa = new FourMediaFileModel()
            {
                Path1 = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/IMG-20200725-WA0002_37.jpg",
                PreviewPath1 = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/IMG-20200725-WA0002-THUMBNAIL_37.jpg",

                Path2 = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/IMG-20200724-WA0004_2.jpg",
                PreviewPath2 = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/IMG-20200724-WA0004-THUMBNAIL_2.jpg",

                Path3 = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/20200718_104804_1.jpg",
                PreviewPath3 = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/20200718_104804-THUMBNAIL_1.jpg",

                Path4 = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/20200714_171640.jpg",
                PreviewPath4 = "/data/user/0/com.crossgeeks.MultiMediaPickerSample/files/TmpMedia/20200714_171640-THUMBNAIL.jpg"
            };
           

            MediaToBeGrouped.Add(aa);


          

            ShowFullImageCommand = new Command(ShowFullImage);


            _multiMediaPickerService = multiMediaPickerService;

            //PageAppearingCommand = new Command(PageAppearing);
            //PageDisappearingCommand = new Command(PageDisappearing);

        SelectImagesCommand = new Command(async (obj) =>
            {
                var hasPermission = await CheckPermissionsAsync();
                if (hasPermission)
                {
                    Media = new ObservableCollection<MediaFile>();
                    await _multiMediaPickerService.PickPhotosAsync();
                }
            });

            SelectVideosCommand = new Command(async (obj) =>
            {
                var hasPermission = await CheckPermissionsAsync();
                if (hasPermission)
                {

                    Media = new ObservableCollection<MediaFile>();

                    await _multiMediaPickerService.PickVideosAsync();

                }
            });

            _multiMediaPickerService.OnMediaPicked += (s, a) =>
            {
                
                //Device.BeginInvokeOnMainThread(() =>
                //{
                    Media.Add(a);

                //});

               // MediaToBeGrouped.Add(a);
            };
        }

        //private void PageAppearing() 
        //{
            
        //}

        //private void PageDisappearing() 
        //{
        //   // MediaToBeGrouped = Media;
        //    //Ar trebui grupate mesajele imagini in numar de peste 4 doar daca sunt consecutive, gen, daca intre ele mai intervin si alte mesaje, nu.
        //    //Exemplu: 2 imagini, mesaj text, 2 imagini - NUUU
        //}

        private async void ShowFullImage()        {
           
        }

        async Task<bool> CheckPermissionsAsync()
        {
            var retVal = false;
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Storage))
                    {
                        await App.Current.MainPage.DisplayAlert("Alert","Need Storage permission to access to your photos.","Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Plugin.Permissions.Abstractions.Permission.Storage });
                    status = results[Plugin.Permissions.Abstractions.Permission.Storage];
                }

                if (status == PermissionStatus.Granted)
                {
                    retVal = true;

                }
                else if (status != PermissionStatus.Unknown)
                {
                    await App.Current.MainPage.DisplayAlert("Alert","Permission Denied. Can not continue, try again.","Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                await App.Current.MainPage.DisplayAlert("Alert", "Error. Can not continue, try again.", "Ok");
            }

            return retVal;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
