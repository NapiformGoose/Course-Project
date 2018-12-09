using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace MotoGP_Ponomarev
{ 
    public class TextRepository : IOperations
    {
        public static ObservableCollection<MotoGP> CollectMotoGPText = new ObservableCollection<MotoGP>();

        public void SaveChanges ()
        {
            StreamWriter streamWriter = new StreamWriter(@"./txtFiles/info.txt");
            int count = CollectMotoGPText.Count();
            for (int i = 0; i < count; i++)
            {
                streamWriter.Write
                    (CollectMotoGPText[i].PilotName + ";" +
                     CollectMotoGPText[i].TeamName + ";" +
                     CollectMotoGPText[i].Country + ";" +
                     CollectMotoGPText[i].PilotNumber + ";" +
                     CollectMotoGPText[i].MotoModel + ";");
                for (int j = 0; j < CollectMotoGPText[i].pilotInformGP.Count; j++)
                {
                    streamWriter.Write(CollectMotoGPText[i].pilotInformGP[j].PointGP + ";");

                }
                streamWriter.WriteLine();
            }
            streamWriter.Close();
        }

        public void Add()
        {
            CollectMotoGPText.Clear();
            foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                CollectMotoGPText.Add(mgp);
            SaveChanges();
        }
        public void Reading()
        {
            CollectMotoGPText.Clear();
            StreamReader streamReader = new StreamReader(@"./txtFiles/info.txt"); //reading the main information from info.txt
            int count = File.ReadAllLines(@"./txtFiles/info.txt").Length; //determine the number of the strings in file
            string temporaryString = ""; //the buffer string
            string[] temporaryArray = new string[10]; //the buffer array
            for (int i = 0; i < count; i++)
            {
                CollectMotoGPText.Add(new MotoGP());
                temporaryString = streamReader.ReadLine();
                temporaryArray = temporaryString.Split(';');
                Guid g = System.Guid.NewGuid();
                CollectMotoGPText[i].Guid = g;
                CollectMotoGPText[i].PilotName = temporaryArray[0];
                CollectMotoGPText[i].TeamName = temporaryArray[1];
                CollectMotoGPText[i].Country = temporaryArray[2];
                CollectMotoGPText[i].PilotNumber = Int32.Parse(temporaryArray[3]);
                CollectMotoGPText[i].MotoModel = temporaryArray[4];
                for (int j = 5; j < 10; j++) //filling of the list object Grand Prix 
                {
                    CollectMotoGPText[i].pilotInformGP.Add(new GrandPrix());
                    CollectMotoGPText[i].pilotInformGP[j-5].PointGP = temporaryArray[j];
                }
                
            }
            streamReader.Close();
  
            for (int i = 0; i < count; i++)
            {
                StreamReader GPReader = new StreamReader(@"./txtFiles/infoGrandPrix.txt"); //reading of the information from infoGrandPrix.txt 
                string GPString = ""; //the buffer string
                string[] GPArray = new string[2]; //the buffer array
                for (int j = 0; j < 5; j++)
                {
                    GPString = GPReader.ReadLine();
                    GPArray = GPString.Split(';');
                    CollectMotoGPText[i].pilotInformGP[j].NameGrandPrix = GPArray[0];
                    CollectMotoGPText[i].pilotInformGP[j].NameRaceGP = GPArray[1];
                }
                GPReader.Close();
            }
        }
        public void Update()
        {
            CollectMotoGPText.Clear();
            foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                CollectMotoGPText.Add(mgp);
            SaveChanges();
        }
        public void Deletion(MotoGP obj)
        {
            if (obj != null)
            {
                AppViewModel.MotoGPCollectionVM.Remove(obj);
                CollectMotoGPText.Clear();
                foreach (MotoGP mgp in AppViewModel.MotoGPCollectionVM)
                    CollectMotoGPText.Add(mgp);
                SaveChanges();
            }
        }
    }
}
