using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace culebrita.ColaArreglo
{
    class Cola_Circular
    {
       public  int fin;
        private static int MAXTAMQ = 9999;
       protected int frente;
        public Object[] listaCola;
        public int conta = 0;

        // avavnza un aposion

        private int siguiente(int r)
        {
            return (r + 1) % MAXTAMQ;
        }

        public Cola_Circular()
        {
            frente = 0;
            fin = MAXTAMQ - 1;
            listaCola =  new object[MAXTAMQ];
        }

        // Validaciones

        public bool colaVacia()
        {
            return frente == siguiente(fin);
        }

        public bool colaLlena()
        {
            return frente == siguiente(siguiente(fin));
        }

        //operaciones de modificacion de cola
        public void insertar(Object elemento)
        {
            if (!colaLlena())
            {
                fin = siguiente(fin);
                listaCola[fin] = elemento;
                conta++;
            }
            else
            {
                throw new Exception("Overflow de la cola");
            }


        }
        // quitar elemento
        public Object quitar()
        {
            if (!colaVacia())
            {
                Object tm = listaCola[frente];
                frente = siguiente(frente);
                conta--;
                return tm;

            }
            else
            {
                throw new Exception("Cola vacia");
            }
        }

        public void borrarCola()
        {
            frente = 0;
            fin = MAXTAMQ - 1;
            conta = 0;
        }

        //obtener el valor de frente
        public object frenteCola()
        {
            if (!colaVacia())
            {
                return listaCola[frente];
            }
            else
            {
                throw new Exception("Cola vacia");
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
        public int canElementos()
        {
            int Elementos = conta;

            return Elementos;
        }
       
        


    }//Fin de la class
}
