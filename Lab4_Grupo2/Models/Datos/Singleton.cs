using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_Grupo2.Models;

namespace Lab4_Grupo2.Models.Datos
{
    public class Singleton
    {

        private static Singleton _instance = null;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null) _instance = new Singleton();
                return _instance;
            }
        }

    }
}
