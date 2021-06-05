using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.ColaCircular
{
    class Nodo
    {
       
            public Object elemento;
            public Nodo siguiente;

            public Nodo(Object x)
            {

                elemento = x;
                siguiente = null;
            }
        
    }
}
