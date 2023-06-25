namespace DoctorWho.Domain.Entities
{
    public class Companion
    {
        public int CompanionId { get; set; }
        public string CompanionName { get; set; }
        public string WhoPlayed { get; set; }
        public ICollection<Episode> Episode { get; set; } = new List<Episode>();
    }
}
