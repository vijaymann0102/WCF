#region Namespaces
using System.Collections.Generic;
using MoviesLibrary;
#endregion
namespace BusinessLayer
{
    public interface IBusinessAccess
    {
        List<MovieData> InternalGetMovies();

        void InsertMovie(MovieData movieData);

        void UpdateMovie(MovieData movieData);

        MovieData GetDataById(int Id);

        List<MovieData> GetAllData();

    }

}

