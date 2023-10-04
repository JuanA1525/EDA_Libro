using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_Libro.Clases
{
    public class Libro : IComparable<Libro>
    {   
        // ATRIBUTOS
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public double AverageRating { get; set; }
        public string ISBN { get; set; }
        public string ISBN13 { get; set; }
        public string LanguageCode { get; set; }
        public int NumPages { get; set; }
        public int RatingsCount { get; set; }
        public int TextReviewsCount { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Publisher { get; set; }

        public static List<Libro> listaDeLibros = new List<Libro>();

        // CONSTRUCTORES
        public Libro() { }

        public Libro(int bookID, string title, string authors, double averageRating,
        string isbn, string isbn13, string languageCode, int numPages,
        int ratingsCount, int textReviewsCount, DateTime publicationDate,
        string publisher)
        {
            BookID = bookID;
            Title = title;
            Authors = authors;
            AverageRating = averageRating;
            ISBN = isbn;
            ISBN13 = isbn13;
            LanguageCode = languageCode;
            NumPages = numPages;
            RatingsCount = ratingsCount;
            TextReviewsCount = textReviewsCount;
            PublicationDate = publicationDate;
            Publisher = publisher;

            // Agrega esta instancia a la lista de libros
            listaDeLibros.Add(this);
        }

        // METODOS

        // Se imoplementa CompareTo para poder implementar la interfaz Comparable 
        // En este caso por defecto se compara por Average Rating
        public int CompareTo(Libro otroLibro)
        {
            return AverageRating.CompareTo(otroLibro.AverageRating);
        }

        // Funcion para leer la CSV e Importar los libros a la lista de libros (6 Registros malos)
        public static void leerCSV(string rutaCSV)
        {
            try
            {
                string[] lineas = File.ReadAllLines(rutaCSV);

                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] campos = lineas[i].Split("&&");

                    if (campos.Length == 12)
                    {
                        try
                        {
                            Libro libro = new Libro
                            {
                                BookID = int.Parse(campos[0]),
                                Title = campos[1],
                                Authors = campos[2],
                                AverageRating = double.Parse(campos[3]),
                                ISBN = campos[4],
                                ISBN13 = campos[5],
                                LanguageCode = campos[6],
                                NumPages = int.Parse(campos[7]),
                                RatingsCount = int.Parse(campos[8]),
                                TextReviewsCount = int.Parse(campos[9]),
                                PublicationDate = DateTime.Parse(campos[10]),
                                Publisher = campos[11]
                            };

                            listaDeLibros.Add(libro);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al crear un libro en la línea {i  }: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"La línea {i + 1} no tiene suficientes campos y será ignorada.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo CSV: {ex.Message}");
            }
        }

        // Se implementa la funcion OrderByDescending para ordenar de forma descendente y devolver la lista
        public static List<Libro> ListarPorRating()
        {
            List<Libro> listaOrdenada = listaDeLibros.OrderByDescending(libro => libro.AverageRating).ToList();
            return listaOrdenada;
        }

        // Implementamos Comparadores
        public class AuthorComparator : IComparer<Libro>
        {
            public int Compare(Libro libro1, Libro libro2)
            {
                return libro1.Authors.CompareTo(libro2.Authors);
            }
        }
        public class RatingsComparator: IComparer<Libro>
        {
            public int Compare(Libro libro1, Libro libro2)
            {
                return libro1.RatingsCount.CompareTo(libro2.RatingsCount);
            }
        }
        public class PublicationDateComparator : IComparer<Libro>
        {
            public int Compare(Libro libro1, Libro libro2)
            {
                return libro1.PublicationDate.CompareTo(libro2.PublicationDate);
            }
        }

        // Listar por Comparador
        public static void ListarPorComparador(Libro[] libros, IComparer<Libro> comparador)
        {
            Array.Sort(libros, comparador);

            foreach (Libro libro in libros)
            {
                Console.WriteLine($"{libro.Title}: {libro.AverageRating}");
            }
        }

        // Implementamos los metodos de Ordenacion
        private static void ShellSort(List<Libro> libros, IComparer<Libro> comparador)
        {
            int n = libros.Count;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    Libro temp = libros[i];
                    int j = i;
                    while (j >= gap && comparador.Compare(libros[j - gap], temp) > 0)
                    {
                        libros[j] = libros[j - gap];
                        j -= gap;
                    }
                    libros[j] = temp;
                }
                gap /= 2;
            }
        }
        private static void InsertionSort(List<Libro> libros, IComparer<Libro> comparador)
        {
            for (int i = 1; i < libros.Count; i++)
            {
                Libro current = libros[i];
                int j = i - 1;
                while (j >= 0 && comparador.Compare(libros[j], current) > 0)
                {
                    libros[j + 1] = libros[j];
                    j--;
                }
                libros[j + 1] = current;
            }
        }
        private static void SelectionSort(List<Libro> libros, IComparer<Libro> comparador)
        {
            for (int i = 0; i < libros.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < libros.Count; j++)
                {
                    if (comparador.Compare(libros[j], libros[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Libro temp = libros[i];
                    libros[i] = libros[minIndex];
                    libros[minIndex] = temp;
                }
            }
        }
        private static void CSharpSort(List<Libro> libros, IComparer<Libro> comparador)
        {
            libros.Sort(comparador);
        }

        // Creamos las funciones para extraer los tiempos por metodo
        public static TimeSpan CSharpSortTime(List<Libro> libros, IComparer<Libro> comparador)
        {
            List<Libro> copiaLibros = new List<Libro>(libros);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            CSharpSort(copiaLibros, comparador);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
        public static TimeSpan ShellSortTime(List<Libro> libros, IComparer<Libro> comparador)
        {
            List<Libro> copiaLibros = new List<Libro>(libros);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            ShellSort(copiaLibros, comparador);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
        public static TimeSpan InsertionSortTime(List<Libro> libros, IComparer<Libro> comparador)
        {
            List<Libro> copiaLibros = new List<Libro>(libros);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            InsertionSort(copiaLibros, comparador);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
        public static TimeSpan SelectionSortTime(List<Libro> libros, IComparer<Libro> comparador)
        {
            List<Libro> copiaLibros = new List<Libro>(libros);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            SelectionSort(copiaLibros, comparador);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        // Implementamos funcion que mezcle las listas
        private static void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // Funcion para obtener promedios de tiempo
        public static List<TimeSpan> MedirTiempoPromedio(List<Libro> libros, IComparer<Libro> comparador, int mediciones, byte tipo_comp)
        {
            List<TimeSpan> tiempos = new List<TimeSpan>();


            if (tipo_comp == 0)
            {

                for (int i = 0; i < mediciones; i++)
                {
                    Shuffle(libros);

                    List<Libro> copiaLibros = new List<Libro>(libros);
                    Stopwatch stopwatch = new Stopwatch();

                    stopwatch.Start();
                    ShellSort(copiaLibros, comparador); //ELEGIR METODO DE ORDENACION...
                    stopwatch.Stop();

                    tiempos.Add(stopwatch.Elapsed);
                }

            }else if (tipo_comp == 1)
            {


                for (int i = 0; i < mediciones; i++)
                {
                    Shuffle(libros);

                    List<Libro> copiaLibros = new List<Libro>(libros);
                    Stopwatch stopwatch = new Stopwatch();

                    stopwatch.Start();
                    InsertionSort(copiaLibros, comparador); //ELEGIR METODO DE ORDENACION...
                    stopwatch.Stop();

                    tiempos.Add(stopwatch.Elapsed);
                }

            }
            else if(tipo_comp == 2)
            {

                for (int i = 0; i < mediciones; i++)
                {
                    Shuffle(libros);

                    List<Libro> copiaLibros = new List<Libro>(libros);
                    Stopwatch stopwatch = new Stopwatch();

                    stopwatch.Start();
                    SelectionSort(copiaLibros, comparador); //ELEGIR METODO DE ORDENACION...
                    stopwatch.Stop();

                    tiempos.Add(stopwatch.Elapsed);
                }

            }
            else if (tipo_comp == 3)
            {

                for (int i = 0; i < mediciones; i++)
                {
                    Shuffle(libros);

                    List<Libro> copiaLibros = new List<Libro>(libros);
                    Stopwatch stopwatch = new Stopwatch();

                    stopwatch.Start();
                    CSharpSort(copiaLibros, comparador); //ELEGIR METODO DE ORDENACION...
                    stopwatch.Stop();

                    tiempos.Add(stopwatch.Elapsed);
                }

            }
            else
            {
                throw new Exception("El numero de comparacion no coincide con ninguno de los implementados.");
            }




            return tiempos;
        }

        // Se sobreescribe la funcion ToString para devolver la info deseada
        public override string ToString()
        {
            return Title.ToString() + " - " + PublicationDate + " Rating: " + AverageRating;
        }
    }
}
