namespace CodingChallangeWeatherapp.DBModels
{
    public class Main
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public float Temp { get; set; }

        /// <summary>
        /// Temperature. This temperature parameter accounts for the human perception of weather. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public float Feels_Like { get; set; }

        /// <summary>
        /// Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
        /// </summary>
        //Ggf. kann hier auch short benutzt werden
        public int? Pressure { get; set; }

        /// <summary>
        /// Humidity, %
        /// </summary>
        public short Humidity { get; set; }

        /// <summary>
        /// Minimum temperature at the moment. This is minimal currently observed temperature (within large megalopolises and urban areas). 
        /// Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public float Temp_Min { get; set; }

        /// <summary>
        /// Maximum temperature at the moment. This is maximal currently observed temperature (within large megalopolises and urban areas). 
        /// Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public float Temp_Max { get; set; }

        /// <summary>
        /// Atmospheric pressure on the sea level, hPa
        /// </summary>
        //Sea- und Ground Level sind mir unklar. Ich nehme an, die Einheit ist die gleiche wie bei Pressure.
        public int? Sea_Level { get; set; }

        /// <summary>
        /// Atmospheric pressure on the ground level, hPa
        /// </summary>
        public int? Grnd_Level { get; set; }
    }
}
