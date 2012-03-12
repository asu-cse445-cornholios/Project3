using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using MusicInfo;
using MusicInfo.SearchTypes;

namespace MusicLookupService
{
    public class MusicService : IMusicService
    {
        public ArtistResult[] findArtists(ArtistSearch search)
        {
            return MediaLibrary.findArtists(search);
        }

        public ReleaseGroupResult[] findReleaseGroups(ReleaseGroupSearch search)
        {
            return MediaLibrary.findReleaseGroups(search);
        }

        public ReleaseResult[] findReleases(ReleaseSearch search)
        {
            return MediaLibrary.findReleases(search);
        }

        public RecordingResult[] findRecordings(RecordingSearch search)
        {
            return MediaLibrary.findRecordings(search);
        }

        public LabelResult[] findLabels(LabelSearch search)
        {
            return MediaLibrary.findLabels(search);
        }

        public WorkResult[] findWorks(WorkSearch search)
        {
            return MediaLibrary.findWorks(search);
        }
    }
}
