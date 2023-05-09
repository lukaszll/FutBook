using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutBookClassLibrary
{
    class clsPitch
    {        
        private int mPitchNo;
        private string mPitchName;
        public int PitchNo
        {
            get { return mPitchNo; }
            set { mPitchNo = value; }
        }

        public string PitchName
        {
            get { return mPitchName; }
            set { mPitchName = value; }
        }
    }
}
