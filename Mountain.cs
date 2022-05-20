using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HegyekMo
{
    class Mountain
    {

        private string name;
        private string mountains;
        private int height;
        private double heightInFeet;

        public Mountain()
        {
        }

        public string getName()
        {
            return name;
        }

        public string getMountains()
        {
            return mountains;
        }

        public int getHeight()
        {
            return height;
        }

        public double getHeightInFeet()
        {
            return heightInFeet;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setMountains(string mountains)
        {
            this.mountains = mountains;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public void setHeightInFeet(double heightInFeet)
        {
            this.heightInFeet = heightInFeet;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
