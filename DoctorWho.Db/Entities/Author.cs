﻿namespace DoctorWho.Db.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}