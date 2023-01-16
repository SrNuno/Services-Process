using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class Caballo
    {
        private int position;
        bool flag = false;
        readonly object l = new object();
        int meta = 25;

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public void Run()
        {
            Random random = new Random();
            Position += random.Next(1, 5);
        }
    }
}
