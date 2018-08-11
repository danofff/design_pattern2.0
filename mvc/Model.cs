using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc
{
    class Model
    {
        private int Result;
        public void addTwoNumbers(int first, int second)
        {
            Result = first + second;
        }

        public int getResult()
        {
            return Result;
        }
    }
}
