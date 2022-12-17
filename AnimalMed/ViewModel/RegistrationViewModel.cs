using AnimalMed.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMed.ViewModel
{
    internal class RegistrationViewModel : INotifyPropertyChanged
    {
        private static RegistrationViewModel _instance = new RegistrationViewModel();
        public static RegistrationViewModel Instance => _instance;
        public RegistrationViewModel()
        {
            SelectedDoctor = ScheduleViewModel.Instance.SelectedDoctor;
        }

        private UserModel _selectedDoctor;
        public UserModel SelectedDoctor
        {
            get
            {
                return _selectedDoctor;
            }
            set
            {
                _selectedDoctor = value;
            }
        }

        private string _selectedDoctorSpecialization;
        public string SelectedDoctorSpecialization
        {
            get
            {
                return _selectedDoctorSpecialization;
            }
            set
            {
                _selectedDoctorSpecialization = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
