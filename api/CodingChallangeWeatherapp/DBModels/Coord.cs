namespace CodingChallangeWeatherapp.DBModels
{
    public class Coord
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// City geo location, longitude.
        /// </summary>
        public float Lon { get; set; }

        /// <summary>
        /// City geo location, latitude.
        /// </summary>
        public float Lat { get; set; }
    }
}
