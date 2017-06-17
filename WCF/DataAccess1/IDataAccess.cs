#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoviesLibrary;
#endregion

namespace DataAccess
{
    public interface IDataAccess
    {

        List<MovieData> InternalGetMovies();

        void InsertMovie(MovieData movieData);

        void UpdateMovie(MovieData movieData);

        MovieData GetDataById(int Id);

        List<MovieData> GetAllData();
      
    }

}
