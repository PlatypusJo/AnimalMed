using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.ComponentModel.DataAnnotations;

namespace AnimalMed.Model
{
    public class RecordModel
    {
        public RecordModel()
        { }
        public RecordModel(DAL.Record record)
        {
            RecordId = record.RecordId;
            TimeVisit = record.TimeVisit;
            Available = record.Available;
            Doctor = record.Doctor;
            Service = record.Service;
            Visit = record.Visit;
            Pet = record.Pet;
            Day = record.Day;
            if (record.Available)
            {
                ColorRecord = new SolidColorBrush(Color.FromRgb(130, 247, 13));
            }
            else
            {
                ColorRecord = new SolidColorBrush(Color.FromRgb(217, 84, 77));
            }
        }
        public int RecordId { get; set; }
        public Brush ColorRecord { get; set; }
        public System.TimeSpan TimeVisit { get; set; }
        public bool Available { get; set; }
        public int Doctor { get; set; }
        public Nullable<int> Service { get; set; }
        public Nullable<int> Visit { get; set; }
        public Nullable<int> Pet { get; set; }
        public int Day { get; set; }
        public void SetColor()
        {
            if (Available)
            {
                ColorRecord = new SolidColorBrush(Color.FromRgb(130, 247, 13));
            }
            else
            {
                ColorRecord = new SolidColorBrush(Color.FromRgb(217, 84, 77));
            }
        }
    }
}
