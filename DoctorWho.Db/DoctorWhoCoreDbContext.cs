using DoctorWho.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<EpisodeView> ViewEpisodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source=DESKTOP-8BNUKJL;Initial Catalog = DoctorWhoCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpisodeView>().HasNoKey().ToView(nameof(ViewEpisodes));
            // Inserting Enemies
            modelBuilder.Entity<Enemy>().HasData(
                new Enemy { EnemyId = 1, EnemyName = "Daleks", EnemyDescription = "Ruthless cyborg conquerors" },
                new Enemy { EnemyId = 2, EnemyName = "Cybermen", EnemyDescription = "Cybernetic humanoids seeking perfection" },
                new Enemy { EnemyId = 3, EnemyName = "The Master", EnemyDescription = "The Doctor's Time Lord nemesis" },
                new Enemy { EnemyId = 4, EnemyName = "Weeping Angels", EnemyDescription = "Quantum-locked predatory beings" },
                new Enemy { EnemyId = 5, EnemyName = "The Silence", EnemyDescription = "Memory-manipulating religious order" },
                new Enemy { EnemyId = 6, EnemyName = "Clockwork androids", EnemyDescription = "Beings" },
                new Enemy { EnemyId = 7, EnemyName = "The Veil", EnemyDescription = "A creature designed to extract information from the Doctor" },
                new Enemy { EnemyId = 8, EnemyName = "Stenza", EnemyDescription = "Specifically, Tzim-Sha, a warrior of the Stenza race" }
            );

            // Inserting Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, AuthorName = "Jane Austen" },
                new Author { AuthorId = 2, AuthorName = "Ernest Hemingway" },
                new Author { AuthorId = 3, AuthorName = "J.K. Rowling" },
                new Author { AuthorId = 4, AuthorName = "Charles Dickens" },
                new Author { AuthorId = 5, AuthorName = "Agatha Christie" }
            );

            // Inserting Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, DoctorNumber = 1, DoctorName = "William Hartnell", BirthDate = new DateTime(1908, 1, 8), FirstEpisodeDate = new DateTime(1963, 11, 23), LastEpisodeDate = new DateTime(1966, 10, 29) },
                new Doctor { DoctorId = 2, DoctorNumber = 10, DoctorName = "David Tennant", BirthDate = new DateTime(1971, 4, 18), FirstEpisodeDate = new DateTime(2005, 12, 25), LastEpisodeDate = new DateTime(2010, 1, 1) },
                new Doctor { DoctorId = 3, DoctorNumber = 11, DoctorName = "Matt Smith", BirthDate = new DateTime(1982, 10, 28), FirstEpisodeDate = new DateTime(2010, 4, 3), LastEpisodeDate = new DateTime(2013, 12, 25) },
                new Doctor { DoctorId = 4, DoctorNumber = 12, DoctorName = "Peter Capaldi", BirthDate = new DateTime(1958, 4, 14), FirstEpisodeDate = new DateTime(2014, 12, 23), LastEpisodeDate = new DateTime(2017, 12, 25) },
                new Doctor { DoctorId = 5, DoctorNumber = 13, DoctorName = "Jodie Whittaker", BirthDate = new DateTime(1982, 6, 17), FirstEpisodeDate = new DateTime(2018, 10, 7), LastEpisodeDate = new DateTime(2021, 9, 1) }
            );

            // Inserting Companions
            modelBuilder.Entity<Companion>().HasData(
                new Companion { CompanionId = 1, CompanionName = "Rose Tyler", WhoPlayed = "Billie Piper" },
                new Companion { CompanionId = 2, CompanionName = "Amy Pond", WhoPlayed = "Karen Gillan" },
                new Companion { CompanionId = 3, CompanionName = "Clara Oswald", WhoPlayed = "Jenna Coleman" },
                new Companion { CompanionId = 4, CompanionName = "Donna Noble", WhoPlayed = "Catherine Tate" },
                new Companion { CompanionId = 5, CompanionName = "Martha Jones", WhoPlayed = "Freema Agyeman" },
                new Companion { CompanionId = 6, CompanionName = "Rory Williams", WhoPlayed = "Arthur Darvill" },
                new Companion { CompanionId = 7, CompanionName = "River Song", WhoPlayed = "Alex Kingston" }
            );

            // Inserting Episodes
            modelBuilder.Entity<Episode>().HasData(
                new Episode { EpisodeId = 1, SeriesNumber = 1, EpisodeNumber = 2, EpisodeType = "Historical Adventure", Title = "The Daleks", EpisodeDate = new DateTime(1963, 12, 21), AuthorId = 1, DoctorId = 1 },
                new Episode { EpisodeId = 2, SeriesNumber = 2, EpisodeNumber = 4, EpisodeType = "Sci-Fi Adventure", Title = "The Girl in the Fireplace", EpisodeDate = new DateTime(2006, 5, 6), AuthorId = 2, DoctorId = 2 },
                new Episode { EpisodeId = 3, SeriesNumber = 5, EpisodeNumber = 10, EpisodeType = "Drama, Mystery", Title = "Vincent and the Doctor", EpisodeDate = new DateTime(2010, 6, 5), AuthorId = 3, DoctorId = 3 },
                new Episode { EpisodeId = 4, SeriesNumber = 9, EpisodeNumber = 11, EpisodeType = "Sci-Fi Adventure", Title = "Heaven Sent", EpisodeDate = new DateTime(2015, 11, 28), AuthorId = 4, DoctorId = 4 },
                new Episode { EpisodeId = 5, SeriesNumber = 11, EpisodeNumber = 1, EpisodeType = "Adventure, Drama", Title = "The Woman Who Fell to Earth", EpisodeDate = new DateTime(2018, 10, 7), AuthorId = 5, DoctorId = 5 },
                new Episode { EpisodeId = 6, SeriesNumber = 1, EpisodeNumber = 8, EpisodeType = "Historical Adventure", Title = "The Reign of Terror", EpisodeDate = new DateTime(1964, 2, 8), AuthorId = 1, DoctorId = 1 },
                new Episode { EpisodeId = 7, SeriesNumber = 3, EpisodeNumber = 10, EpisodeType = "Sci-Fi Adventure", Title = "Blink", EpisodeDate = new DateTime(2007, 6, 9), AuthorId = 2, DoctorId = 2 },
                new Episode { EpisodeId = 8, SeriesNumber = 7, EpisodeNumber = 5, EpisodeType = "Sci-Fi Adventure", Title = "The Angels Take Manhattan", EpisodeDate = new DateTime(2012, 9, 29), AuthorId = 3, DoctorId = 3 },
                new Episode { EpisodeId = 9, SeriesNumber = 8, EpisodeNumber = 11, EpisodeType = "Sci-Fi Adventure", Title = "Dark Water", EpisodeDate = new DateTime(2014, 11, 1), AuthorId = 4, DoctorId = 4 },
                new Episode { EpisodeId = 10, SeriesNumber = 12, EpisodeNumber = 10, EpisodeType = "Adventure, Drama", Title = "The Timeless Children", EpisodeDate = new DateTime(2020, 3, 1), AuthorId = 5, DoctorId = 5 }

            );


        }

    }
}
