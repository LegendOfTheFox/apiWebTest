using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILesson.Models
{
    public class MusicStoreModel : DbContext
    {

        public MusicStoreModel(DbContextOptions<MusicStoreModel>options) : base(options)
        {
            // db options are set in Startup.cs
        }

        public DbSet<Album> Albums { get; set; }
    }
}
