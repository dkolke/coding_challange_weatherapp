namespace CodingChallangeWeatherapp.DBModels
{
    public class Rain
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Rain volume for the last 1 hour, mm
        /// </summary>
        public float One_Hour { get; set; }

        /// <summary>
        /// Rain volume for the last 3 hour, mm
        /// </summary>
        public float Three_Hour { get; set; }
    }
}
