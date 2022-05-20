using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HegyekMo
{
    class DataHandler
    {

        private string filename;
        private string[] data = File.ReadAllLines("hegyekMo.txt");

        public DataHandler()
        {
        }

        public DataHandler(string filename)
        {
            this.filename = filename;
        }

        public List<Mountain> getProcessedData()
        {
            List<Mountain> result = new List<Mountain>();

            string[] splittedData;
            for (int i = 1; i < data.Length; i++)
            {
                Mountain template = new Mountain();
                splittedData = data[i].Split(';');

                template.setName(splittedData[0]);
                template.setMountains(splittedData[1]);
                template.setHeight(int.Parse(splittedData[2]));

                result.Add(template);
            }

            return result;
        }

        public void writeToFile( List<Mountain> mountains)
        {
            StreamWriter sw = new StreamWriter(filename, false,Encoding.Default);
            sw.WriteLine("Hegycsúcs neve;Magasság láb");
            foreach(Mountain m in mountains)
            {
                sw.WriteLine(m.getName() + ";" + replaceCommaToDot(m.getHeightInFeet()));
            }
            sw.Close();
        }

        private string replaceCommaToDot(double fraction)
        {
            return fraction.ToString().Replace(',', '.');
        }
    }
}
