using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Models
{
    public class Enemy
    {
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string EnemyDescription { get; set; }
        public ICollection<Episode> Episode { get; set; }=new List<Episode>();
    }
}
