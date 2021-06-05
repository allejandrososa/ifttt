using culebrita.ColaLienal;
using culebrita.ColaLista;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace culebrita.Jueguitos
{
    class JuegoCLineal
    {

        //convertirlo en un programa orietado a objetos
        //emitir beep cuando coma la comida
        //incrementar la velocidad conforme vaya avanzando
        //modificar el uso de queue y reemplazarlo con cada una de las estructuras de de cola vista en clase
        //Elaborar Video explicando el funcionamiento del código y del programa.


        internal enum Direction
        {
            Abajo, Izquierda, Derecha, Arriba
        }


        public  void DibujaPantalla(Size size)
        {
            Console.Title = "Culebrita comelona";
            Console.WindowHeight = size.Height + 2;
            Console.WindowWidth = size.Width + 2;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                }
            }
        }



        private static void MuestraPunteo(int punteo)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Puntuación: {punteo.ToString("00000000")}");
        }




        private static Direction ObtieneDireccion(Direction direccionAcutal)
        {
            if (!Console.KeyAvailable) return direccionAcutal;

            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                    if (direccionAcutal != Direction.Arriba)
                        direccionAcutal = Direction.Abajo;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionAcutal != Direction.Derecha)
                        direccionAcutal = Direction.Izquierda;
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionAcutal != Direction.Izquierda)
                        direccionAcutal = Direction.Derecha;
                    break;
                case ConsoleKey.UpArrow:
                    if (direccionAcutal != Direction.Abajo)
                        direccionAcutal = Direction.Arriba;
                    break;
            }
            return direccionAcutal;
        }



        private static Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
        {
            Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
            switch (direction)
            {
                case Direction.Arriba:
                    siguienteDireccion.Y--;
                    break;
                case Direction.Izquierda:
                    siguienteDireccion.X--;
                    break;
                case Direction.Abajo:
                    siguienteDireccion.Y++;
                    break;
                case Direction.Derecha:
                    siguienteDireccion.X++;
                    break;
            }
            return siguienteDireccion;
        }




        private static bool MoverLaCulebrita(ColaLineal culebra, Point posiciónObjetivo,
             int longitudCulebra, Size screenSize)

        {


                var lastPoint = (Point)culebra.finalCola();


                if (lastPoint.Equals(posiciónObjetivo)) return true;


            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                        || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
                {
                

                return false;
                 }
               



                Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
                Console.WriteLine(" ");

                culebra.insertar(posiciónObjetivo);

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
                Console.Write(" ");

                // Quitar cola
                if (culebra.cantidad() > longitudCulebra)
                {
                    var removePoint = (Point)culebra.quitar();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                    Console.Write(" ");

                }
            
            return true;
            
        }

        private static Point MostrarComida(Size screenSize, ColaLineal culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.finalCola();
            var a = cabezaCulebra.X;
            var b = cabezaCulebra.Y;
           


            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if (culebra.ToString().All(x => a != x || b != y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                }

            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");

            return lugarComida;
        }



        public void Iniciar()
        {



            var punteo = 0;
            var velocidad = 100; //modificar estos valores y ver qué pasa
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(60, 20);
            var culebrita = new ColaLineal();
            var longitudCulebra = 3; //modificar estos valores y ver qué pasa
            var posiciónActual = new Point(0, 9); //modificar estos valores y ver qué pasa
            culebrita.insertar(posiciónActual);
            var dirección = Direction.Derecha; //modificar estos valores y ver qué pasa

            DibujaPantalla(tamañoPantalla);
            MuestraPunteo(punteo);

            while (MoverLaCulebrita(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                Thread.Sleep(velocidad);
                dirección = ObtieneDireccion(dirección);
                posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    Console.Beep();
                    posiciónComida = Point.Empty;
                    longitudCulebra++; //modificar estos valores y ver qué pasa  
                    punteo += 10; //modificar estos valores y ver qué pasa

                    if (punteo == 30)
                    {
                        velocidad = 60;
                    }
                    if (punteo == 60)
                    {
                        velocidad = 30;
                    }

                    MuestraPunteo(punteo);
                }

                if (posiciónComida == Point.Empty) //entender qué hace esta linea
                {
                    posiciónComida = MostrarComida(tamañoPantalla, culebrita);
                }
            }

            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Write("Fin del Juego");
            Thread.Sleep(2000);
            Console.ReadKey();

        }









    }
}
