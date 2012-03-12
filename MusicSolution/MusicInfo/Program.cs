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
            //Test artist search
            ArtistSearch search = new ArtistSearch();
            search.Artist = "Scorpions";

            ArtistResult[] result = MediaLibrary.findArtists(search);

            // Test others
            return;
        }
    }
}
