using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFMovieServer
{
    [DataContract]
    public class VoteDetails
    {
        string ratingID, judul, rating, date;

        [DataMember]
        public string RatingID
        {
            get { return ratingID; }
            set { ratingID = value; }
        }

        [DataMember]
        public string Judul
        {
            get { return judul; }
            set { judul = value; }
        }

        [DataMember]
        public string Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        [DataMember]
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}