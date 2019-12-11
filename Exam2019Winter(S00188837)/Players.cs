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
        public DateTime PlayerDate { get; set; }
        public int Age { get; set; }


        

    }
}
