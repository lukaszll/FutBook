using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FutBookClassLibrary
{
    public class clsPitchCollection
    {
        private List<clsPitch> mPitchList = new List<clsPitch>();

        public clsPitchCollection()
        {
            // Populate the list of pitches here, assuming 10 pitches in total
            for (int i = 1; i <= 10; i++)
            {
                clsPitch pitch = new clsPitch();
                pitch.PitchNo = i;
                pitch.PitchName = "Pitch " + i.ToString();
                pitch.PitchAvailable = true;
                mPitchList.Add(pitch);
            }
        }

        public List<clsPitch> PitchList
        {
            get { return mPitchList; }
            set { mPitchList = value; }
        }
    }
}