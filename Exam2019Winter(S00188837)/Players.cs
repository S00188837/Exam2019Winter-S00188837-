using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2019Winter_S00188837_
{
    class Players
    {

        public enum PlayerType
        {
            Goalkeeper,
            Defender,
            Midfielder,
            Forward
        }

        public static Players[] players = new Players[]
        {
            
        };

        //properties
        public string Name { get; set; }
        public string Surname { get; set; }
        public PlayerType playerType { get; set; }
        private DateTime PlayerDate { get; set; }
        private int Age { get; set; }



        public Players(string name, string surname, DateTime date, PlayerType type)
        {
            Name = name;
            Surname = surname;
            PlayerDate = date; 
            playerType = type;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}({PlayerDate.ToShortDateString()}) {playerType}";
        }

        

    }
}
