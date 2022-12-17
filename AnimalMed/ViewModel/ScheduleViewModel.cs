using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using AnimalMed.Commands;
using AnimalMed.Model;
using AnimalMed.Services;

namespace AnimalMed.ViewModel
{
    internal class ScheduleViewModel : INotifyPropertyChanged
    {
        
        private readonly ScheduleService _scheduleService = new ScheduleService();
        private static ScheduleViewModel _instance = new ScheduleViewModel();
        public static ScheduleViewModel Instance => _instance;
        
        public ScheduleViewModel()
        {
            Specializations = new ObservableCollection<SpecializationModel>(_scheduleService.GetAllSpecializations());
            SelectedDate = DateTime.Now.Date;
        }

        public ObservableCollection<UserModel> Doctors { get; set; }
        public ObservableCollection<SpecializationModel> Specializations { get; set; }

        private DateTime _selectedDate;
        public DateTime SelectedDate 
        { 
            get => _selectedDate; 
            set => _selectedDate = value; 
        }

        private SpecializationModel _selectedSpecialization;
        public SpecializationModel SelectedSpecialization
        { 
            get => _selectedSpecialization; 
            set => _selectedSpecialization = value; 
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

        private RelayCommand _findDoctorsCommand;
        public RelayCommand FindDoctorsCommand => _findDoctorsCommand ??
                  (_findDoctorsCommand = new RelayCommand(obj =>
                  {
                      FindDoctorsAndRecords();
                  }));

        public void FindDoctorsAndRecords()
        {
            if (SelectedDate.ToString() != null)
            {
                Doctors = new ObservableCollection<UserModel>(_scheduleService.GetDoctorsByDate(SelectedDate));
            }
            if (SelectedSpecialization.SpecializationId != -1 && Doctors != null)
            {
                Doctors = new ObservableCollection<UserModel>(_scheduleService.GetDoctorsBySpecialization(SelectedSpecialization.SpecializationId, Doctors));
            }
            OnPropertyChanged(nameof(Doctors));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
