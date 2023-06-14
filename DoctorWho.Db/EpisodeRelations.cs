using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public static class EpisodeRelations
    {
        public static void AddEnemyToEpisode(this Episode episode, Enemy enemy)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            if (episode != null && enemy != null)
            {
                episode.Enemies.Add(enemy);
                _context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException($"Enemy and Episode can't be null");
            }
        }
        public static void AddEnemyToEpisode(this Enemy enemy, Episode episode)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            if (episode != null && enemy != null)
            {
                episode.Enemies.Add(enemy);
                _context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException($"Enemy and Episode can't be null");
            }
        }
        public static void AddCompanionToEpisode(this Episode episode, Companion companion)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            if (episode != null && companion != null)
            {
                episode.Companions.Add(companion);
                _context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException($"Companion and Episode can't be null");
            }
        }
        public static void AddCompanionToEpisode(this Companion companion, Episode episode)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            if (episode != null && companion != null)
            {
                episode.Companions.Add(companion);
                _context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException($"Companion and Episode can't be null");
            }
        }
    }
}
