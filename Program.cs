using System;
using System.Collections.Generic;
using System.Linq;

namespace HegyekMo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region init
            string FILENAME = "bukk-videk.txt";
            DataHandler data = new DataHandler(FILENAME);
            List<Mountain> mountainList = data.getProcessedData();
            Util util = new Util(mountainList);
            #endregion

            #region 3. feladat
            Console.WriteLine("3. feladat: Hegycsúcsok száma: " + mountainList.Count());
            #endregion

            #region 4. feladat
            Console.WriteLine("4. feladat: Hegycsúcsok átlagos magassága: " + util.AvgHeight());
            #endregion

            #region 5 .feladat
            Console.WriteLine("5. feladat: A legmagasabb hegycsúcs adatai: ");
            Mountain highest = util.GetHighestMountain();
            Console.WriteLine("\tNév:  " + highest.getName());
            Console.WriteLine("\tHegység:  " + highest.getMountains());
            Console.WriteLine("\tMagasság: "+highest.getHeight()+" m");
            #endregion

            #region 6 .feladat
            bool isCountinue;
            uint number = 0;
            do
            {
                Console.Write("6. feladat: Kérek egy magasságot: ");
                isCountinue = true;

                try
                {
                    number = uint.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    isCountinue = false;

                }
            } while (!isCountinue);

            Console.Write(util.IsHigherInBörzsöny(number) ? "\tVan ":"\tNincs ");
            Console.WriteLine(number + "m - nél magasabb hegycsúcs a Börzsönyben");
            #endregion

            #region 7. feladat
            Console.WriteLine("7. feladat: 3000 lábnál magasabb hegycsúcsok száma: " + util.NumberOfThreeThousandHighs());
            #endregion

            #region 8. feladat
            Console.WriteLine("8. feladat: Hegység statisztika");
            util.WriteOutStat();
            #endregion

            #region 9. feladat
            Console.WriteLine("9. feladat: "+ FILENAME);
            List<Mountain> mountainsToFile = util.prepareToFile();
            data.writeToFile(mountainsToFile);
            #endregion

            Console.ReadKey();
        }  
    }
}
