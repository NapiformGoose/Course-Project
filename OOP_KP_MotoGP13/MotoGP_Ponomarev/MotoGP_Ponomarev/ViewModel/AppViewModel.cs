using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.IO;


namespace MotoGP_Ponomarev
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<MotoGP> MotoGPCollectionVM { get; private set; }
        MotoGP selectedPilot;
        public MotoGP SelectedPilot
        {
            get { return selectedPilot; }
            set
            {
                selectedPilot = value;
                OnPropertyChanged("SelectedPilot");
            }
        }
       
        public AppViewModel()
        {       
            MotoGPCollectionVM = new ObservableCollection<MotoGP>();
        }

        public static void TextRepositoryCreate()
        {
            Singleton.Initialize(RepositoryType.text);
            Singleton.Instance.Repository.Reading();
            MotoGPCollectionVM.Clear();
            foreach (MotoGP mgp in TextRepository.CollectMotoGPText)
                MotoGPCollectionVM.Add(mgp);
        }
        public static void MemoryRepositoryCreate()
        {
            Singleton.Initialize(RepositoryType.memory);
            Singleton.Instance.Repository.Reading();
            MotoGPCollectionVM.Clear();
            foreach (MotoGP mgp in MemoryRepository.CollectMotoGPMemory)
                MotoGPCollectionVM.Add(mgp);
        }
        public static void BinaryRepositoryCreate()
        {
            Singleton.Initialize(RepositoryType.binary);
            Singleton.Instance.Repository.Reading();
            MotoGPCollectionVM.Clear();
            foreach (MotoGP mgp in BinaryRepository.CollectMotoGPBin)
                MotoGPCollectionVM.Add(mgp);
        }

        ExecutedCommand addCommand;
        public ExecutedCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new ExecutedCommand(obj =>
                    {
                        Singleton.Instance.Repository.Add();                    
                    }));
            }
        }
        
        ExecutedCommand removeCommand;
        public ExecutedCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new ExecutedCommand(obj =>
                    {
                        Singleton.Instance.Repository.Deletion(SelectedPilot);
                    },
                    (obj) => MotoGPCollectionVM.Count > 0));
            }
        }

        ExecutedCommand updateCommand;
        public ExecutedCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                    (updateCommand = new ExecutedCommand(obj =>
                    {
                        Singleton.Instance.Repository.Update();
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
