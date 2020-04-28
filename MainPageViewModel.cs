using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace XamarinFormsApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private string nume = "Tamara";

        private ObservableCollection<Persoana> listaPersoane = new ObservableCollection<Persoana>();

      //  private bool visibility=false;

        #endregion

        
        #region Public Properties

        //public bool Visibility 
        //{
        //    get => visibility;
        //    set { 
        //          visibility = value;
        //        OnPropertyChanged("Visibility");
        //    }
        //}
        public ObservableCollection<Persoana> ListaPersoane 
        {
            get => listaPersoane;
            set 
            {
                listaPersoane = value;
                OnPropertyChanged("listaPersoane");
            }
        }

        public string Nume
        {
            get => nume;
            set
            {
                nume = value;
                OnPropertyChanged("Nume");
            }
        }

        #endregion

        #region
        public ICommand PressToShowFramePressedCommand { get; set; }
        public ICommand CloseFrameCommand { get; set; }
        #endregion

        public MainPageViewModel() 
        {

            PressToShowFramePressedCommand = new RelayCommand(ToFramePressed);
            CloseFrameCommand = new RelayCommand(CloseFrame);


            ListaPersoane.Add(new Persoana() { Prenume = "Vasilica" });
            ListaPersoane.Add(new Persoana() { Prenume = "Lili" });
            ListaPersoane.Add(new Persoana() { Prenume = "Marinela" });
            ListaPersoane.Add(new Persoana() { Prenume = "Niculina" });
            ListaPersoane.Add(new Persoana() { Prenume = "Adina" });
            ListaPersoane.Add(new Persoana() { Prenume = "Iosefina" });
            ListaPersoane.Add(new Persoana() { Prenume = "Cosmina" });
            ListaPersoane.Add(new Persoana() { Prenume = "Mireca" });
            ListaPersoane.Add(new Persoana() { Prenume = "Cinimini" });
            ListaPersoane.Add(new Persoana() { Prenume = "Cezar" });

        }


        public void ToFramePressed() 
        {
    
           // Visibility = true;
        }

        public void CloseFrame() 
        {
           // Visibility = false;
        }

    #region Implementare interfata INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#endregion

    }
}
