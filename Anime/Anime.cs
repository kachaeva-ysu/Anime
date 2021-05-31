using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anime
{
    public class Anime
    {
        public int id;
        public string name;
        public List<string> genres;
        public bool isMovie;
        public int numberOfEpisodes;
        public int rating;
        public int community;

        public Anime(string i,string n,string g,string im,string noe,string r,string c)
        {
            id = int.Parse(i);
            name = n;
            genres = new List<string>(g.Split(','));
            if (im == "Movie")
                isMovie = true;
            else
                isMovie = false;
            numberOfEpisodes = int.Parse(noe);
            rating = int.Parse(r);
            community = int.Parse(c);
        }


        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine(id.ToString());
            res.AppendLine(name.ToString());
            for (int i = 0; i < genres.Count - 1; i++)
                res.Append(genres[i] + ',');
            res.AppendLine(genres[genres.Count - 1]);
            if (isMovie)
                res.AppendLine("Movie");
            else
                res.AppendLine("Series");
            res.AppendLine(numberOfEpisodes.ToString());
            res.AppendLine(rating.ToString());
            res.AppendLine(community.ToString());
            return res.ToString();
        }
    }
}
