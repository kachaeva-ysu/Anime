using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Anime
{
    public class AnimeCatalog
    {
        public List<Anime> animes;

        public void Add(Anime anime)
        {
            animes.Add(anime);
        }
        public void FindAllInGenre(string genre)
        {
            List<Anime> movies = new List<Anime>();
            List<Anime> series = new List<Anime>();
            foreach(var anime in animes)
            {
                if(anime.genres.Contains(genre))
                {
                    if (anime.isMovie)
                        movies.Add(anime);
                    else
                        series.Add(anime);
                }
            }
            movies = (from movie in movies orderby movie.name select movie).ToList<Anime>();
            series = (from serial in series orderby serial.name select serial).ToList<Anime>();
            string fileWithMoviesName = genre + "Movies.txt";
            string fileWithSeriesName = genre + "Series.txt";
            using (var sw = new StreamWriter(fileWithMoviesName))
            {
                foreach (var movie in movies)
                    sw.WriteLine(movie.ToString());
            }
            using (var sw = new StreamWriter(fileWithSeriesName))
            {
                foreach (var serial in series)
                    sw.WriteLine(serial.ToString());
            }
            Console.WriteLine("Фильмы:");
            foreach (var movie in movies)
                Console.WriteLine(movie.ToString());
            Console.WriteLine("Сериалы:");
            foreach (var serial in series)
                Console.WriteLine(serial.ToString());
        }
        public void FindBestSeries()
        {
            List<Anime> rightAnimes = new List<Anime>();
            foreach(var anime in animes)
            {
                if (!anime.isMovie && anime.community <= 200000)
                    rightAnimes.Add(anime);
            }
            List<Anime> bestAnimes = (from anime in rightAnimes orderby anime.rating select anime).Take(20).ToList<Anime>();
            string fileName = "bestSeries.txt";
            using(var sw=new StreamWriter(fileName))
            {
                foreach(var series in bestAnimes)
                {
                    sw.WriteLine(series.ToString());
                    Console.WriteLine(series.ToString());
                }
            }
        }
        public void FindBestMovies()
        {
            List<Anime> rightAnimes = new List<Anime>();
            foreach (var anime in animes)
            {
                if (anime.isMovie)
                    rightAnimes.Add(anime);
            }
            int count=int.Parse(Math.Round(rightAnimes.Count*0.01).ToString());
            List<Anime> bestAnimes = (from anime in rightAnimes orderby anime.rating select anime).Take(count).ToList<Anime>();
            bestAnimes = (from anime in bestAnimes orderby anime.community select anime).ToList<Anime>();
            string fileName = "bestMovies.txt";
            using (var sw = new StreamWriter(fileName))
            {
                foreach (var movie in bestAnimes)
                {
                    sw.WriteLine(movie.ToString());
                    Console.WriteLine(movie.ToString());
                }
            }
        }
        public void FindAllInEveryGenre()
        {
            Dictionary<string, List<Anime>> animesInGenres = new Dictionary<string, List<Anime>>();
            foreach(var anime in animes)
            {
                foreach(var genre in anime.genres)
                {
                    if (!animesInGenres.ContainsKey(genre))
                        animesInGenres.Add(genre, new List<Anime>());
                    animesInGenres[genre].Add(anime);
                }
            }
            string fileName = "animesInEveryGenre.txt";
            using (var sw = new StreamWriter(fileName))
            {
                foreach (var genre in animesInGenres)
                {
                    int minCommunity = genre.Value[0].community;
                    int maxCommunity= genre.Value[0].community;
                    foreach(var anime in genre.Value)
                    {
                        if (anime.community < minCommunity)
                            minCommunity = anime.community;
                        if (anime.community > maxCommunity)
                            maxCommunity = anime.community;
                    }
                    animesInGenres[genre.Key] = (from anime in animesInGenres[genre.Key] orderby anime.isMovie, anime.rating select anime).ToList<Anime>();
                    StringBuilder description = new StringBuilder();
                    StringBuilder communityRange = new StringBuilder();
                    communityRange.AppendFormat("{0}-{1}", minCommunity, maxCommunity);
                    description.AppendFormat("Жанр:{0} Количество аниме:{1} Диапозон количества участников сообществ:{2}", genre.Key, genre.Value.Count, communityRange);
                    sw.WriteLine(description);
                    Console.WriteLine(description);
                    foreach (var anime in genre.Value)
                    {
                        sw.WriteLine(anime.ToString());
                        Console.WriteLine(anime.ToString());
                    }
                }
            }
        }
    }
}
