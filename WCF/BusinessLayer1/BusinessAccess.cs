#region Namespaces
using System.Collections.Generic;
using DataAccess;
using MoviesLibrary;
#endregion
namespace BusinessLayer
{
    public class BusinessAccess : IBusinessAccess
    {
        #region BusinessAccess
        private DataAccess.DataAccess access;

        public BusinessAccess()
        {
            access = new DataAccess.DataAccess();
        }
        /// <summary>
        /// Get all the movies data present in existing database
        /// <para>No Paramters Required</para>
        /// </summary>
        /// <returns>All Movies in Genric list of MovieData</returns>
        public List<MovieData> InternalGetMovies()
        {
            return access.GetAllData();
     
        }

        /// <summary>
        /// Inserts a movie into the database
        /// <para>MovieData object details to be inserted</para>
        /// </summary>
        /// <returns>void</returns>
        public void InsertMovie(MovieData movieData)
        {
            access.InsertMovie(movieData);
        }

        /// <summary>
        /// Updates the movieData into database
        /// <para>MovieDataTobeUpdated into contains movieId as well for which the updation has to be done.</para>
        /// </summary>
        /// <returns>void</returns>
        public void UpdateMovie(MovieData movieData)
        {
            access.UpdateMovie(movieData);
        }

        /// <summary>
        /// Gets the movie information by movie Id
        /// <para>Id of the movie to get details of</para>
        /// </summary>
        /// <returns>Returns object of moviedata having all the info</returns>
        public MovieData GetDataById(int Id)
        {
            return access.GetDataById(Id);
        }

        /// <summary>
        /// Returns the generic list of movieData objects
        /// <para>No Paramters Required</para>
        /// </summary>
        /// <returns>All Movies Details in db currently</returns>
        public List<MovieData> GetAllData()
        {
            return access.GetAllData();
        }
    }
    #endregion


}

