using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoProyecto
{
    internal class Program
    {
        //creamos un arreglo bidimensional para el tablero del juego
       static int[,] tablero = new int[3, 3];
        //creamos un arreglo para los simbolos del tablero: espacio en blanco, jug1 y jug2
       static char[] simbolo = { ' ','O','X'};
        static void Main(string[] args)
        {
            bool terminado = false;

            //tablero inicial
            DibujarTablero();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");
            do
            {
                //turno a jugador 1
                PreguntarPosicion(1);
                //dibujar la casilla que escogio el jugador 1
                DibujarTablero();
                //Comprobar si ha ganado el jugador 1
                terminado = ComprobarGanador();
                if(terminado == true)
                {
                    Console.WriteLine("el jugador 1 ha ganado!");
                }
                else //se comprueba si hubo empate
                {
                    terminado = ComprobarEmpate();
                    if (terminado == true)
                    {
                        Console.WriteLine("Esto es un empate!");
                    }
                    // si jugador 1 no gano ni hubo empate, entonces es turno del jugador 2
                   else
                    { //turno del jugador 2
                        PreguntarPosicion(2);
                        DibujarTablero();
                        //Comprobar si ha ganado el jugador 2
                        terminado = ComprobarGanador();
                        if (terminado == true)
                        {
                            Console.WriteLine("el jugador 2 ha ganado");
                        }
                    }
                }

            }while (terminado == false); //mientrase el juego no haya terminado, es decir, mientras la variable sea igual a false, se sigue repitiendo el ciclo


        }//cierre main

        static void DibujarTablero()
        {
            int fila = 0;
            int columna = 0;
            Console.WriteLine();//espacio en blanco antes del tablero
            Console.WriteLine("------------");//Dibuja la primera linea
            for (fila = 0;fila <3;fila++)
            {
                Console.Write("|");//dibuja la primera linea vertical
             
                for (columna = 0;columna < 3;columna++)
                {
                    //asigna un espacio, O , X segun sea el caso
                    Console.Write(" {0} |", simbolo[tablero[fila,columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("------------"); //dibuja las lineas horizontales

            }
        }
        //preguntar donde escribir y lo dibuja en el tablero
        static void PreguntarPosicion(int jugador) //1 = jugador1; 2 = jugador2
        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("turno del jugador: {0}",jugador);
                //pedimos la fila
                do
                {
                    Console.WriteLine("seleciona la fila (1 a 3):");
                    fila = Convert.ToInt32(Console.ReadLine());

                } while ((fila<1) || (fila >3));
                //pedimos la columna
                do
                {
                    Console.WriteLine("seleciona la columna (1 a 3):");
                    columna = Convert.ToInt32(Console.ReadLine());

                } while ((columna < 1) || (columna > 3));
                if (tablero[fila-1,columna-1]!= 0)
                {
                    Console.WriteLine("casilla ocupada!");
                }

            } while (tablero[fila - 1, columna - 1] != 0);
            //si todo es correcto se le asigna al jugador correspondiente
            tablero[fila - 1, columna - 1] = jugador;

        }
        //devuelve un "true" si hay tres en linea
        static bool ComprobarGanador()
        {
            int fila, columna;
            bool tictactoe = false;
            //si en alguna fila todas las casillas son iguales y no estan vacias
            for (fila = 0; fila <3;fila++)
            {
                if ((tablero[fila, 0] == tablero[fila, 1]) && (tablero[fila, 0] == tablero[fila,2]) &&
                        (tablero[fila,0] != 0))
                {
                    tictactoe = true;
                }
            }
            //si en alguna columna todas las casillas son iguales y no estan vacias
            for (columna = 0; columna < 3; columna++)
            {
                if ((tablero[0, columna] == tablero[1, columna]) && (tablero[0, columna] == tablero[2, columna]) &&
                        (tablero[0, columna] != 0))
                {
                    tictactoe = true;
                }
            }
            //si en alguna diagona todas las casillas son iguales o no estan vacias
            if ((tablero[0,0] == tablero[1,1]) && (tablero[0,0] == tablero[2,2]) && (tablero[0,0] !=0))
            {
                tictactoe = true;
            }
            if ((tablero[0, 2] == tablero[1, 1]) && (tablero[0, 2] == tablero[2, 0]) && (tablero[0, 2] != 0))
            {
                tictactoe = true;
            }

            return tictactoe;
        }
        //devuelve un "true" si hay empate
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila, columna;
            for(fila = 0; fila<3;fila++)
            {
                for (columna = 0; columna < 3; columna++)
                {
                    if (tablero[fila,columna] ==0)
                    {
                        //si encuentra una casilla vacia quiere decir que aun se puede seguir jugando
                        hayEspacio = true;
                    }
                }
            }

            return !hayEspacio; /*si el clclo anterior regresa un "true", indicando que si hay espacios, entonces se que regresar una negacion de true para que la condicion de empate no se cumpla en main*/
        }
    }
}
