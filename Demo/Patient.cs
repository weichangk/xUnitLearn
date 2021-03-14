using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Patient: Person, INotifyPropertyChanged
    {
        public Patient()
        {
            this.IsNew = true;
            BloodSugar = 4.900003f;
            History = new List<string>();
        }

        public string FullName => $"{FirstName} {LastName}";
        public int HeartBeatRate { get; set; }
        public bool IsNew { get; set; }
        public float BloodSugar { get; set; }
        public List<string> History { get; set; }

        public void IncreaseHeartBeatRate()
        {
            this.HeartBeatRate = CalculateHeartBeatRate() + 2;
            OnPropertyChanged(nameof(HeartBeatRate));
        }
        public int CalculateHeartBeatRate()
        {
            var random = new Random();
            return random.Next(1, 100);
        }
        public void NotAllowed()
        {
            throw new InvalidOperationException("not able to create");
        }

        public event EventHandler<EventArgs> PatientSlept;

        public void OnPatientSleep()
        {
            PatientSlept?.Invoke(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //var handler = PropertyChanged;
            //if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
