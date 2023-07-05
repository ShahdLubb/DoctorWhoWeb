using DoctorWho.Domain.Entities;

namespace DoctorWho.Web.Models
{
    public class EpisodeDTO
    {
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public string? Notes { get; set; }
        public AuthorDTO Author { get; set; }
        public DoctorDTO Doctor { get; set; }
    }
}
