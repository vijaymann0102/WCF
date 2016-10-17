#region NameSpaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using MoviesLibrary;
using log4net;
using System.Configuration;

using BusinessLayer;
#endregion


namespace WcfMovie
{
    #region MovieService
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Movie : IService2
    {
        #region Initialisedobjects
        MovieDataSource movieDataSource;
        BusinessAccess access;
        _FaultData errorInfo;
        private static ILog Log = LogManager.GetLogger("WcfMovie");
        public Movie()
        {
            movieDataSource = new MovieDataSource();
            access = new BusinessAccess();
            errorInfo = new _FaultData();
            //log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(ConfigurationManager.AppSettings["PathLogConfig"]));
        }
        #endregion

        #region GetAllMovies
        /// <summary>
        /// Get all the movies data present in existing database
        /// <para>No Paramters Required</para>
        /// </summary>
        /// <returns>All Movies in Xml Format</returns>
        public Task<List<MovieData>> GetAllMovies()
        {
            try
            {
                return Task<List<MovieData>>.Factory.StartNew(InternalGetMovies);
            }
            catch (Exception ex)
            {
                LogErrorDetails(ex.Message, "GetAllMovies", ex.InnerException.ToString());
                throw new ApplicationException("");
            }
            finally
            {
             
            }
        }



        /// <summary>
        /// The Function called by GetAllMovies for fetching  data asyncronously
        /// <para>No Paramater Required</para>
        /// </summary>
        /// <returns>A generic list of Movie Data Objects</returns>
        [AspNetCacheProfile("ClientCache")]
        private List<MovieData> InternalGetMovies()
        {
            List<MovieData> movieData = access.InternalGetMovies();
            return movieData;
        }
        #endregion

        #region InsertMovie
        /// <summary>
        /// Insert a movie Record in the DataBase
        /// <para>Object of Movie Data</para>
        /// </summary>
        /// <returns>Nothing/Void</returns>
        public void InsertMovie(MovieData movieData)
        {
            try
            {
                if (movieData != null)
                {
                    if (movieData.Cast == null || movieData.Classification == null || movieData.Genre == null || movieData.Rating == 0 || movieData.ReleaseDate == 0 || movieData.Title == null)
                    {
                        //Please input the Data
                        //We can also raise a fault Expection Here
                        //In Case Cast is empty still insert
                    }
                    else
                        access.InsertMovie(movieData);
                }
            }
            catch (Exception ex)
            {
                LogErrorDetails(ex.Message, "InsertMovie", ex.InnerException.ToString());
                throw new ApplicationException("Error occured while getting movies");
            }
            finally
            {
                //Dispose unwanted objects here
                
            }

        }
        #endregion

        #region UpdateMovie
        /// <summary>
        /// Updates the movie based on movie ID
        /// <para>Object of Movie Data and Associated MovieID to update data to</para>
        /// </summary> 
        /// <returns>Nothing/Void</returns>
        public void UpdateMovie(MovieData movieData, int movieId)
        {
            try
            {
               MovieData movie = access.GetDataById(movieId);
               if (movie != null)
                {
                    if (movieData.Cast == null && movieData.Classification == null && movieData.Genre == null && movieData.Rating == 0 && movieData.ReleaseDate == 0 && movieData.Title == null)
                    {
                        //Please input some Data
                        //Update all data to null or 0 is not valid data
                        //We can also raise a fault Expection Here
                        //In Case Cast is empty still insert
                    }
                    else
                    {
                        movie.Rating = movieData.Rating;
                        movie.ReleaseDate = movieData.ReleaseDate;
                        movie.Title = movieData.Title;
                        movie.Genre = movieData.Genre;
                        movie.Classification = movieData.Classification;
                        movie.Cast = movieData.Cast;
                        access.UpdateMovie(movie);
                    }
                }

            }
            catch (Exception ex)
            {
                LogErrorDetails(ex.Message, "UpdateMovie", ex.InnerException.ToString());
                throw new ApplicationException("Error occured while getting data!");
            }
            finally
            {
            
            }
        }
        #endregion

        #region SearchByField
        /// <summary>
        /// Function is used for search a particular text in a particular Field
        /// <para>ColumnName -the column to be searched and texttosearch -the value to be searched in that column</para>
        /// </summary>
        /// <returns>A generic list of Movie Data Objects found based on parameters passed.The actual data is returned by the function that has been called in startnew</returns>

        public Task<List<MovieData>> SearchbyField(string columnname, string textToSearch)
        {
            try
            {
                return Task<List<MovieData>>.Factory.StartNew(() => InternalSearchbyField(columnname, textToSearch));
            }
            catch (Exception ex)
            {
                LogErrorDetails(ex.Message, "SearchbyField", ex.InnerException.ToString());
                throw new ApplicationException("Error occured while search!");
            }
            finally
            {

            }
        }

        /// <summary>
        /// Function is used for search a particular text in a particular Field
        /// <para>ColumnName -the column to be searched and texttosearch -the value to be searched in that column</para>
        /// </summary>
        /// <returns>A generic list of Movie Data Objects found based on parameters passed.</returns>

        [AspNetCacheProfile("ClientCache")]
        private List<MovieData> InternalSearchbyField(string columnname, string textToSearch)
        {
            List<MovieData> results = access.GetAllData();
            if (!string.IsNullOrEmpty(columnname))
            {
                switch (columnname)
                {
                    case "Classification":
                        results = (List<MovieData>)results.FindAll(
                        delegate(MovieData mv)
                        {
                            return mv.Classification == textToSearch;
                        }
                        );

                        break;

                    case "Genre":
                        results = (List<MovieData>)results.FindAll(
                          delegate(MovieData mv)
                          {
                              return mv.Genre == textToSearch;
                          }
                          );
                        break;
                    case "MovieId":
                        results = (List<MovieData>)results.FindAll(
                      delegate(MovieData mv)
                      {
                          return mv.MovieId == int.Parse(textToSearch);
                      }
                      );
                        break;
                    case "Rating":
                        results = (List<MovieData>)results.FindAll(
                     delegate(MovieData mv)
                     {
                         return mv.Rating == int.Parse(textToSearch);
                     }
                     );
                        break;
                    case "ReleaseDate":
                        results = (List<MovieData>)results.FindAll(
                     delegate(MovieData mv)
                     {
                         return mv.ReleaseDate == int.Parse(textToSearch);
                     }
                     );
                        break;
                    case "Title":
                        results = (List<MovieData>)results.FindAll(
                    delegate(MovieData mv)
                    {
                        return mv.Title == textToSearch;
                    }
                    );
                        break;
                    case "Cast":
                        results = (List<MovieData>)results.FindAll(
                    delegate(MovieData mv)
                    {
                        //Assuming the max length of cast array to be 4 for time being.
                        switch (mv.Cast.Length)
                        {
                            case 4: return mv.Cast[0] == textToSearch || mv.Cast[1] == textToSearch || mv.Cast[2] == textToSearch || mv.Cast[3] == textToSearch;
                            case 3: return mv.Cast[0] == textToSearch || mv.Cast[1] == textToSearch || mv.Cast[2] == textToSearch;
                            case 2: return mv.Cast[0] == textToSearch || mv.Cast[1] == textToSearch;
                            case 1: return mv.Cast[0] == textToSearch;
                            default:
                                return false;
                        }
                    }
                    );
                        break;
                    default:
                        break;

                }
            }
            return results;
        }
        #endregion

        #region SortByField
        /// <summary>
        /// Sorts the data based on a particular field in the datasource
        /// <para>The Name of field to sort data from</para>
        /// </summary>
        /// <returns>A generic list of Movie Data Objects found based on parameters passed.Which Actually is retruned by the method called in StartNew</returns>
        public Task<List<MovieData>> SortbyField(string fieldname)
        {
            return Task<List<MovieData>>.Factory.StartNew(() => InternalSortbyField(fieldname));
        }


        /// <summary>
        /// Sorts the data based on a particular field in the datasource
        /// <para>The Name of field to sort data from</para>
        /// </summary>
        /// <returns>A generic list of Movie Data Objects found based on parameters passed.</returns>
        private List<MovieData> InternalSortbyField(string fieldname)
        {
            try
            {
                List<MovieData> results = access.GetAllData();
                if (!string.IsNullOrEmpty(fieldname))
                {
                    switch (fieldname)
                    {
                        case "Classification":
                            results = results.OrderBy(x => x.Classification).ThenBy(x => x.Classification).ToList();
                            break;
                        case "Genre":
                            results = results.OrderBy(x => x.Genre).ThenBy(x => x.Genre).ToList();
                            break;
                        case "MovieId":
                            results = results.OrderBy(x => x.MovieId).ThenBy(x => x.MovieId).ToList();
                            break;
                        case "Rating":
                            results = results.OrderBy(x => x.Rating).ThenBy(x => x.Rating).ToList();
                            break;
                        case "ReleaseDate":
                            results = results.OrderBy(x => x.ReleaseDate).ThenBy(x => x.ReleaseDate).ToList();
                            break;
                        case "Title":
                            results = results.OrderBy(x => x.Title).ThenBy(x => x.Title).ToList();
                            break;
                        default:
                            break;
                    }
                }
                return results;
            }

            catch (Exception ex)
            {
                LogErrorDetails(ex.Message, "InternalSortbyField", ex.InnerException.ToString());
            }
            return new List<MovieData>();
        }

        private void LogErrorDetails(string ErrorDetails,string MethodName,string innerException)
        {
            errorInfo.Result = true;
            errorInfo.ErrorMessage = "Error in GetAllMovies";
            errorInfo.ErrorDetails = ErrorDetails;
            Log.Info("Error Method:" + MethodName);
            Log.Error(new FaultException<_FaultData>(errorInfo, innerException));
        }
        #endregion
    }
    #endregion
}
