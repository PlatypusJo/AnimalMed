using AnimalMed.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AnimalMed.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Model.UserModel>? Doctors { get; set; }

        public UserViewModel()
        {
            Doctors = new ObservableCollection<Model.UserModel>();
            
                
        }
    }
}
