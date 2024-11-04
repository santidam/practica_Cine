using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01
{
    public class FilaButacas
    {
        public ObservableCollection<int> Butacas { get; set; } // 0 = disponible, 1 = reservada

        public FilaButacas()
        {
            Butacas = new ObservableCollection<int> { 0, 0, 0 }; 
        }
    }
}
