using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    class Auto
    {

        public string Indulas { get; private set; }

        public string Cel { get; private set; }

        public string Rendszam { get; private set; }

        public string Telefonszam { get; private set; }

        public int Ferohely { get; private set; }


        public Auto(string szoveg)
        {
            string[] a = szoveg.Split(';');

            Indulas = a[0];
            Cel = a[1];
            Rendszam = a[2];
            Telefonszam = a[3];
            Ferohely = int.Parse(a[4]);
        }

    }
}
