//======================================================================
// Class: MySparse2DMatrix
// Author: Dario Vogogna
// Date: November 2015
//======================================================================

namespace HMM_Solve
{
    public class MySparse2DMatrix : Sparse2DMatrix<int, int, double>
    {

        public MySparse2DMatrix() : base(0.0)
        {
        }

        public double getValue(int row, int col)
        {
            return this[row, col];
        }

        public void setValue(int row, int col, double newValue)
        {
            this[row, col] = newValue;
        }
    }
}
