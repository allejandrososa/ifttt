using culebrita.ColaLista;
using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.ColaLista
{
    class ColaConLista
    {
        public Nodo frente;
        public Nodo fin;

        // Constructor
        public ColaConLista()
        {
            frente = fin = null;
        }


        // Verificar si la cola está vacia
        public bool colaVacia()
        {
            return (frente == null);
        }

        public void insertar(Object elemento)
        {
            Nodo a;
            a = new Nodo(elemento);
            if (colaVacia())
            {
                frente = a;
            }
            else
            {
                fin.siguiente = a;
            }
            fin = a;
        }

        //Quitar elemento

        public Object quitar()
        {
            Object aux;
            if (!colaVacia())
            {
                aux = frente.elemento;
                frente = frente.siguiente;
            }
            else
            {
                throw new Exception("Error por que la cola esta vacia");
            }
            return aux;

        }

        // vacia o liberar todo los nodos

        public void borraCola()
        {
            for (; frente != null;)
            {
                frente = frente.siguiente;
            }
        }

        // Devolver el valor que está el frente de la cola

        public Object frenteCola()
        {
            if (colaVacia())
            {
                throw new Exception("Error: la cola esta vacia");

            }

            return (frente.elemento);
        }

        public Object finalCola()
        {
            if (colaVacia())
            {
                throw new Exception("Error: la cola esta vacia");

            }

            return (fin.elemento);
        }

        public int elementosColaLista()
        {
            int n;
            Nodo a = frente;

            if (colaVacia())
            {
                n = 0;
            }
            else
            {
                n = 1;
                while (a != fin)
                {
                    n++;
                    a = a.siguiente;
                }
            }
            return n;


        }

    }
}
