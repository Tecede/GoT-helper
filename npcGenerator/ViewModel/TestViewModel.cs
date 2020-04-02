using npcGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace npcGenerator.ViewModel
{
    class TestViewModel
    {
        public ICommand Test_Click
        {
            get
            {
                return new RelayCommand(() => MessageBox.Show("Test"));
            }
        }
    }
}
