using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace MotoGP_Ponomarev
{
    public class MemoryRepository : IOperations
    {
        public static ObservableCollection<MotoGP> CollectMotoGPMemory = new ObservableCollection<MotoGP>();
        public void Add()
        {
            CollectMotoGPMemory.Clear();
            foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                CollectMotoGPMemory.Add(mgp);
        }
        public void Reading()
        {
            CollectMotoGPMemory.Clear();
            Guid g = Guid.NewGuid();
            CollectMotoGPMemory.Add(new MotoGP());
            CollectMotoGPMemory[0].PilotName = "Mika Kallio";
            CollectMotoGPMemory[0].TeamName = "Ducati Team";
            CollectMotoGPMemory[0].Country = "Japan";
            CollectMotoGPMemory[0].PilotNumber = 42;
            CollectMotoGPMemory[0].MotoModel = "Ducati Desmosedici GP17/GP16";
            CollectMotoGPMemory[0].Guid = g;
            CollectMotoGPMemory[0].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[0].pilotInformGP[0].NameGrandPrix = "Grand Prix Qatar";
            CollectMotoGPMemory[0].pilotInformGP[0].NameRaceGP = "Losail";
            CollectMotoGPMemory[0].pilotInformGP[0].PointGP = "8/8";
            CollectMotoGPMemory[0].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[0].pilotInformGP[1].NameGrandPrix = "Grand Prix Argentinian";
            CollectMotoGPMemory[0].pilotInformGP[1].NameRaceGP = "Termas de Rio Hondo";
            CollectMotoGPMemory[0].pilotInformGP[1].PointGP = "7/9";
            CollectMotoGPMemory[0].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[0].pilotInformGP[2].NameGrandPrix = "Grand Prix German";
            CollectMotoGPMemory[0].pilotInformGP[2].NameRaceGP = "Sachsenring";
            CollectMotoGPMemory[0].pilotInformGP[2].PointGP = "-/-";
            CollectMotoGPMemory[0].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[0].pilotInformGP[3].NameGrandPrix = "Grand Prix Spanish";
            CollectMotoGPMemory[0].pilotInformGP[3].NameRaceGP = "Circuito de Jerez";
            CollectMotoGPMemory[0].pilotInformGP[3].PointGP = "16/3";
            CollectMotoGPMemory[0].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[0].pilotInformGP[4].NameGrandPrix = "Grand Prix French";
            CollectMotoGPMemory[0].pilotInformGP[4].NameRaceGP = "Le Mans Circuit Bugatti";
            CollectMotoGPMemory[0].pilotInformGP[4].PointGP = "6/10";

            Guid g1 = Guid.NewGuid();
            CollectMotoGPMemory.Add(new MotoGP());
            CollectMotoGPMemory[1].PilotName = "Sylvain Guintoli";
            CollectMotoGPMemory[1].TeamName = "Movistar Yamaha MotoGP";
            CollectMotoGPMemory[1].Country = "Japan";
            CollectMotoGPMemory[1].PilotNumber = 24;
            CollectMotoGPMemory[1].MotoModel = "Yamaha YZR0M1 2018";
            CollectMotoGPMemory[1].Guid = g1;
            CollectMotoGPMemory[1].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[1].pilotInformGP[0].NameGrandPrix = "Grand Prix Qatar";
            CollectMotoGPMemory[1].pilotInformGP[0].NameRaceGP = "Losail";
            CollectMotoGPMemory[1].pilotInformGP[0].PointGP = "25/1";
            CollectMotoGPMemory[1].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[1].pilotInformGP[1].NameGrandPrix = "Grand Prix Argentinian";
            CollectMotoGPMemory[1].pilotInformGP[1].NameRaceGP = "Termas de Rio Hondo";
            CollectMotoGPMemory[1].pilotInformGP[1].PointGP = "11/5";
            CollectMotoGPMemory[1].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[1].pilotInformGP[2].NameGrandPrix = "Grand Prix German";
            CollectMotoGPMemory[1].pilotInformGP[2].NameRaceGP = "Sachsenring";
            CollectMotoGPMemory[1].pilotInformGP[2].PointGP = "-/-";
            CollectMotoGPMemory[1].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[1].pilotInformGP[3].NameGrandPrix = "Grand Prix Spanish";
            CollectMotoGPMemory[1].pilotInformGP[3].NameRaceGP = "Circuito de Jerez";
            CollectMotoGPMemory[1].pilotInformGP[3].PointGP = "20/2";
            CollectMotoGPMemory[1].pilotInformGP.Add(new GrandPrix());
            CollectMotoGPMemory[1].pilotInformGP[4].NameGrandPrix = "Grand Prix French";
            CollectMotoGPMemory[1].pilotInformGP[4].NameRaceGP = "Le Mans Circuit Bugatti";
            CollectMotoGPMemory[1].pilotInformGP[4].PointGP = "13/4";
        }
        public void Update()
        {
            CollectMotoGPMemory.Clear();
            foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                CollectMotoGPMemory.Add(mgp);
        }
        public void Deletion(MotoGP obj)
        {
            if (obj != null)
            {
                AppViewModel.MotoGPCollectionVM.Remove(obj);
                CollectMotoGPMemory.Clear();
                foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                    CollectMotoGPMemory.Add(mgp);
            }
        }
    }
}
