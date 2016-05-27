//======================================================================
// Class: Id2Str
// Author: Dario Vogogna
// Date: November 2015
//======================================================================

using System.Collections.Generic;

namespace HMM_Solve
{
    public class Id2Str
    {
        private Dictionary<int, string> strIdRelation;

        public Id2Str()
        {
            strIdRelation = new Dictionary<int, string>();
        }

        /// <summary>
        ///     Gets the number of symbols in the alphabet of this model.
        /// </summary>
        public int Symbols
        {
            get { return strIdRelation.Count; }
        }
        /// <summary>
        ///     Return the state label corresponding to the id given
        /// </summary>
        public string getStr(int id)
        {
            string _value;
            if (strIdRelation.TryGetValue(id, out _value))
                return _value;

            return null;
        }

        /// <summary>
        ///     Return the id corresponding to the state label given
        /// </summary>
        public int getId(string str)
        {
            foreach (var item in strIdRelation)
            {
                if (item.Value == str)
                    return item.Key;
            }

            return -1;
        }

        /// <summary>
        ///     Creates a new element if it is not present and returns the index.
        /// </summary>
        public int setId(string str)
        {
            int count = 0;
            foreach (var item in strIdRelation)
            {
                if (item.Value == str)
                    return item.Key;

                count++;
            }

            strIdRelation[count] = str;
            return count;
        }
    }
}