using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_16._02
{
    class Program
    {
        #region Зад 1
        struct Vector
        {
            public int x;
            public int y;
            public int z;
            public Vector(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public void Show() => Console.WriteLine($"X: {x}\nY: {y}\nZ: {z}\n");
            public void MultNum(int a)
            {
                x *= a;
                y *= a;
                z *= a;
            }
            public void SumVector(Vector b)
            {
                this.x += b.x;
                this.y += b.y;
                this.z += b.z;
            }
            public void SubVector(Vector b)
            {
                this.x -= b.x;
                this.y -= b.y;
                this.z -= b.z;
            }
        }
        #endregion

        #region Зад 2
        struct Dec
        {
            public int num;
            public Dec(int num) => this.num = num;
            public int Get()
            {
                return this.num;
            }
            public int ToBin()
            {
                int bin = 0, k = 1;
                while (Convert.ToBoolean(num))
                {
                    bin += (num % 2) * k;
                    k *= 10;
                    num /= 2;
                }
                return bin;
            }
            public int ToOct()
            {
                int count = 1, k = 1;
                int copy_num = num;
                while (num > 7)
                {
                    count++;
                    copy_num /= 8;
                }
                int buf = 0;
                for (int i = 0; i < count - 1; i++)
                {
                    buf += (num % 8) * k;
                    k *= 10;
                    num /= 8;
                }
                return buf;
            }
            public int ToSixt()
            {
                string buf = Convert.ToString(num, 16).ToUpper();
                return Convert.ToInt32(buf);
            }
        }
        #endregion

        #region Зад 3
        struct RGB
        {
            public int red;
            public int green;
            public int blue;
            public RGB(int red, int green, int blue)
            {
                this.red = red;
                this.green = green;
                this.blue = blue;
            }
            public void ToHSL()
            {
                float _R = (red / 255f);
                float _G = (green / 255f);
                float _B = (blue / 255f);

                float _Min = Math.Min(Math.Min(_R, _G), _B);
                float _Max = Math.Max(Math.Max(_R, _G), _B);
                float _Delta = _Max - _Min;

                float H = 0;
                float S = 0;
                float L = (float)((_Max + _Min) / 2.0f);

                if (_Delta != 0)
                {
                    if (L < 0.5f)
                    {
                        S = (float)(_Delta / (_Max + _Min));
                    }
                    else
                    {
                        S = (float)(_Delta / (2.0f - _Max - _Min));
                    }


                    if (_R == _Max)
                    {
                        H = (_G - _B) / _Delta;
                    }
                    else if (_G == _Max)
                    {
                        H = 2f + (_B - _R) / _Delta;
                    }
                    else if (_B == _Max)
                    {
                        H = 4f + (_R - _G) / _Delta;
                    }
                }
                Console.WriteLine($"{H}\n{S}\n{L}");
            }
            public void ToHEX()
            {
                Console.WriteLine("{0:X2}{1:X2}{2:X2}\n", red, green, blue);
            }
            public void ToCMYK()
            {
                double dr = (double)red / 255;
                double dg = (double)green / 255;
                double db = (double)blue / 255;
                double k = 1 - Math.Max(Math.Max(dr, dg), db);
                double c = (1 - dr - k) / (1 - k);
                double m = (1 - dg - k) / (1 - k);
                double y = (1 - db - k) / (1 - k);
                Console.WriteLine($"{c:F1}\n{m:F1}\n{y:F1}\n{k:F1}\n");
            }

        }
        #endregion

        static void Main(string[] args)
        {
            Vector vector = new Vector(2, 3, 4);
            vector.MultNum(2);
            vector.Show();
            Vector vector1 = new Vector(5, 6, 7);
            vector1.SumVector(vector);
            vector1.Show();
            Console.WriteLine();
            Dec dec = new Dec(31);
            int bin = dec.ToBin();
            int oct = dec.ToOct();
            int sixt = dec.ToOct();
            Console.WriteLine(bin + "\n" + oct + "\n" + sixt + "\n");
            RGB rgb = new RGB(255, 122, 0);
            rgb.ToHSL();
            rgb.ToHEX();
            rgb.ToCMYK();
        }
        
    }
}
