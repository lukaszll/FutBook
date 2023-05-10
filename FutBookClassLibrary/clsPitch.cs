using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutBookClassLibrary
{
    public class clsPitch
    {        
        private int mPitchNo;
        private string mPitchName;
        private bool mPitchAvailable;

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
        public bool PitchAvailable
        {
            get { return mPitchAvailable; }
            set { mPitchAvailable = value; }
        }
    }
}
