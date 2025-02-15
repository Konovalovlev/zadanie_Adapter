using System;

namespace zadanie_1
{
    public interface Adapter
    {
    }

    public class RoundHole
    {
        private int radius;

        public RoundHole(int radius)
        {
            this.radius = radius;
        }

        public int getRadius()
        {
            return radius;
        }

        public bool fits(RoundPeg peg)
        {
            return radius >= peg.getRadius();
        }
    }

    public class RoundPeg
    {
        private int radius;

        public RoundPeg(int radius)
        {
            this.radius = radius;
        }

        public virtual int getRadius()
        {
            return radius;
        }
    }

    public class SquarePeg
    {
        private int width;

        public SquarePeg(int width)
        {
            this.width = width;
        }

        public int getWidth()
        {
            return width;
        }
    }



    public class SquarePegAdapter : RoundPeg
    {
        private SquarePeg peg;

        public SquarePegAdapter(SquarePeg peg) : base(0)
        {
            this.peg = peg;
        }

        public override int getRadius()
        {
            return (int)(peg.getWidth() * Math.Sqrt(2) / 2);
        }
    }



    public class ConePegAdapter : RoundPeg
    {
        private RoundPeg peg;

        public ConePegAdapter(RoundPeg peg) : base(0)
        {
            this.peg = peg;
        }

        public override int getRadius()
        {
            return peg.getRadius();
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            //создать круглое отверстие с радиусом 
            RoundHole hole = new RoundHole(99);


            //создать круглая деталь с радиусом 
            RoundPeg roundPeg = new RoundPeg(48);
            Console.WriteLine(hole.fits(roundPeg));


            //создать квадратную деталь с шириной 
            SquarePeg squarePeg = new SquarePeg(40);
            SquarePegAdapter squarePegAdapter = new SquarePegAdapter(squarePeg);


            //проверка подходит ли квадрат адапт деталь к отверстию
            Console.WriteLine(hole.fits(squarePegAdapter));


            //создать адаптер круглой детали (ConePegAdapter)
            ConePegAdapter conePegAdapter = new ConePegAdapter(roundPeg);


            //проверка подходит ли круглая адапт деталь к отверстию
            Console.WriteLine(hole.fits(conePegAdapter));
        }
    }
}