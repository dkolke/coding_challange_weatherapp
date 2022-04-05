using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallangeWeatherapp.DBModels
{
    public class WeatherData
    {
        /// <summary>
        /// City Id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// City Name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Time of data calculation, unix, UTC.
        /// </summary>
        public virtual DateTime Dt { get; set; }

        /// <summary>
        /// Visibility, meter. The maximum value of the visibility is 10km
        /// </summary>
        public virtual float Visibility { get; set; }

        /// <summary>
        /// Shift in seconds from UTC
        /// </summary>
        public virtual int Timezone { get; set; }

        public int? CoordId { get; set; }

        public virtual Coord Coord { get; set; }

        public int? WeatherId { get; set; }

        public virtual Weather Weather { get; set; }

        public int? MainId { get; set; }

        public virtual Main Main { get; set; }

        public int? WindId { get; set; }

        public virtual Wind Wind { get; set; }

        public int? CloudsId { get; set; }

        public virtual Clouds Clouds { get; set; }

        public int? RainId { get; set; }

        public virtual Rain Rain { get; set; }

        public int? SnowId { get; set; }

        public virtual Snow Snow { get; set; }
    }
}
