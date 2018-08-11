using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc
{
    class Controller
    {
        private MainWindow View;
        private Model Model;

        public Controller(MainWindow view, Model model)
        {
            View = view;
            Model = model;
        }

        public void Execute()
        {
            Model.addTwoNumbers(View.getFirst(), View.getSecond());
            View.SetSolution(Model.getResult());
        }
    }
}
