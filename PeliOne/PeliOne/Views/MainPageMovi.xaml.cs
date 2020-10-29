using PeliOne.SincroData;
using PeliOne.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeliOne.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMovi : ContentPage
    {
        API_SINCRO sincro_ = new API_SINCRO();
        public static List<VideoPoinDetailViewModel> dataDetail;

        public MainPageMovi()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Iniciar();
        }

        #region Methods

        private async Task cargaDatos(String tabla_, int lista_)
        {
            List<MovieList1> movieLists_ = new List<MovieList1>();
            try
            {
                var img_ = new List<String>();
                var date_ = new List<String>();
                var name_ = new List<String>();
                var data = await sincro_.EndPoint("", tabla_, "266b1f1010336734c5cad16f255ca1f3");
                if (data != null)
                {
                    int count = 0;
                    int countVard = 0;
                    foreach (var itemD in data.First().results)
                    {
                        if (countVard < 3)
                        {
                            count++;
                            if (count <= 3)
                            {
                                img_.Add("https://image.tmdb.org/t/p/w500/" + itemD.poster_path);
                                date_.Add(itemD.id.ToString());
                                name_.Add(itemD.original_title);
                            }
                            else
                            {
                                countVard++;
                                count = 0;
                                var m = new MovieList1
                                {
                                    ImageUrl = img_[0],
                                    ImageUr2 = img_[1],
                                    ImageUr3 = img_[2],
                                    Date1 = date_[0],
                                    Date2 = date_[1],
                                    Date3 = date_[2],
                                    Name1 = name_[0],
                                    Name2 = name_[1],
                                    Name3 = name_[2],
                                };
                                movieLists_.Add(m);

                                img_ = new List<String>();
                                date_ = new List<String>();
                                name_ = new List<String>();
                            }
                        }
                       

                        //var m = new MovieList1
                        //{
                        //    ImageUrl = "https://image.tmdb.org/t/p/w500/" + itemD.poster_path,
                        //    Date = itemD.release_date,
                        //    Name = itemD.original_title
                        //};
                        //movieLists_.Add(m);
                    }

                    if (lista_ == 0)
                        clwMovie.ItemsSource = movieLists_;
                    else if (lista_ == 1)
                        clwMovieUpcoming.ItemsSource = movieLists_;
                    else if (lista_ == 2)
                        clwMoviePopular.ItemsSource = movieLists_;

                }



            }
            catch (Exception exM)
            {
                Console.WriteLine("Error: " + exM.Message);
            }

        }

        private async void Iniciar()
        {
            try
            {
                lytEspera.IsVisible = true;
                actCarga.IsRunning = true;
                await StartAction();

            }
            catch (Exception exM)
            {
                Console.WriteLine(exM.Message);
            }
        }
        private async System.Threading.Tasks.Task StartAction()
        {
            try
            {
                await cargaDatos("3/movie/top_rated",0);
                await cargaDatos("3/movie/upcoming", 1);
                await cargaDatos("3/movie/popular", 2);
                
                await WaitAndExecute(7300, () =>
                {

                    lytEspera.IsVisible = false;
                    actCarga.IsRunning = false;

                });


            }
            catch (Exception exM)
            {
                Console.WriteLine("\nError de inicio: " + exM.Message);
            }
            
        }
        protected async System.Threading.Tasks.Task WaitAndExecute(int milisec, Action actionToExecute)
        {

            await System.Threading.Tasks.Task.Delay(milisec);
            //Action doWorkAction = new Action(StartAction);
            //doWorkAction();
            actionToExecute();
            
        }

        private async Task GoDetailMovie(String id, String tabla_) 
        {
            try 
            {
                dataDetail = await sincro_.EndPointDetail("", tabla_ + "/" + id, "266b1f1010336734c5cad16f255ca1f3");

            }
            catch (Exception exM)
            {
                Console.WriteLine("Error: " + exM.Message + "\n");
            }
        }
        #endregion

        #region events
        //Evento que octiene la id de la imagen para vincular con detalle
        private async void tapImage1_Tapped(object sender, EventArgs e)
        {
            var img_id = (TappedEventArgs)e;
            var id_ = img_id.Parameter.ToString();
            lytEspera.IsVisible = true;
            actCarga.IsRunning = true;
            await GoDetailMovie(id_, "3/movie");
            await Navigation.PushAsync(new MoviDetailPage());
            lytEspera.IsVisible = false;
            actCarga.IsRunning = false;
        }

        #endregion

        
    }

    public class MovieList1
    {
        public string ImageUrl { get; set; }
        public string ImageUr2 { get; set; }
        public string ImageUr3 { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Date1 { get; set; }
        public string Date2 { get; set; }
        public string Date3 { get; set; }
        
    }
}