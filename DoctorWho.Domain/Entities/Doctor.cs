namespace DoctorWho.Domain.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public int DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FirstEpisodeDate { get; set; }
        public DateTime LastEpisodeDate { get; set; }

        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
