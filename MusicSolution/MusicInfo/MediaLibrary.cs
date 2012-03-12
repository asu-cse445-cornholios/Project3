using System;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicInfo
{
    using SearchTypes;
    using System.IO;
    using System.Xml;


    class MediaLibrary
    {
        /// <summary>
        /// Contains base url to service
        /// </summary>
        private static string serviceUrl = "http://www.musicbrainz.org/ws/2";

        /// <summary>
        /// Gets the child text value for node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static string getTextChild(XmlNode node)
        {
            if (node == null)
                return "";
            else
            {
                return node.FirstChild.InnerText;
            }
        }

        /// <summary>
        /// Gets attribute attached to node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        private static string getAttributeValue(XmlNode node, string attributeName)
        {
            string ret = "";
            foreach (XmlAttribute attr in node.Attributes)
            {
                if (attr.Name == attributeName)
                {
                    ret = attr.Value;
                    break;
                }
            }

            return ret;
        }

        /// <summary>
        /// Gets the child node of a parent by name
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static XmlNode getNodeByName(XmlNode parentNode, string name)
        {
            if (parentNode == null)
                return null;

            foreach (XmlNode node in parentNode.ChildNodes)
            {
                if (node.Name == name)
                {
                    return node;
                }
            }
            return null;
        }


        public static ArtistResult[] findArtists(ArtistSearch search)
        {
            List<ArtistResult> artists = new List<ArtistResult>();

            //
            // Build request Url
            //
            string requestUrl = serviceUrl + "/artist/?query=";

            if (search.Artist != "")
            {
                requestUrl += "artist:" + search.Artist + " ";
            }


            //
            // Get and Parse result
            //
            XmlDocument docRef = new XmlDocument();
            docRef.Load(requestUrl);
            XmlNode root = docRef.DocumentElement;
            XmlNode artistList = root.FirstChild;

            XmlNodeList artistNodes = artistList.ChildNodes;
            foreach (XmlNode artistNode in artistNodes)
            {
                ArtistResult newArtist = new ArtistResult();

                newArtist.Score = getAttributeValue(artistNode,"ext:score");
                newArtist.Id = getAttributeValue(artistNode,"id");
                newArtist.Name = getTextChild(getNodeByName(artistNode, "name"));
                newArtist.Country = getTextChild(getNodeByName(artistNode, "country"));

                XmlNode lifeSpan = getNodeByName(artistNode, "life-span");
                newArtist.Begin = getTextChild(getNodeByName(lifeSpan, "begin"));
                newArtist.End = getTextChild(getNodeByName(lifeSpan, "end"));

                artists.Add(newArtist);
            }
            


            return artists.ToArray();
        }

        public static ReleaseGroupResult[] findReleaseGroups(ReleaseGroupSearch search)
        {
            List<ReleaseGroupResult> releaseGroups = new List<ReleaseGroupResult>();

            //
            // Build request Url
            //
            string requestUrl = serviceUrl + "/release-group/?query=";

            if (search.Artist != "")
            {
                requestUrl += "artist:" + search.Artist + " ";
            }
            if (search.Release != "")
            {
                requestUrl += "release:" + search.Release + " ";
            }
            if (search.ReleaseGroup != "")
            {
                requestUrl += "releasegroup:" + search.ReleaseGroup + " ";
            }
            if (search.ReleaseID != "")
            {
                requestUrl += "reid:" + search.ReleaseID + " ";
            }
            if (search.Type != "")
            {
                requestUrl += "type:" + search.Type + " ";
            }

            //
            // Get and Parse result
            //
            XmlDocument docRef = new XmlDocument();
            docRef.Load(requestUrl);
            XmlNode root = docRef.DocumentElement;
            XmlNode releaseGroupList = root.FirstChild;

            XmlNodeList releaseGroupNodes = releaseGroupList.ChildNodes;
            foreach (XmlNode releaseGroupNode in releaseGroupNodes)
            {
                ReleaseGroupResult newReleaseGroup = new ReleaseGroupResult();

                newReleaseGroup.Score = getAttributeValue(releaseGroupNode, "ext:score");
                newReleaseGroup.Id = getAttributeValue(releaseGroupNode, "id");
                newReleaseGroup.Type = getTextChild(getNodeByName(releaseGroupNode, "type"));
                newReleaseGroup.Title = getTextChild(getNodeByName(releaseGroupNode, "title"));

                releaseGroups.Add(newReleaseGroup);
            }



            return releaseGroups.ToArray();
        }

        public static ReleaseResult[] findReleases(ReleaseSearch search)
        {
            return null;
        }

        public static RecordingResult[] findRecordings(RecordingSearch search)
        {
            return null;
        }

        public static LabelResult[] findLabels(LabelSearch search)
        {
            return null;
        }

        public static WorkResult[] findWorks(WorkSearch search)
        {
            return null;
        }
    }
}
