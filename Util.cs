using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HegyekMo
{
    class Util
    {
        
        List<Mountain> listOfMountains;

        public Util(List<Mountain> listOfMountains)
        {
            this.listOfMountains = listOfMountains;
        }

        DataHandler dataHandler = new DataHandler();

        public double AvgHeight()
        {
            double avg = 0;

            foreach (Mountain m in listOfMountains)
            {
                avg += m.getHeight();
            }
            avg /= listOfMountains.Count();
            return avg;
        }
        public Mountain GetHighestMountain()
        {
            Mountain mountain = listOfMountains[0];

            foreach (Mountain m in listOfMountains)
            {
                if(m.getHeight() > mountain.getHeight())
                {
                    mountain = m;
                }
            }

            return mountain;
        }
        public bool IsHigherInBörzsöny(uint high)
        {
            bool result = false; 
            foreach (Mountain m in listOfMountains)
            {
                if(m.getMountains().Equals("Börzsöny")
                    && m.getHeight() > high)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public int NumberOfThreeThousandHighs()
        {
            int sum = 0;
            foreach (Mountain m in listOfMountains)
            {
                if (ConvertToFeet(m.getHeight()) > 3000)
                {
                    sum++;
                }
            }
            return sum;

        }
        private double ConvertToFeet(int meter)
        {
            return meter * 3.280839895;
        }
        public void WriteOutStat()
        {
            HashSet<string> uniqueNames = new HashSet<string>();

            foreach (Mountain m in listOfMountains)
            {
                uniqueNames.Add(m.getMountains());
            }

            int count = 0;
            foreach (String n in uniqueNames)
            {
                foreach (Mountain m in listOfMountains)
                {
                    if (m.getMountains().Equals(n))
                    {
                        count++;
                    }
                }
                Console.WriteLine("\t" + n + " - " + count + " db");
                count = 0;
            }
        }

        public List<Mountain> prepareToFile()
        {

            List<Mountain> res = new List<Mountain>();
            foreach (Mountain m in listOfMountains)
            {
                if(m.getMountains().Equals("Bükk-vidék"))
                {
                    Mountain mountain = m;
                    m.setHeightInFeet(Math.Round(ConvertToFeet(m.getHeight()),1));
                    res.Add(m);
                }
            }

            return res;
        }

    }
}
