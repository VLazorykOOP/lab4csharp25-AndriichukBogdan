namespace Lab4Charp
{
    using System;

    internal class Program
    {
        class Point
        {
            private int x;
            private int y;
            private int c;

            public Point()
            {
                this.x = 0;
                this.y = 0;
                this.c = 0;
            }

            public Point(int dX, int dY, int color)
            {
                this.x = dX;
                this.y = dY;
                this.c = color;
            }

            public void getCords()
            {
                Console.WriteLine("X,Y = " + this.x + "," + this.y);
            }

            public double getDistance()
            {
                double distance = Math.Sqrt((x * x) + (y * y));
                Console.WriteLine("Distance = " + distance);
                return distance;
            }

            public void moveByVector(int x1, int y1)
            {
                Console.WriteLine("Old dot:" + this.x + "," + this.y);
                this.x += x1;
                this.y += y1;
                Console.WriteLine("New dot:" + this.x + "," + this.y);
            }

            public int X
            {
                get { return this.x; }
                set { this.x = value; }
            }

            public int Y
            {
                get { return this.y; }
                set { this.y = value; }
            }

            public int Color
            {
                get { return this.c; }
            }

            public int this[int i]
            {
                get
                {
                    if (i == 0) return x;
                    if (i == 1) return y;
                    if (i == 2) return c;
                    Console.WriteLine("Некоректний індекс!");
                    return -1;
                }
            }

            public static Point operator ++(Point n)
            {
                return new Point(n.x + 1, n.y + 1, n.c);
            }

            public static Point operator --(Point n)
            {
                return new Point(n.x - 1, n.y - 1, n.c);
            }

            public static bool operator true(Point n)
            {
                return n.x == n.y;
            }

            public static bool operator false(Point n)
            {
                return n.x != n.y;
            }

            public static Point operator +(Point n, Point m)
            {
                return new Point(n.x + m.x, n.y + m.y, n.c);
            }

            public static explicit operator string(Point p)
            {
                return p.x + "," + p.y + "," + p.c;
            }

            public static explicit operator Point(string s)
            {
                string[] parts = s.Split(',');
                int x = Convert.ToInt32(parts[0]);
                int y = Convert.ToInt32(parts[1]);
                int c = Convert.ToInt32(parts[2]);

                return new Point(x, y, c);
            }
        }

        static void Main(string[] args)
        {

            Point p1 = new Point(3, 4, 255);
            Point p2 = new Point(5, 5, 128);

            p1.getCords();
            p2.getCords();

            p1++;
            p1.getCords();
            p2--;
            p2.getCords();

            if (p1)
            {
                Console.WriteLine("p1 has equal x and y");
            }
            else
            {
                Console.WriteLine("p1 hasnt equal x and y");
            }

            Point p3 = p1 + p2;
            p3.getCords();

            Console.WriteLine("p1[0] = " + p1[0]);
            Console.WriteLine("p1[1] = " + p1[1]);
            Console.WriteLine("p1[2] = " + p1[2]);

            string strPoint = (string)p1;
            Console.WriteLine("Point to string: " + strPoint);

            Point p4 = (Point)"10,20,100";
            p4.getCords();
        }
    }
}
