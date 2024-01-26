using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPracticosa.Plantillas
{
    public class Simple : ContentPage
    {
        public Simple() {
            var simple = Application.Current.Resources["simple"] as ControlTemplate;
            ControlTemplate = simple;
        }
    }
}
