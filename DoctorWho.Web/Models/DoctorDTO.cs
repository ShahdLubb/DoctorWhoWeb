using DoctorWho.Domain.Entities;

namespace DoctorWho.Web.Models
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public int DoctorNumber { get; set; }
        public string? DoctorName{ get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }

    }
}
