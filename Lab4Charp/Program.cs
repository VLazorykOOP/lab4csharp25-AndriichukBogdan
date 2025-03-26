namespace Lab4Charp
{
    using System;

    internal class Program
    {
        /*
            Перше завдання
        */
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

        /*
            Друге завдання 
        */
        class VectorInt
        {
            protected int[] IntArray;
            protected uint size;
            protected int codeError;
            protected static uint num_vec = 0;

            public VectorInt()
            {
                this.size = 1;
                this.IntArray = new int[this.size];
                this.IntArray[0] = 0;
                num_vec++;
            }

            public VectorInt(uint size)
            {
                this.size = size;
                this.IntArray = new int[this.size];
                for (int i = 0; i < this.size; i++)
                {
                    this.IntArray[i] = 0;
                }
                num_vec++;
            }

            public VectorInt(uint size, int value)
            {
                this.size = size;
                this.IntArray = new int[this.size];
                for (int i = 0; i < this.size; i++)
                {
                    this.IntArray[i] = value;
                }
                num_vec++;
            }

            ~VectorInt()
            {
                Console.WriteLine("Vector deleted.");
            }

            public void EnterElements()
            {
                Console.WriteLine("Enter " + this.size + " elements:");
                for (int i = 0; i < this.size; i++)
                {
                    this.IntArray[i] = Convert.ToInt32(Console.ReadLine());
                }
            }

            public void PrintElements()
            {
                Console.Write("Vector: ");
                for (int i = 0; i < this.size; i++)
                {
                    Console.Write(this.IntArray[i] + " ");
                }
                Console.WriteLine();
            }

            public void AssignValue(int value)
            {
                for (int i = 0; i < this.size; i++)
                {
                    this.IntArray[i] = value;
                }
            }

            public static uint CountVectors()
            {
                return num_vec;
            }

            public uint Size
            {
                get { return this.size; }
            }

            public int CodeError
            {
                get { return this.codeError; }
                set { this.codeError = value; }
            }

            public int this[int i]
            {
                get
                {
                    if (i >= 0 && i < this.size) return this.IntArray[i];
                    Console.WriteLine("Invalid index!");
                    return 0;
                }
                set
                {
                    if (i >= 0 && i < this.size) this.IntArray[i] = value;
                    else this.codeError = -1;
                }
            }

            public static VectorInt operator ++(VectorInt v)
            {
                for (int i = 0; i < v.size; i++) v.IntArray[i]++;
                return v;
            }

            public static VectorInt operator --(VectorInt v)
            {
                for (int i = 0; i < v.size; i++) v.IntArray[i]--;
                return v;
            }

            public static bool operator true(VectorInt v)
            {
                if (v.size == 0) return false;
                for (int i = 0; i < v.size; i++)
                    if (v.IntArray[i] != 0) return true;
                return false;
            }

            public static bool operator false(VectorInt v)
            {
                if (v.size == 0) return true;
                for (int i = 0; i < v.size; i++)
                    if (v.IntArray[i] != 0) return false;
                return true;
            }

            public static bool operator !(VectorInt v)
            {
                return v.size == 0;
            }

            public static VectorInt operator ~(VectorInt v)
            {
                for (int i = 0; i < v.size; i++) v.IntArray[i] = ~v.IntArray[i];
                return v;
            }

            public static VectorInt operator +(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        result.IntArray[i] = v1.IntArray[i] + v2.IntArray[i];

                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator +(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] + scalar;
                return result;
            }
            public static VectorInt operator -(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        result.IntArray[i] = v1.IntArray[i] - v2.IntArray[i];
                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator -(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] - scalar;
                return result;
            }
            public static VectorInt operator *(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        result.IntArray[i] = v1.IntArray[i] * v2.IntArray[i];

                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator *(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] * scalar;
                return result;
            }
            public static VectorInt operator /(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        if (v2.IntArray[i] != 0) result.IntArray[i] = v1.IntArray[i] / v2.IntArray[i];
                        else result[i] = 0;
                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator /(VectorInt v, int scalar)
            {
                if (scalar == 0) return new VectorInt(v.size, 0);
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] / scalar;
                return result;
            }
            public static VectorInt operator %(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        if (v2.IntArray[i] != 0) result.IntArray[i] = v1.IntArray[i] % v2.IntArray[i];
                        else result[i] = 0;
                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator %(VectorInt v, int scalar)
            {
                if (scalar == 0) return new VectorInt(v.size, 0);
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] % scalar;
                return result;
            }
            public static VectorInt operator |(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        result.IntArray[i] = v1.IntArray[i] | v2.IntArray[i];

                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator |(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] | scalar;
                return result;
            }
            public static VectorInt operator ^(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        result.IntArray[i] = v1.IntArray[i] ^ v2.IntArray[i];

                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator ^(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] ^ scalar;
                return result;
            }
            public static VectorInt operator &(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        result.IntArray[i] = v1.IntArray[i] & v2.IntArray[i];

                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator &(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] & scalar;
                return result;
            }
            public static VectorInt operator >>(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        result.IntArray[i] = v1.IntArray[i] >> v2.IntArray[i];

                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator >>(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] >> scalar;
                return result;
            }
            public static VectorInt operator <<(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    VectorInt result = new VectorInt(v1.size);
                    for (int i = 0; i < v1.size; i++)
                        result.IntArray[i] = v1.IntArray[i] << v2.IntArray[i];

                    return result;
                }
                else
                {
                    Console.WriteLine("Error array isnt the same lenght!");
                    return new VectorInt(v1.size, 0);
                }
            }

            public static VectorInt operator <<(VectorInt v, int scalar)
            {
                VectorInt result = new VectorInt(v.size);
                for (int i = 0; i < v.size; i++)
                    result.IntArray[i] = v.IntArray[i] << scalar;
                return result;
            }


            public static bool operator ==(VectorInt v1, VectorInt v2)
            {
                if (v1.size != v2.size) return false;
                for (int i = 0; i < v1.size; i++)
                    if (v1.IntArray[i] != v2.IntArray[i]) return false;
                return true;
            }

            public static bool operator !=(VectorInt v1, VectorInt v2)
            {
                return !(v1 == v2);
            }

            public static bool operator >(VectorInt v1, VectorInt v2)
            {
                if (v1.size == v2.size)
                {
                    int count = 0;
                    for (int i = 0; i < v1.size; i++) if (v1.IntArray[i] >= v2.IntArray[i]) count++;
                    return count > (v1.size / 2);
                }
                return v1.size > v2.size;
            }

            public static bool operator <(VectorInt v1, VectorInt v2)
            {
                return !(v1 > v2);
            }
            public static bool operator >=(VectorInt v1, VectorInt v2)
            {
                return (v1 > v2) || (v1 == v2);
            }
            public static bool operator <=(VectorInt v1, VectorInt v2)
            {
                return (v1 < v2) || (v1 == v2);
            }
        }

        static void Main(string[] args)
        {
            void task1()
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

            void task2()
            {
                Console.WriteLine("Test VectorInt:");

                VectorInt v1 = new VectorInt(3, 10);
                VectorInt v2 = new VectorInt(3, 5);

                v1.PrintElements();
                v2.PrintElements();

                VectorInt v3 = v1 + v2;
                v3.PrintElements();

                v3 = v1 - v2;
                v3.PrintElements();

                v3 = v1 * v2;
                v3.PrintElements();

                v3 = v1 / v2;
                v3.PrintElements();

                v3 = v1 % v2;
                v3.PrintElements();

                v3 = v1 | v2;
                v3.PrintElements();

                v3 = v1 ^ v2;
                v3.PrintElements();

                v3 = v1 & v2;
                v3.PrintElements();

                v3 = v1 >> 1;
                v3.PrintElements();

                v3 = v1 << 1;
                v3.PrintElements();

                v1++;
                v1.PrintElements();

                v2--;
                v2.PrintElements();

                if (v1 == v2)
                {
                    Console.WriteLine("v1 equal v2");
                }

                if (v1 > v2)
                {
                    Console.WriteLine("v1 greater than v2");
                }

                if (v1 < v2)
                {
                    Console.WriteLine("v1 less than v2");
                }

                if (v1 >= v2)
                {
                    Console.WriteLine("v1 greater or equal v2");
                }

                if (v1 <= v2)
                {
                    Console.WriteLine("v1 less or equal v2");
                }

                Console.WriteLine("~v1:");
                v3 = ~v1;
                v3.PrintElements();

                if (v1)
                {
                    Console.WriteLine("v1 true");
                }


                if (!v1)
                {
                    Console.WriteLine("!v1");
                }

                Console.WriteLine("Кількість векторів: " + VectorInt.CountVectors());
            }

            void choose_task()
            {
                Console.Write("1. Point\n2. VectorInt\n");
                int answer = Convert.ToInt16(System.Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        {
                            task1();
                            Console.Write("\n\n\n");
                            choose_task();
                            break;
                        }
                    case 2:
                        {
                            task2();
                            Console.Write("\n\n\n");
                            choose_task();
                            break;
                        }
                    default:
                        {
                            choose_task();
                            break;
                        }
                }
            }
            choose_task();

        }
    }
}
