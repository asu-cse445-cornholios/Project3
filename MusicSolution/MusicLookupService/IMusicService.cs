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
    [ServiceContract]
    public interface IMusicService
    {
        [OperationContract]
        ArtistResult[] findArtists(ArtistSearch search);

        [OperationContract]
        ReleaseGroupResult[] findReleaseGroups(ReleaseGroupSearch search);

        [OperationContract]
        ReleaseResult[] findReleases(ReleaseSearch search);

        [OperationContract]
        RecordingResult[] findRecordings(RecordingSearch search);

        [OperationContract]
        LabelResult[] findLabels(LabelSearch search);

        [OperationContract]
        WorkResult[] findWorks(WorkSearch search);
    }


}
