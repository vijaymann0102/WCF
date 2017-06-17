#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoviesLibrary;
#endregion

namespace DataAccess
{
    public class DataAccess : IDataAccess
    {
        #region DataAccessLayer
        MovieDataSource movieDataSource;

        public DataAccess()
        {
            movieDataSource = new MovieDataSource();
        }
        /// <summary>
        /// Get all the movies data present in existing database
        /// <para>No Paramters Required</para>
        /// </summary>
        /// <returns>All Movies in Genric list of MovieData</returns>
        public  List<MovieData> InternalGetMovies()
        {
            List<MovieData> movieData = movieDataSource.GetAllData();
            return movieData;
        }

        /// <summary>
        /// Inserts a movie into the database
        /// <para>MovieData object details to be inserted</para>
        /// </summary>
        /// <returns>void</returns>
        public void InsertMovie(MovieData movieData)
        {
            movieDataSource.Create(movieData);
        }

        /// <summary>
        /// Updates the movieData into database
        /// <para>MovieDataTobeUpdated into contains movieId as well for which the updation has to be done.</para>
        /// </summary>
        /// <returns>void</returns>
        public void UpdateMovie(MovieData movieData)
        {
            movieDataSource.Update(movieData);
        }

        /// <summary>
        /// Gets the movie information by movie Id
        /// <para>Id of the movie to get details of</para>
        /// </summary>
        /// <returns>Returns object of moviedata having all the info</returns>
        public MovieData GetDataById(int Id)
        {
            return movieDataSource.GetDataById(Id);
        }

        /// <summary>
        /// Returns the generic list of movieData objects
        /// <para>No Paramters Required</para>
        /// </summary>
        /// <returns>All Movies Details in db currently</returns>
        public List<MovieData> GetAllData()
        {
            return movieDataSource.GetAllData();
        }
    }
        #endregion
}
