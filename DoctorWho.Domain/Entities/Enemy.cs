namespace DoctorWho.Domain.Entities
{
    public class Enemy
    {
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string EnemyDescription { get; set; }
        public ICollection<Episode> Episode { get; set; } = new List<Episode>();
    }
}
