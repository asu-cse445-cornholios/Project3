using System;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicInfo
{
    using SearchTypes;
    using System.IO;


    class MediaLibrary
    {
        /// <summary>
        /// Contains base url to service
        /// </summary>
        private static string serviceUrl = "http://www.musicbrainz.org/ws/2"; 


        public static ArtistResult findArtists(ArtistSearch search)
        {
            //
            // Build request Url
            //
            string requestUrl = serviceUrl + "/artist/?query=";

            if (search.Artist != "")
            {
                requestUrl += "artist:" + search.Artist + " ";
            }

            System.Console.WriteLine(requestUrl);

            //
            // Get and Parse result
            //
            XPathDocument doc = new XPathDocument(requestUrl);
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iter = nav.Select("/metadata/artist-list/artist");
            
            while (iter.MoveNext())
            {
                XPathNodeIterator xnode = iter.Current.Select("name");
                System.Console.WriteLine(xnode.Current.Value);
            }

            return null;
        }

    }
}
