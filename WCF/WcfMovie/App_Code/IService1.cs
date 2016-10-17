#region NameSpaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MoviesLibrary;
#endregion
namespace WcfMovie
{
    #region ServiceContract
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {

        #region AllOperationContracts
        [OperationContract(AsyncPattern=true)]
        [WebInvoke(Method = "GET")]
        [FaultContract(typeof(_FaultData))]
        Task<List<MovieData>> GetAllMovies();

        [OperationContract()]
        [WebInvoke(Method = "POST")]
        [FaultContract(typeof(_FaultData))]
        void InsertMovie(MovieData moviedata);

        [OperationContract()]
        [WebInvoke(Method = "POST",BodyStyle=WebMessageBodyStyle.Wrapped)]
        [FaultContract(typeof(_FaultData))]
        void UpdateMovie(MovieData moviedata,int movieId);
                
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET")]
        [FaultContract(typeof(_FaultData))]
        Task<List<MovieData>> SearchbyField(string columnname, string texttosearch);

        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET")]
        [FaultContract(typeof(_FaultData))]
        Task<List<MovieData>> SortbyField(string fieldname);
        #endregion

    }
    #region Fault DataContract
    //This contract has been added for fault details
    [DataContract]
    public class _FaultData
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string ErrorDetails { get; set; }
    }
   #endregion
    
#endregion
}
