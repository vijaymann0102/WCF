using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoviesLibrary;
using WcfMovie;

namespace WebClient
{
    public partial class TestingPage : System.Web.UI.Page
    {
          Movie movie = new Movie();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnTest_Click(object sender, EventArgs e)
        {
          this.gvData.DataSource= (IEnumerable<MovieData>) movie.GetAllMovies().Result.ToList();
          this.gvData.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            MovieData data = new MovieData();
            data.Cast = new string[] { txtCast.Text };
            data.Classification = txtClassification.Text;
            data.Genre = txtGenre.Text;
            data.Rating = int.Parse(txtRating.Text);
            data.ReleaseDate = int.Parse(txtReleaseDate.Text);
            data.Title = txtTitle.Text;
            movie.InsertMovie(data);
            gvData.DataSource = (IEnumerable<MovieData>)movie.GetAllMovies().Result.ToList();
            gvData.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            MovieData data = new MovieData();
            data.Cast = new string[] { txtCastU.Text };
            data.Classification = txtClassificationU.Text;
            data.Genre = txtGenreU.Text;
            data.Rating = int.Parse(txtRatingU.Text);
            data.ReleaseDate = int.Parse(txtReleaseDateU.Text);
            data.Title = txtTitleU.Text;
            data.MovieId = int.Parse(txtMovieId.Text);
            movie.UpdateMovie(data, data.MovieId);
            gvData.DataSource = (IEnumerable<MovieData>)movie.GetAllMovies().Result.ToList();
            gvData.DataBind();
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            gvData.DataSource =(IEnumerable<MovieData>) movie.SearchbyField(txtColumnName.Text, txtToSearch.Text).Result.ToList();
            gvData.DataBind();

        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            gvData.DataSource = (IEnumerable<MovieData>)movie.SortbyField(txtSort.Text).Result.ToList();
            gvData.DataBind();
        }
        }
    }

