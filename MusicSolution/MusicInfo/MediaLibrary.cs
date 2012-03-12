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


    public static class MediaLibrary
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
            List<ReleaseResult> releases = new List<ReleaseResult>();

            //
            // Build request Url
            //
            string requestUrl = serviceUrl + "/release/?query=";

            if (search.AmazonID != "")
            {
                requestUrl += "asin:" + search.AmazonID + " ";
            }
            if (search.ArtistID != "")
            {
                requestUrl += "arid:" + search.ArtistID + " ";
            }
            if (search.ArtistName != "")
            {
                requestUrl += "artistname:" + search.ArtistName + " ";
            }
            if (search.Label != "")
            {
                requestUrl += "label:" + search.Label + " ";
            }
            if (search.ReleaseGroupID != "")
            {
                requestUrl += "rgid:" + search.ReleaseGroupID + " ";
            }
            if (search.ReleaseID != "")
            {
                requestUrl += "reid:" + search.ReleaseID + " ";
            }
            if (search.ReleaseName != "")
            {
                requestUrl += "release:" + search.ReleaseName + " ";
            }



            //
            // Get and Parse result
            //
            XmlDocument docRef = new XmlDocument();
            docRef.Load(requestUrl);
            XmlNode root = docRef.DocumentElement;
            XmlNode releaseList = root.FirstChild;

            XmlNodeList releaseNodes = releaseList.ChildNodes;
            foreach (XmlNode releaseNode in releaseNodes)
            {
                ReleaseResult newRelease = new ReleaseResult();

                newRelease.Score = getAttributeValue(releaseNode, "ext:score");
                newRelease.Id = getAttributeValue(releaseNode, "id");
                newRelease.Title = getTextChild(getNodeByName(releaseNode, "title"));

                releases.Add(newRelease);
            }


            return releases.ToArray();
        }

        public static RecordingResult[] findRecordings(RecordingSearch search)
        {
            List<RecordingResult> recording = new List<RecordingResult>();

            //
            // Build request Url
            //
            string requestUrl = serviceUrl + "/recording/?query=";

            if (search.Artist != "")
            {
                requestUrl += "artist:" + search.Artist + " ";
            }
            if (search.Id != "")
            {
                requestUrl += "rid:" + search.Id + " ";
            }
            if (search.Recording != "")
            {
                requestUrl += "recording:" + search.Recording + " ";
            }
            if (search.Release != "")
            {
                requestUrl += "release:" + search.Release + " ";
            }
            if (search.Type != "")
            {
                requestUrl += "type:" + search.Type + " ";
            }
            if (search.ArtistId != "")
            {
                requestUrl += "aid:" + search.ArtistId + " ";
            }

            System.Console.WriteLine(requestUrl);

            //
            // Get and Parse result
            //
            XmlDocument docRef = new XmlDocument();
            docRef.Load(requestUrl);
            XmlNode root = docRef.DocumentElement;
            XmlNode recordList = root.FirstChild;

            XmlNodeList recordNodes = recordList.ChildNodes;
            foreach (XmlNode recordNode in recordNodes)
            {
                RecordingResult newRecord = new RecordingResult();

                newRecord.Id = getAttributeValue(recordNode, "id");
                newRecord.Title = getTextChild(getNodeByName(recordNode, "title"));
                newRecord.Length = getTextChild(getNodeByName(recordNode, "length"));

                recording.Add(newRecord);
            }

            return recording.ToArray();
        }

        public static LabelResult[] findLabels(LabelSearch search)
        {
            List<LabelResult> label = new List<LabelResult>();

            //
            // Build request Url
            //
            string requestUrl = serviceUrl + "/label/?query=";

            if (search.Name != "")
            {
                requestUrl += "label:" + search.Name + " ";
            }
            if (search.Alias != "")
            {
                requestUrl += "alias:" + search.Alias + " ";
            }
            if (search.Type != "")
            {
                requestUrl += "type:" + search.Type + " ";
            }

            System.Console.WriteLine(requestUrl);

            //
            // Get and Parse result
            //
            XmlDocument docRef = new XmlDocument();
            docRef.Load(requestUrl);
            XmlNode root = docRef.DocumentElement;
            XmlNode labelList = root.FirstChild;

            XmlNodeList labelNodes = labelList.ChildNodes;
            foreach (XmlNode labelNode in labelNodes)
            {
                LabelResult newLabel = new LabelResult();

                newLabel.Id = getAttributeValue(labelNode, "id");
                newLabel.Name = getTextChild(getNodeByName(labelNode, "name"));
                newLabel.Country = getTextChild(getNodeByName(labelNode, "country")); 

                XmlNode alias = getNodeByName(labelNode, "alias-list");
                newLabel.Alias = getTextChild(getNodeByName(alias, "alias"));

                label.Add(newLabel);
            }

            return label.ToArray();
        }

        public static WorkResult[] findWorks(WorkSearch search)
        {
            List<WorkResult> works = new List<WorkResult>();

            //
            // Build request Url
            //
            string requestUrl = serviceUrl + "/work/?query=";

            if (search.Artist != "")
            {
                requestUrl += "artist:" + search.Artist + " ";
            }
            if (search.Work != "")
            {
                requestUrl += "work:" + search.Work + " ";
            }
            if (search.WorkID != "")
            {
                requestUrl += "wid:" + search.WorkID + " ";
            }
            if (search.WorkType != "")
            {
                requestUrl += "type:" + search.WorkType + " ";
            }

            System.Console.WriteLine(requestUrl);

            //
            // Get and Parse result
            //
            XmlDocument docRef = new XmlDocument();
            docRef.Load(requestUrl);
            XmlNode root = docRef.DocumentElement;
            XmlNode workList = root.FirstChild;

            XmlNodeList workNodes = workList.ChildNodes;
            foreach (XmlNode workNode in workNodes)
            {
                WorkResult newWork = new WorkResult();

                newWork.Id = getAttributeValue(workNode, "id");
                newWork.Title = getTextChild(getNodeByName(workNode, "title"));

                XmlNode alias = getNodeByName(workNode, "alias-list");
                newWork.Alias = getTextChild(getNodeByName(alias, "alias"));

                works.Add(newWork);
            }

            return works.ToArray();
        }
    }
}
