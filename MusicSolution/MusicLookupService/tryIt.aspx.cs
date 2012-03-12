using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicInfo.SearchTypes;

namespace MusicLookupService
{
    public partial class tryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "";

            serviceProxy.MusicServiceClient client = new serviceProxy.MusicServiceClient();

            if (DropDownList1.Text == "findArtists")
            {
                ArtistSearch search = new ArtistSearch();
                search.Artist = TextBox1.Text;
                ArtistResult[] results = client.findArtists(search);

                foreach (ArtistResult result in results)
                {
                    TextBox2.Text += "Name: " + result.Name + "\n";
                    TextBox2.Text += "ID: " + result.Id + "\n";
                    TextBox2.Text += "Score: " + result.Score + "\n";
                    TextBox2.Text += "Country: " + result.Country + "\n";
                    TextBox2.Text += "Start Year: " + result.Begin + "\n";
                    TextBox2.Text += "End Year: " + result.End + "\n";
                    TextBox2.Text += "\n";
                }
            }
            if (DropDownList1.Text == "findReleaseGroups")
            {
                ReleaseGroupSearch search = new ReleaseGroupSearch();
                search.Release = TextBox1.Text;
                ReleaseGroupResult[] results = client.findReleaseGroups(search);

                foreach (ReleaseGroupResult result in results)
                {
                    TextBox2.Text += "Title: " + result.Title + "\n";
                    TextBox2.Text += "ID: " + result.Id + "\n";
                    TextBox2.Text += "Score: " + result.Score + "\n";
                    TextBox2.Text += "Type: " + result.Type + "\n";
                    TextBox2.Text += "\n";
                }
            }
            if (DropDownList1.Text == "findReleases")
            {
                ReleaseSearch search = new ReleaseSearch();
                search.ReleaseName = TextBox1.Text;
                ReleaseResult[] results = client.findReleases(search);

                foreach (ReleaseResult result in results)
                {
                    TextBox2.Text += "Title: " + result.Title + "\n";
                    TextBox2.Text += "ID: " + result.Id + "\n";
                    TextBox2.Text += "Score: " + result.Score + "\n";
                    TextBox2.Text += "\n";
                }
            }
            if (DropDownList1.Text == "findRecordings")
            {
                RecordingSearch search = new RecordingSearch();
                search.Recording = TextBox1.Text;
                RecordingResult[] results = client.findRecordings(search);

                foreach (RecordingResult result in results)
                {
                    TextBox2.Text += "Title: " + result.Title + "\n";
                    TextBox2.Text += "ID: " + result.Id + "\n";
                    TextBox2.Text += "Length: " + result.Length + "\n";
                    TextBox2.Text += "\n";
                }
            }
            if (DropDownList1.Text == "findLabels")
            {
                LabelSearch search = new LabelSearch();
                search.Name = TextBox1.Text;
                LabelResult[] results = client.findLabels(search);

                foreach (LabelResult result in results)
                {
                    TextBox2.Text += "Name: " + result.Name + "\n";
                    TextBox2.Text += "ID: " + result.Id + "\n";
                    TextBox2.Text += "Country: " + result.Country + "\n";
                    TextBox2.Text += "Alias: " + result.Alias + "\n";
                    TextBox2.Text += "\n";
                }
            }
            if (DropDownList1.Text == "findWorks")
            {
                WorkSearch search = new WorkSearch();
                search.Work = TextBox1.Text;
                WorkResult[] results = client.findWorks(search);

                foreach (WorkResult result in results)
                {
                    TextBox2.Text += "Title: " + result.Title + "\n";
                    TextBox2.Text += "ID: " + result.Id + "\n";
                    TextBox2.Text += "Alias: " + result.Alias + "\n";
                    TextBox2.Text += "\n";
                }
            }


            

        }
    }
}