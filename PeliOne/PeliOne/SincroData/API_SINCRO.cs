using PeliOne.Services;
using PeliOne.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeliOne.SincroData
{
    
    public class API_SINCRO
    {
        public static List<VideoPointViewModel> _EnPointAPI;
        public static List<VideoPoinDetailViewModel> _EnPointAPIDetail;
        ApiServices _Services;
        public static string Message = "";

        public async System.Threading.Tasks.Task<List<VideoPointViewModel>> EndPoint(string Ambiente_, string _tabla, string key_ )
        {
            
            try
            {

                _EnPointAPI = new List<VideoPointViewModel>();
                _Services = new ApiServices();

                if (!String.IsNullOrWhiteSpace(key_) && !String.IsNullOrWhiteSpace(_tabla))
                {

                    

                    _EnPointAPI = await _Services.GetFiltre<VideoPointViewModel>
                        (
                            App.urlApi,
                            Ambiente_,
                            _tabla,
                            key_
                        );

                    return _EnPointAPI;
                }
                else
                {
                    
                    Message = "Datos vacios en el punto de acceso";
                    return null;
                }
            }
            catch (Exception exM)
            {
                Message = ApiServices.Mensaje;
                Console.WriteLine("error al consumir el api: " + exM.Message);
                return null;
            }
        }
        
        public async System.Threading.Tasks.Task<List<VideoPoinDetailViewModel>> EndPointDetail(string Ambiente_, string _tabla, string key_ )
        {
            
            try
            {

                _EnPointAPIDetail = new List<VideoPoinDetailViewModel>();
                _Services = new ApiServices();

                if (!String.IsNullOrWhiteSpace(key_) && !String.IsNullOrWhiteSpace(_tabla))
                {

                    

                    _EnPointAPIDetail = await _Services.GetFiltre<VideoPoinDetailViewModel>
                        (
                            App.urlApi,
                            Ambiente_,
                            _tabla,
                            key_
                        );

                    return _EnPointAPIDetail;
                }
                else
                {
                    
                    Message = "Datos vacios en el punto de acceso";
                    return null;
                }
            }
            catch (Exception exM)
            {
                Message = ApiServices.Mensaje;
                Console.WriteLine("error al consumir el api: " + exM.Message);
                return null;
            }
        }

    }
}
