using CodingChallangeWeatherapp.DBModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CodingChallangeWeatherapp.Data
{
    public class DataContext : DbContext
    {
        #region Tables
        public virtual DbSet<WeatherData> WeatherData { get; set; }

        public virtual DbSet<Wind> Wind { get; set; }

        public virtual DbSet<Weather> Weather { get; set; }

        public virtual DbSet<Snow> Snow { get; set; }

        public virtual DbSet<Rain> Rain { get; set; }

        public virtual DbSet<Main> Main { get; set; }

        public virtual DbSet<Coord> Coord { get; set; }

        public virtual DbSet<Clouds> Clouds { get; set; }
        #endregion


        private readonly IHttpContextAccessor _httpContextAccessor;

        public string Url
        {
            get
            {
                return _httpContextAccessor.HttpContext?.Request.GetDisplayUrl() ?? "";
            }
        }

        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAcc)
            : base(options)
        {
            _httpContextAccessor = httpContextAcc;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clouds>().HasKey(o => new { o.Id });
            modelBuilder.Entity<Coord>().HasKey(o => new { o.Id });
            modelBuilder.Entity<Main>().HasKey(o => new { o.Id });
            modelBuilder.Entity<Rain>().HasKey(o => new { o.Id });
            modelBuilder.Entity<Snow>().HasKey(o => new { o.Id });
            modelBuilder.Entity<Weather>().HasKey(o => new { o.Id });
            modelBuilder.Entity<WeatherData>().HasKey(o => o.Id);
            modelBuilder.Entity<Wind>().HasKey(o => new { o.Id });

            modelBuilder.Entity<WeatherData>().Navigation(o => o.Clouds).AutoInclude();
            modelBuilder.Entity<WeatherData>().Navigation(o => o.Coord).AutoInclude();
            modelBuilder.Entity<WeatherData>().Navigation(o => o.Main).AutoInclude();
            modelBuilder.Entity<WeatherData>().Navigation(o => o.Rain).AutoInclude();
            modelBuilder.Entity<WeatherData>().Navigation(o => o.Snow).AutoInclude();
            modelBuilder.Entity<WeatherData>().Navigation(o => o.Weather).AutoInclude();
            modelBuilder.Entity<WeatherData>().Navigation(o => o.Wind).AutoInclude();
        }
    }
}
