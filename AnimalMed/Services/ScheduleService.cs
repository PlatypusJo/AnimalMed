using AnimalMed.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AnimalMed.Services
{
    internal class ScheduleService
    {
        VetclinicEntities db;

        public ScheduleService()
        {
            db = new VetclinicEntities();
        }

        public List<UserModel> GetDoctorsByDate(DateTime date)
        {
            var d = (from dr in db.UserSys
                     join sch in db.Schedule on dr.UserId equals sch.Doctor
                     join day in db.ScheduleDay on sch.ScheduleId equals day.Schedule
                     where dr.Type == 1 && day.Date == date
                     select new UserModel()
                     {
                         UserId = dr.UserId,
                         Login = dr.Login,
                         Password = dr.Password,
                         Name = dr.FullName,
                         Specialization = dr.Specialization,
                         Type = dr.Type,
                         //Records = new ObservableCollection<RecordModel>(GetDoctorRecords(dr.UserId))
                     }).ToList();
            foreach(UserModel doctor in d)
            {
                doctor.Records = new ObservableCollection<RecordModel>(GetDoctorRecords(date, doctor.UserId));
            }
            return d;
        }

        public List<UserModel> GetDoctorsBySpecialization(int s, ObservableCollection<UserModel> drs)
        {
            List<UserModel> userModels = drs.Where(d => (int)d.Specialization == s).ToList();
            return userModels;
        }

        private List<RecordModel> GetDoctorRecords(DateTime date, int DoctorId)
        {
            var r = (from rec in db.Record
                         //join day in db.ScheduleDay on rec.Day equals day.ScheduleDayId
                         //join sch in db.Schedule on day.Schedule equals sch.ScheduleId
                         //join dr in db.UserSys on sch.Doctor equals dr.UserId
                     join dr in db.UserSys on rec.Doctor equals dr.UserId
                     join day in db.ScheduleDay on rec.Day equals day.ScheduleDayId
                     where dr.UserId == DoctorId && day.Date == date
                     orderby rec.TimeVisit
                     select new RecordModel() 
                     { 
                         RecordId = rec.RecordId, 
                         Available = rec.Available, 
                         Day = rec.Day, 
                         Doctor = rec.Doctor,
                         Pet = rec.Pet, 
                         Service = rec.Service, 
                         TimeVisit = rec.TimeVisit, 
                         Visit = rec.Visit 
                     }).ToList();
            foreach (RecordModel record in r)
            {
                record.SetColor();
            }
            return r;
        }

        public List<SpecializationModel> GetAllSpecializations()
        {
            var sp = db.Specialization.Select(sp => new SpecializationModel() { SpecializationId = sp.SpecializationId, Name = sp.Name }).ToList();
            sp.Insert(0, new SpecializationModel() { SpecializationId = -1, Name = "Все" });
            return sp.ToList();
        }
    }
}
