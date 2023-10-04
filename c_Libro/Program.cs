using c_Libro.Clases;

namespace c_Libro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro.leerCSV("C:\\Users\\juana\\OneDrive - UPB\\ESTRUCTURAS DE DATOS Y ALGORITMOS\\Taller Practico #3\\books.csv");

            IComparer<Libro> authComparer = new Libro.AuthorComparator();
            IComparer<Libro> ratingComparer = new Libro.RatingsComparator();
            IComparer<Libro> dateComparer = new Libro.PublicationDateComparator();
            
            // SHELL SORT con AUTH COMPARER

            List<TimeSpan> tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, authComparer, 20, 0);
            TimeSpan tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #1: \nComparaciones por autor.\n20 Comparaciones.\nMetodo -> ShellSort\n\n Resultados:\n");

            byte contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());



            // SHELL SORT con RATING COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, ratingComparer, 20, 0);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #2: \nComparaciones por rating.\n20 Comparaciones.\nMetodo -> ShellSort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());


            // SHELL SORT con DATE COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, dateComparer, 20, 0);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #3: \nComparaciones por fecha.\n20 Comparaciones.\nMetodo -> ShellSort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());


            // INSERTION SORT con AUTH COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, authComparer, 20, 1);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #1: \nComparaciones por autor.\n20 Comparaciones.\nMetodo -> InsertionSort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());


            // INSERTION SORT con RATING COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, ratingComparer, 20, 1);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #2: \nComparaciones por rating.\n20 Comparaciones.\nMetodo -> InsertionSort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());


            // INSERTION SORT con DATE COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, dateComparer, 20, 1);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #3: \nComparaciones por fecha.\n20 Comparaciones.\nMetodo -> InsertionSort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());


            // SELECTION SORT con AUTH COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, authComparer, 20, 2);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #1: \nComparaciones por autor.\n20 Comparaciones.\nMetodo -> SelectionSort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());



            // SELECTION SORT con RATING COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, ratingComparer, 20, 2);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #2: \nComparaciones por rating.\n20 Comparaciones.\nMetodo -> SelectionSort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());



            // SELECTION SORT con DATE COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, dateComparer, 20, 2);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #3: \nComparaciones por fecha.\n20 Comparaciones.\nMetodo -> SelectionSort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());


            // CSHARP SORT con AUTH COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, authComparer, 20, 3);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #1: \nComparaciones por autor.\n20 Comparaciones.\nMetodo -> CSHARP Sort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());


            // CSHARP SORT con RATING COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, ratingComparer, 20, 3);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #2: \nComparaciones por rating.\n20 Comparaciones.\nMetodo -> CSHARP Sort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());


            // CSHARP SORT con DATE COMPARER

            tiempos = Libro.MedirTiempoPromedio(Libro.listaDeLibros, dateComparer, 20, 3);
            tiempoPromedio = new TimeSpan((long)tiempos.Average(t => t.Ticks));

            Console.WriteLine("\n\nCOMPARACIONES #3: \nComparaciones por fecha.\n20 Comparaciones.\nMetodo -> CSHARP Sort\n\n Resultados:\n");

            contador = 0;
            foreach (var tiempo in tiempos)
            {
                contador++;
                Console.WriteLine("Medicion #" + contador + ": " + tiempo.ToString());
            }

            Console.WriteLine("\nPromedio de los tiempos: " + tiempoPromedio.ToString());


        }
    }
}