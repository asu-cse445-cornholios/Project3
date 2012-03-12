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
            ArtistSearch search1 = new ArtistSearch();
            search1.Artist = "Scorpions";
            ArtistResult[] result1 = MediaLibrary.findArtists(search1);

            // Test others
            RecordingSearch search2 = new RecordingSearch();
            search2.Recording = "Comeblack";
            RecordingResult[] result2 = MediaLibrary.findRecordings(search2); 

            return;
        }
    }
}
