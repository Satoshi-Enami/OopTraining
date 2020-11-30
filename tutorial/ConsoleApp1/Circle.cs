using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Circle : IShape
    {
        public double radius;

        public Circle(string radiuses)
        {
            double radius = double.Parse(radiuses);

            this.radius = radius;
        }

        public double CalcArea()
        {
            return (Math.Pow(this.radius,2) * Math.PI);
        }

    }
}
