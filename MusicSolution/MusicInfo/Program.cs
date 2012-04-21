using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicInfo
{
    using SearchTypes;

    class Program
    {
        static void Main(string[] args)
        {
            ReleaseSearch search = new ReleaseSearch();
            search.ArtistName = "scorpions";
            ReleaseResult[] result = MediaLibrary.findReleases(search);

            foreach (ReleaseResult r in result)
            {
                Console.WriteLine("Album name: " + r.Title);
                Console.WriteLine("Date: " + r.Date);
                Console.WriteLine("Artist: " + r.Artist);
                Console.WriteLine("Type: " + r.Type);
                Console.WriteLine("Track Count: " + r.TrackCount);
                Console.WriteLine();
            }

            return;
        }
    }
}
