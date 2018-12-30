using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Traveler
{
    class Program
    {
        static Point koordinat = new Point();
        static void Main(string[] args)
        {
            
            #region takeKoordinat
          
        koordinat:
            Console.Write("Sağ üst koordinatı giriniz.");
            string koor = Console.ReadLine();
            if (koor.Length == 3)
            {
                if (char.IsNumber(koor[0]) && char.IsNumber(koor[2]))
                {
                    koordinat.X = int.Parse(koor.Substring(0, 1));
                    koordinat.Y = int.Parse(koor.Substring(2, 1));
                }
                else
                {
                    Console.WriteLine("Uygun formatta koordinat bilgisi girilmelidir.(X Y)");
                    goto koordinat;
                }
            }
            else
            {
                Console.WriteLine("Uygun formatta koordinat bilgisi girilmelidir.(X Y)");
                goto koordinat;
            }
            #endregion

            #region rob1

            Robotic rob1 = getKonum("1");
        kat1:
            Console.WriteLine("1. robot için harf katarını giriniz");
            char[] katar1 =(Console.ReadLine().ToUpper()).ToCharArray();
            if (checkKatar(katar1) == false)
                goto kat1;
            #endregion

            #region rob2
            Robotic rob2 = getKonum("2");
        kat2:
            Console.WriteLine("2. robot için harf katarını giriniz");
            char[] katar2 =( Console.ReadLine().ToUpper()).ToCharArray();
            if (checkKatar(katar2) == false)
                goto kat2;
            #endregion


            #region output
            rob1 = output(katar1, rob1);
            rob2 = output(katar2, rob2);
            Console.WriteLine("1. robotun son konumu ve yönü:" + rob1.loc.p.X + " " + rob1.loc.p.Y + " " + rob1.dir.d);
            Console.WriteLine("2. robotun son konumu ve yönü:" + rob2.loc.p.X + " " + rob2.loc.p.Y + " " + rob2.dir.d); 
            #endregion
            Console.ReadKey();

        }

        #region methods
        private static bool checkKatar(char[] katar)
        {
            bool ret = false;
            foreach (var item in katar)
            {
                if (item == 'L' || item == 'R' || item == 'M')
                {
                    ret = true;
                }
                else
                {
                    Console.WriteLine("Harf katarı L R M dışında komut içermemelidir.");
                    ret = false;
                    break;
                }

            }
            return ret;
        }

        private static Robotic output(char[] katar, Robotic rob)
        {
            foreach (var item in katar)
            {
                if (item == 'L' || item == 'R')
                    rob.dir.d = Direction.findDirection(item, rob.dir.d);
                else if (item == 'M')
                {
                    rob.loc.p = Location.move(rob.dir.d, rob.loc.p);
                    //Koordinat dışına çıkmasını engellemek için;
                    if (rob.loc.p.Y > koordinat.Y)
                        rob.loc.p = new Point(rob.loc.p.X, koordinat.Y);
                    if (rob.loc.p.X > koordinat.X)
                        rob.loc.p = new Point(koordinat.X, rob.loc.p.Y);
                    if (rob.loc.p.X < 0)
                        rob.loc.p = new Point(0, rob.loc.p.Y);
                    if (rob.loc.p.Y < 0)
                        rob.loc.p = new Point(rob.loc.p.X, 0);
                }

            }
            return rob;
        }

        private static Robotic getKonum(string number)
        {
        rob:
            Console.WriteLine(number + ". robotun ilk konumunu giriniz.");
            string rob = Console.ReadLine();
            Robotic robotic = new Robotic();
            if (rob.Length == 5)
            {
                if (char.IsNumber(rob[0]) && char.IsNumber(rob[2]))
                    robotic.loc = new Location { p = new Point(int.Parse(rob.Substring(0, 1)), int.Parse(rob.Substring(2, 1))) };
                else
                {
                    Console.WriteLine("Uygun formatta koordinat bilgisi girilmelidir.(X Y (N E W S))");
                    goto rob;
                }

                robotic.dir = new Direction { d = char.Parse(rob.Substring(4, 1).ToUpper()) };
                if (robotic.dir.d == 'N' || robotic.dir.d == 'W' || robotic.dir.d == 'S' || robotic.dir.d == 'E')
                { }
                else
                {
                    Console.WriteLine("Uygun formatta koordinat bilgisi girilmelidir.(X Y (N E W S))");
                    goto rob;
                }
            }
            else
            {
                Console.WriteLine("Uygun formatta koordinat bilgisi girilmelidir.(X Y (N E W S))");
                goto rob;
            }
            return robotic;
        } 
        #endregion
    }
}
