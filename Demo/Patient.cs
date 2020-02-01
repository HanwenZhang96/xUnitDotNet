using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Demo
{
    public class Patient: Person, INotifyPropertyChanged
    {
        public Patient()
        {
            IsNew = true;
            BloodSugar = 4.9f;
            History = new List<string>();
        }


        public string FullName => $"{FirstName} {LastName}";
        public int HeartBeatRate { get; set; }
        public bool IsNew { get; set; }
        public float BloodSugar { get; set; }
        public List<string> History { get; set; }

        public event EventHandler<EventArgs> PatientSlept;
        public event PropertyChangedEventHandler PropertyChanged;

        // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void OnPatientSleeep()
        {
            PatientSlept?.Invoke(this, EventArgs.Empty);
        }
        public void Sleep()
        {
            OnPatientSleeep();
        }

        public void NotAllowed()
        {
            throw new InvalidOperationException("Not able to create");
        }

        public void IncreaseHeartBeatRate()
        {
            HeartBeatRate = CalculateHeartBeatRate() + 2;
            OnPropertyChanged(nameof(HeartBeatRate));
        }

        private int CalculateHeartBeatRate()
        {
            var random = new Random();
            return random.Next(1, 100);
        }
    }
}
