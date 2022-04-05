using CodingChallangeWeatherapp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallangeWeatherapp.DBModels
{
    public class Weather
    {
        /// <summary>
        /// Weather condition id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Group of wether paramters (Rain, Snow, Extreme, etc.)
        /// </summary>
        [Column(TypeName = "nvarchar(24)")] 
        public EWeatherGroup Main { get; set; }

        /// <summary>
        /// Weather condition within the group.
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Weather icon id.
        /// </summary>
        //Alternativ auch als ENUM
        public string Icon { get; set; }

        /*
         * Bekannte IDs:
         * 
         * 01d, 02d, 03d, 04d, 09d, 10d, 11d, 13d, 50d
         * 
         */
    }
}
