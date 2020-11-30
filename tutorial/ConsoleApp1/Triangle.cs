using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Triangle :IShape
    {
        public double bottom;
        public double height;

        public Triangle(string bottoms, string heights)
        {
            double bottom = double.Parse(bottoms);
            double height = double.Parse(heights);

            this.bottom = bottom;
            this.height = height;
        }

        public double CalcArea()
        {
            return this.bottom * this.height / 2 ;
        }

    }
}
