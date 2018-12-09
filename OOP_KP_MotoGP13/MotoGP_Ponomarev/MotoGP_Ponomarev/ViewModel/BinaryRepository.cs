using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.ObjectModel;

namespace MotoGP_Ponomarev
{
    
   class BinaryRepository : IOperations
    {
        public static ObservableCollection<MotoGP> CollectMotoGPBin = new ObservableCollection<MotoGP>();

        public void SaveChanges()
        {
            List<MotoGP> gPs = new List<MotoGP>(); //the buffer list
            foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                gPs.Add(mgp);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStram = new FileStream(@"./binFiles/binInfo.dat", FileMode.OpenOrCreate)) //serialization and writing in the binary file
            {
                binaryFormatter.Serialize(fileStram, gPs);
            }
        }
        public void Add()
        {
            CollectMotoGPBin.Clear();
            foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                CollectMotoGPBin.Add(mgp);
            SaveChanges();
        }
        public void Reading() 
        {
            //SaveChanges(); //if necessary, create a new binary file - run the method "SaveChanges" and comment on the code below
            CollectMotoGPBin.Clear();
            BinaryFormatter binaryFormatter = new BinaryFormatter();        
            using (FileStream fileStream = new FileStream(@"./binFiles/binInfo.dat", FileMode.OpenOrCreate)) //deseralization and reading for the binary file
            {
                List<MotoGP> deserilizeMotoGP = (List<MotoGP>)binaryFormatter.Deserialize(fileStream);

                foreach (MotoGP mGP in deserilizeMotoGP)
                {
                    CollectMotoGPBin.Add(new MotoGP
                    {
                        Guid = mGP.Guid,
                        PilotName = mGP.PilotName,
                        TeamName = mGP.TeamName,
                        Country = mGP.Country,
                        PilotNumber = mGP.PilotNumber,
                        MotoModel = mGP.MotoModel,
                        pilotInformGP = mGP.pilotInformGP
                    }); 
                }
            }  
        }
        public void Update()
        {
            CollectMotoGPBin.Clear();
            foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                CollectMotoGPBin.Add(mgp);
            SaveChanges();
        }
        public void Deletion(MotoGP obj)
        {
            if (obj != null)
            {
                AppViewModel.MotoGPCollectionVM.Remove(obj);
                CollectMotoGPBin.Clear();
                foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                    CollectMotoGPBin.Add(mgp);
                SaveChanges();
            }
        }
    }
}
