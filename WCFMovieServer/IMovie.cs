using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFMovieServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIMovie" in both code and config file together.
    [ServiceContract]
    public interface IIMovie
    {
        [OperationContract]
        List<MovieDetails> getMovie();

        [OperationContract]
        List<MovieDetails> getMovieByJudul(string judul);

        [OperationContract]
        int regisUser(RegisDetails data);

        [OperationContract]
        int CommentUser(CommentDet data);

        [OperationContract]
        int getRating(MovieDetails data);

        [OperationContract]
        int deleteComment(string judul);

        [OperationContract]
        double CalculateRating(int totalrating, int submissionvotes, int totalvotes);
    }
}
