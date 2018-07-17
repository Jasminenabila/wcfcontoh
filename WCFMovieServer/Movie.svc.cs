using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace WCFMovieServer
{
   public class IMovie : IIMovie
    {

        public List<MovieDetails> getMovieByJudul(string judul)
        {
            koneksi kon = new koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<MovieDetails> objList = new List<MovieDetails>();
            MovieDetails objMovie = new MovieDetails();

            using (sqlcon)
            {
                sqlcon.Open();

                string sql = "select * from movie where judul= @judul";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);

                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@judul", judul);
                    SqlDataReader dr = sqlcom.ExecuteReader();

                    if (dr.Read())
                    {
                        objMovie.Foto = dr.GetByte(0);
                        objMovie.Judul = dr.GetString(1);
                        objMovie.Durasi = dr.GetString(2);
                        objMovie.Publikasi = dr.GetString(3);
                        objMovie.Genre = dr.GetString(4);
                        objMovie.Sutradara = dr.GetString(5);
                        objMovie.Sinopsis = dr.GetString(6);
                        objMovie.Rating = dr.GetString(7);
                        objMovie.Status = dr.GetString(8);
                        objMovie.Cast = dr.GetString(9);
                        objMovie.Trailer = dr.GetString(10);
                        

                        objList.Add(objMovie);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }
        public double CalculateRating(int totalrating, int submissionvotes, int totalvotes)
        {
            IMovie movie = new IMovie();

            double a = ((double)totalrating / (double)submissionvotes) * Math.Sqrt(((double)submissionvotes / 2) / ((double)totalvotes / 2));

            return a;
        }

        public int deleteComment(string judul)
        {
            koneksi kon = new koneksi();
            SqlConnection sqlcon = kon.getConnection();
            int result = 0;

            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "delete from Comment where judul = @judul";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@judul", judul);
                    result = sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
            return result;
        }


        public List<MovieDetails> getMovie()
        {
            koneksi kon = new koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<MovieDetails> objList = new List<MovieDetails>();

            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select * from movie";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);

                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();

                    while (dr.Read())
                    {
                        MovieDetails objMovie = new MovieDetails();
                        byte[] Buffer = new byte[100];
                        
                        objMovie.Judul = dr.GetString(0);
                        objMovie.Durasi = dr.GetString(1);
                        objMovie.Publikasi = dr.GetString(2);
                        objMovie.Genre = dr.GetString(3);
                        objMovie.Sutradara = dr.GetString(4);
                        objMovie.Cast = dr.GetString(5);
                        objMovie.Sinopsis = dr.GetString(6);
                        objMovie.Rating = dr.GetString(7);
                        objMovie.Status = dr.GetString(8); 
                        objMovie.Trailer = dr.GetString(9);
                        objMovie.Foto = dr.GetBytes(10, 0, Buffer, 0, 100);

                        objList.Add(objMovie);
                    }
                }
                sqlcon.Close();
            }
            return objList;

        }

        public int login(LoginDetails data)
        {
            koneksi kon = new koneksi();
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            //SqlConnection sqlcon = kon.getConnection();
            int result = 0;

            using (sqlcon)
            {
                sqlcon.Open();

                string sql = "select count(*) from Regis where username=@username and password=@password";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);

                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@username", data.Username);
                    sqlcom.Parameters.AddWithValue("@password", data.Password);


                    result = sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();

            }
            return result;
        }

        public int getRating(MovieDetails data)
        {
            koneksi kon = new koneksi();
            SqlConnection sqlcon = kon.getConnection();
            int TotalRating = 0;

            using(sqlcon)
            {
                sqlcon.Open();

                string sql = "select count(*) from movie where judul=@judul";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                
                using(sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@judul", data.Judul);

                    SqlDataReader sdr = sqlcom.ExecuteReader();

                    while (sdr.Read())
                    {
                        TotalRating = sdr.GetInt32(0);
                    }
                }
                sqlcon.Close();
            }
            return TotalRating;
        }

        public int regisUser(RegisDetails data)
        {
            koneksi kon = new koneksi();
            SqlConnection sqlcon = kon.getConnection();
            int result = 0;

            using (sqlcon)
            {
                sqlcon.Open();

                string sql = "insert into Regis values (@username, @email, @password, @repassword)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);

                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@username", data.Username);
                    sqlcom.Parameters.AddWithValue("@email", data.Email);
                    sqlcom.Parameters.AddWithValue("@password", data.Password);
                    sqlcom.Parameters.AddWithValue("@repassword", data.Repassword);

                    result = sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();

            }
            return result;
        }
        public int CommentUser(CommentDet data)
        {
            koneksi kon = new koneksi();
            SqlConnection sqlcon = kon.getConnection();
            int result = 0;

            using (sqlcon)
            {
                sqlcon.Open();

                string sql = "insert into Comment values (@Judul, @Username, @Comment)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);

                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@Judul", data.Judul);
                    sqlcom.Parameters.AddWithValue("@Username", data.Username);
                    sqlcom.Parameters.AddWithValue("@Comment", data.Comment);

                    
                    result = sqlcom.ExecuteNonQuery();
                }
                sqlcon.Close();

            }
            return result;
        }
       

    }
}
