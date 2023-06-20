using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sah3
{
    public class Kmet : Figura
    {
        private int _positionX;
        private int _positionY;
        string[] kill;
        private bool _bela;
        private String _ime;

        /// <summary>
        /// pozicija X
        /// </summary>
        public int PositionX
        {
            get { return _positionX; }
        }

        /// <summary>
        /// pozicija Y
        /// </summary>
        public int PositionY
        {
            get { return _positionY; }
        }

        /// <summary>
        /// Barva kmeta
        /// </summary>
        public bool Bela
        {
            get { return _bela; }
        }

        /// <summary>
        /// ime figure
        /// </summary>
        public String Ime
        {
            get { return _ime; }
        }

        public Kmet(int positionX, int positionY, bool bela)
        {
            _positionX = positionX;
            _positionY = positionY;
            _bela = bela;

            if (bela)
            {
                kill = new string[] { "kc", "kmc", "koc", "tec", "trc" };
                _ime = "kmb";
                
            }
            else
            {
                kill = new string[] { "kb", "kmb", "kob", "teb", "trb"};
                _ime = "kmc";
            }
            
        }

        /// <summary>
        /// Preverimo ali lahko prestavimo kmeta in če ga lahko to tudi storimo
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="arr"></param>
        /// <returns>Vrnemo tabelo bool. Prvi indeks pove ali se lahko prestavimo. Drugi indeks pa, če smo pojedli katero figuro.</returns>
        public bool[] Prestavi(int positionX, int positionY, int newPositionX, int newPositionY, String[][] arr)
        {
            //Preverimo, ali smo šli izven polja
            if (newPositionX > 7 || newPositionX < 0 || newPositionY < 0 || newPositionY > 7)
            {
                return new bool[] { false, false };
            }

            //Preverimo ali se kmet lahko premakne na dano pozicijo BELA
            if (Bela)
            {
                //Ali se kmet lahko premakne za dve polji ali eno naprej
                if ((newPositionY - 2 == positionY) || (newPositionY - 1 == positionY && arr[newPositionX][newPositionY] == ""))
                {
                    return new bool[] { true, false };
                }

                //Ali kmet lahko poje figuro 
                if ((newPositionY - 1 == positionY && (newPositionX - 1 == positionX || newPositionX + 1 == positionX)) && kill.Contains(arr[newPositionX][newPositionY]))
                {
                    _positionX = positionX;
                    _positionY = positionY;
                    return new bool[] { true, true };
                }
            }
            //Isto za ČRNEGA
            else
            {
                if ((newPositionY + 2 == positionY) || (newPositionY + 1 == positionY && arr[newPositionX][newPositionY] == ""))
                {
                    return new bool[] { true, false };
                }

                if (newPositionY + 1 == positionY && (newPositionX - 1 == positionX || newPositionX + 1 == positionX) && kill.Contains(arr[newPositionX][newPositionY]))
                {
                    _positionX = positionX;
                    _positionY = positionY;
                    return new bool[] { true, true };
                }
            }
            return new bool[] { false, false };
        }
    }
}
