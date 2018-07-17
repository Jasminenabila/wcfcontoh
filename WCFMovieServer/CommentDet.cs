using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFMovieServer
{   [DataContract]
    public class CommentDet
    {
        string judul, username, comment;
        [DataMember]
        public string Judul
        {
            get { return judul; }
            set { judul = value; }
        }
        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }


      

    }
}