namespace DoctorWho.Db.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}
