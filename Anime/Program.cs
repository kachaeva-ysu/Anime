using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Anime
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimeCatalog animes = new AnimeCatalog();
            using(var sr=new StreamReader("data_anime.txt"))
            {
                string id = sr.ReadLine();
                while(id!=null)
                {
                    animes.Add(new Anime(id, sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()));
                }
            }
            Console.WriteLine("Введите жанр или нажмте q для продолжения:");
            string genre = Console.ReadLine();
            while (genre != "q")
            {
                animes.FindAllInGenre(genre);
                Console.WriteLine("Введите жанр или нажмте q для продолжения:");
                genre = Console.ReadLine();
            }
            Console.WriteLine("Лучшие фильмы:");
            animes.FindBestMovies();
            Console.WriteLine("Лучшие сериалы:");
            animes.FindBestSeries();
            animes.FindAllInEveryGenre();
        }
    }
}
