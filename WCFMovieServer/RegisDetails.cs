using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFMovieServer
{
    [DataContract]

    public class RegisDetails
    {
        string username, email, password, repassword;

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public string Repassword
        {
            get { return repassword; }
            set { repassword = value; }
        }
    }
}