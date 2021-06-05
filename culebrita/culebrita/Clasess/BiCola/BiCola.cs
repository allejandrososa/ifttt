using culebrita.ColaLista;
using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.BiColaEnlazada
{
    class BiCola:ColaConLista
    {
         // insertar por el final de la bicola

        public void ponerFinal(Object elemento) {
            insertar(elemento);
        }
        //insertar al frente

        public void ponerFrente(Object elemento)
        {
            Nodo a;
            a = new Nodo(elemento);
            if (colaVacia())
            {
                fin = a;
            }
            a.siguiente = frente;
            frente = a;
        }

        // Quitar elemento
        public Object quitarFrente() {
            return quitar();
        }

       

        public object quitarFinal() {
            Object aux;
            if (!colaVacia())
            {
                if (frente == fin)// La BiCola solo tiene un Nodo
                {
                    aux = quitar();
                }
                else
                {
                    // Como no tiene elementos vamos a Iterar

                    Nodo a = frente;
                    while (a.siguiente != fin)
                    {
                        a = a.siguiente;
                    }

                    //siguiente del nodo anterior lo vamos a poner en null
                    a.siguiente = null;
                    aux = fin.elemento;
                    fin = a;
                }


            }
            else {

                throw new Exception("La cola está vacia");
            }
            return aux;
        }
        // Retorna el valor que se encuentra en el primer elemento o frente de la cola
        public Object frenteBiCola() {
            return frenteCola();
        }
        // devolver final de la cola
        public Object finalBiCola()
        {
            if (colaVacia()) {
                throw new Exception("Cola Vacia");

            }
            return (fin.elemento);
        }
        //Retorna si está vacia la cola
        public bool biColaVacia() {
            return colaVacia();
        }

        public void borrarBiCola() {
            borrarBiCola();
        }

        //Conteo de elementos
        public int ElementosBicola() {
            int n;
            Nodo a = frente;

            if (biColaVacia())
            {
                n = 0;
            }
            else             {
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
