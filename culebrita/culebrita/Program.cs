
using culebrita.Jueguitos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace culebrita
{
    class Program
    {

        //convertirlo en un programa orietado a objetos
        //emitir beep cuando coma la comida
        //incrementar la velocidad conforme vaya avanzando
        //modificar el uso de queue y reemplazarlo con cada una de las estructuras de de cola vista en clase
        //Elaborar Video explicando el funcionamiento del código y del programa.







        static void Main()
        {
           JuegoBiCola JugarBi = new JuegoBiCola();
           JuegoCCircular JugarCi = new JuegoCCircular();
           JuegoCLineal JugarLi = new JuegoCLineal();
           JuegoCLista JugarCLi = new JuegoCLista();

            //JugarBi.Iniciar();
            //JugarCi.Iniciar();
           // JugarLi.Iniciar();
            JugarCLi.Iniciar();
 
            


        }







    }//fin
}




