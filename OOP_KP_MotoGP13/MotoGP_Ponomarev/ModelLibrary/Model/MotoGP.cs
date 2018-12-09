using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;


namespace MotoGP_Ponomarev
{
    [Serializable]
    public class MotoGP : INotifyPropertyChanged //main class 
    {  
        Guid guid;
        string pilotName; 
        string teamName; 
        string country; 
        int pilotNumber; 
        string motoModel; 
        public List<GrandPrix> pilotInformGP = new List<GrandPrix>();

        public Guid Guid
        {
            get { return guid; }
            set
            {
                guid = value;
            }
        }
        public string PilotName
        {
            get { return pilotName; }
            set
            {
                pilotName = value;
                OnPropertyChanged("NamePilot");
            }
        }
        public string TeamName
        {
            get { return teamName; }
            set
            {
                teamName = value;
                OnPropertyChanged("NameTeam");
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }
        public int PilotNumber
        {
            get { return pilotNumber; }
            set
            {
                pilotNumber = value;
                OnPropertyChanged("NumberPilot");
            }
        }
        public string MotoModel
        {
            get { return motoModel; }
            set
            {
                motoModel = value;
                OnPropertyChanged("ModelMoto");
            }
        }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs (property));
        }
    }
}
