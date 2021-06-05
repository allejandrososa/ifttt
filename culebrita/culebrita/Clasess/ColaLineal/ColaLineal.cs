
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.ColaLienal
{
    class ColaLineal
    {

        protected int fin;
        private static int MAZTAMQ = 999;
        protected int frente;
        protected int conteo;

        protected Object[] listaCola;

        public ColaLineal()
        {
            frente = 0;
            fin = -1;
            listaCola = new object[MAZTAMQ];

        }

        public bool colaVacia()
        {
            return frente > fin;
        }

        public bool colaLlena()
        {
            return fin == MAZTAMQ - 1;
        }
        //Operaciones para trabajr con datos en la cola
        public void insertar(Object elemento)
        {
            if (!colaLlena())
            {
                listaCola[++fin] = elemento;
               conteo++;
            }
            else
            {
                throw new Exception("Overflow de la Cola");
            }
        }
        //Quitar elementos en la cola

        public Object quitar()
        {
            if (!colaVacia())
            {
                conteo--;
                return listaCola[frente++];

            }
            else
            {
                throw new Exception("Cola Vacia");
            }
        }

        //Limpiar toda la cola

        public void borrarCola()
        {
            frente = 0;
            fin = -1;
        }

        //Acceso a la cola
        public Object frenteCola()
        {
            if (!colaVacia())
            {
                return listaCola[frente];
            }
            else
            {

                throw new Exception("Cola Vacia");
            }
        }
        public Object finalCola()
        {
            if (colaVacia())
            {
                throw new Exception("Cola Vacia");

            }
            return (listaCola[fin]);
        }
        public int cantidad()
        {
            int elementos;
            elementos= conteo;

            return elementos;
        }
        


    }
}
