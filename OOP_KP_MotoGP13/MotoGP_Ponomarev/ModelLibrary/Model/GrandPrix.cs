using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP_Ponomarev
{
    [Serializable]
    public class GrandPrix //information about the Grand Prix
    {
        //string nameGrandPrix = "";
        //string nameRaceG = "";
        //int positionGP;

        public string NameGrandPrix { get; set; } //название Гран При
        public string NameRaceGP { get; set; } //навзвание трассы на которой проходит Гран При
        public string PointGP { get; set; } //очки пилота в Гран При
    }
}
