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
            XPathDocument document = new XPathDocument(requestUrl);
            XPathNavigator navigater = document.CreateNavigator();
            XPathNodeIterator artistNodes = navigater.Select("metadata/artist-list/artist");

            XPathNavigator node = artistNodes.Current;
            node = node.MoveToChild() ;
            
            while (artistNodes.MoveNext())
            {
                XPathNavigator artistNode = artistNodes.Current;
                System.Console.WriteLine(artistNode.GetAttribute("id",""));

                XPathNodeIterator nameNode = artistNodes.Current.Select("Name");
                nameNode.MoveNext();

              // XPathNavigator nameNode = artistNodes.Current.SelectSingleNode("name");
               //nameNode.
            }


            //XPathNavigator nodesNavigator = nodes.Current;

            //XPathNodeIterator nodesText = nodesNavigator.sele

            //while (nodesText.MoveNext())
            //    Console.WriteLine(nodesText.Current.Value);
            

            return null;
        }

    }
}
