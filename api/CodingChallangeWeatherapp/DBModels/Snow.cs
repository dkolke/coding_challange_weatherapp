namespace CodingChallangeWeatherapp.DBModels
{
    public class Snow
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Snow volume for the last 1 hour, mm
        /// </summary>
        public float One_Hour { get; set; }

        /// <summary>
        /// Snow volume for the last 3 hour, mm
        /// </summary>
        public float Three_Hour { get; set; }
    }
}
