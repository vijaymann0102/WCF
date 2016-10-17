using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WcfMovie;
using MoviesLibrary;


namespace UnitTest
{
    #region AllUnitTestCases
    [TestClass]
    public class WcfMovieTest
    {
        #region ObjectsInitialised
        Movie movie = new Movie();
        MovieDataSource movieDataSource = new MovieDataSource();
        #endregion

        #region UnitTestGetAllMovieFunction
        [TestMethod]
        public void GetAllMoviesTest()
        {
            int ActualCount = movie.GetAllMovies().Result.Count;
            Assert.AreEqual(80, ActualCount);
        }
        #endregion

        #region InsertMovieUnitTest
        [TestMethod]
        public void InsertMovie()
        {
            MovieData moviedata = new MovieData();
            moviedata.Rating = 1;
            moviedata.ReleaseDate = DateTime.Now.Day;
            moviedata.Title = "Insert Unit Test";
            moviedata.Genre = "AA";
            moviedata.Classification = "A";
            moviedata.Cast = new String[] { "Amitabh", "SriDevi" };
            int Count = movieDataSource.GetAllData().Count + 1;
            movie.InsertMovie(moviedata);
            int ActualCount = movieDataSource.GetAllData().Count;
            Assert.AreEqual(Count, ActualCount);
        }
        #endregion

        #region UpdateMovieUnitTest
        [TestMethod]
        public void UpdateMovie()
        {
            MovieData moviedata = new MovieData();
            MovieData movienew = movieDataSource.GetDataById(10);
            moviedata.Title = "Insert Unit Test";
            movie.UpdateMovie(moviedata, 10);
            string NewTitle = movieDataSource.GetDataById(10).Title;
            Assert.AreEqual(moviedata.Title, NewTitle);
        }
        #endregion

        #region SortByFieldUnitTest
        [TestMethod]
        public void SortbyField()
        {
            List<MovieData> results = movieDataSource.GetAllData();
            CollectionAssert.AreNotEqual((List<MovieData>)results.OrderBy(x => x.Classification).ToList(), movie.SortbyField("Classification").Result);
        }
        #endregion

        #region SearchByFieldUnitTest
        [TestMethod]
        public void SearchbyField()
        {
            List<MovieData> results = movieDataSource.GetAllData();
            Assert.AreEqual(results.FindAll(m => m.Classification == "A").Count, movie.SearchbyField("Classification", "A").Result.Count);

        }
        #endregion
    }
    #endregion
}
