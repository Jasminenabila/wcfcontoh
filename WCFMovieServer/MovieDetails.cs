using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFMovieServer
{
    [DataContract]
    public class MovieDetails
    {
        string judul, durasi, publikasi, genre, sutradara, sinopsis, rating, status, cast, trailer;
        long foto;

        [DataMember]
        public string Judul
        {
            get { return judul; }
            set { judul = value; }
        }

        [DataMember]
        public String Durasi
        {
            get { return durasi; }
            set { durasi = value; }
        }

        [DataMember]
        public String Publikasi
        {
            get { return publikasi; }
            set { publikasi = value; }
        }

        [DataMember]
        public String Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        [DataMember]
        public String Sutradara
        {
            get { return sutradara; }
            set { sutradara = value; }
        }

        [DataMember]
        public String Cast
        {
            get { return cast; }
            set { cast = value; }
        }

        [DataMember]
        public String Sinopsis
        {
            get { return sinopsis; }
            set { sinopsis = value; }
        }

        [DataMember]
        public String Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        [DataMember]
        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public String Trailer
        {
            get { return trailer; }
            set { trailer = value; }
        }

        [DataMember]
        public long Foto
        {
            get { return foto; }
            set { foto = value; }
        }
    }
}