using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMed.Model
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Specialization { get; set; }
        public int Type { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public UserModel()
        { }

        public UserModel(DAL.UserSys user)
        {
            UserId = user.UserId;
            Name = user.FullName;
            Specialization = user.Specialization;
            Type = user.Type;
            Password = user.Password;
            Login = user.Login;
        }
        public ObservableCollection<RecordModel> Records { get; set; }
    }
}
