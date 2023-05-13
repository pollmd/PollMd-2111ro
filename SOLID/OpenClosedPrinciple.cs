using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public abstract class Shape 
    {
        public abstract double Area();
    }

    public class Rectangle: Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double Area()
        {
            return Height * Width;
        }
    }

    public class Circle: Shape
    {
        public double Radius { get; set; }

        public override double Area()
        {
            return 2 * Math.PI * Radius;
        }
    }

    public class AreaCalculator
    {
        public double TotalArea(Shape[] arrShapes)
        {
            double area=0;

            foreach(var obj in arrShapes)
            {
                area += obj.Area();
            }

            return area;
        }
    }
}
