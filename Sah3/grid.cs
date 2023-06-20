using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah3
{
    public class Grid
    {
        private Figura[,] _grid = new Figura[8, 8];

        public Figura[,] grid{
            get { return _grid; }
        }
        
        /// <summary>
        /// Dodaj figure na grid
        /// </summary>
        public void dodaj(int positionX, int positionY, String figura)
        {
            if(figura == "KRC")
            {
                //Pokliči razred kralj crn
            }
            if (figura == "KC")
            {
                //Pokliči razred kraljica crna
            }
            //Pokliči razred kmet crn
            if (figura == "KMC")
            {
                Kmet kmet = new Kmet(positionX, positionY, false);
                _grid[positionX, positionY] = kmet;
            }
            if (figura == "KOC")
            {
                //Pokliči razred konj crn
            }
            if (figura == "TEC")
            {
                //Pokliči razred tekac crn
            }
            if (figura == "TRC")
            {
                //Pokliči razred trdnjava crna
            }
            if (figura == "KRB")
            {
                //Pokliči razred kralj bel
            }
            if (figura == "KB")
            {
                //Pokliči razred kraljica bela
            }
            //Pokliči razred kmet bel
            if (figura == "KMB")
            {
                Kmet kmet = new Kmet(positionX, positionY, true);
                _grid[positionX, positionY] = kmet;

            }
            if (figura == "KOB")
            {
                //Pokliči razred konj bel
            }
            if (figura == "TEB")
            {
                //Pokliči razred tekač bel
            }
            if (figura == "TRB")
            {
                //Pokliči razred trdnjava bela
            }
        }
    }

}
