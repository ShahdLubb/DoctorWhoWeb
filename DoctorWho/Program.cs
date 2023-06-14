using DoctorWho.Db;
using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DoctorWho
{
    internal class Program
    {
        static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        static void Main(string[] args)
        {
            var EpisodesList = _context.Episodes.ToList();
            printEnemeyForAllEpisodes(EpisodesList);
            printECompanionForAllEpisodes(EpisodesList);
            var EpisodeSummary = GetEpisodeSummaryFromProcedure();
            PrintEpisodeSummaryFromProcedure(EpisodeSummary);
        }
        public static List<EpisodeView> GetEpisodeView()
        {
            return _context.ViewEpisodes.ToList();
        }
        public static void PrintEpisodeSummaryFromProcedure(List<List<string>> Summary)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("-Frequent 3  Companions Then Enemies:");
            foreach (List<string> model in Summary)
            {
                foreach (string value in model)
                {
                    Console.WriteLine(value);
                }
                Console.WriteLine();

            }
        }
        public static List<List<string>> GetEpisodeSummaryFromProcedure()
        {
            List<string> FrequentCompanions = new List<string>();
            List<string> FrequentEnemies = new List<string>();
            List<List<string>> EpisodeSummary = new List<List<string>>();
            EpisodeSummary.Add(FrequentCompanions);
            EpisodeSummary.Add(FrequentEnemies);

            var database = new DoctorWhoCoreDbContext();
            var connection = database.Database.GetDbConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"dbo.spSummariseEpisodes;";
            command.CommandType = CommandType.Text;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string companion = reader.GetString(0);
                FrequentCompanions.Add(companion);
            }

            reader.NextResult();

            while (reader.Read())
            {
                string enemy = reader.GetString(0);
                FrequentEnemies.Add(enemy);
            }

            reader.CloseAsync();
            return EpisodeSummary;
        }
        public static void printECompanionForAllEpisodes(List<Episode> EpisodesList)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine(" Companion for every Episode: ");
            foreach (Episode episode in EpisodesList)
            {
                Console.Write($"{episode.Title} :");
                foreach (string e in GetCompanionByEpisode(episode.EpisodeId))
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static List<string> GetCompanionByEpisode(int EpisodeId)
        {
            var EpisodeCompanion = _context.Database.SqlQuery<string>($"SELECT dbo.fnCompanions({EpisodeId});").ToList();
            return EpisodeCompanion;
        }
        public static void printEnemeyForAllEpisodes(List<Episode> EpisodesList)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine(" Enemy for every Episode: ");
            foreach (Episode episode in EpisodesList)
            {
                Console.Write($"{episode.Title} :");
                foreach (string e in GetEnemyByEpisode(episode.EpisodeId))
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static List<string> GetEnemyByEpisode(int EpisodeId)
        {
            var EpisodeEnemies = _context.Database.SqlQuery<string>($"SELECT dbo.fnEnemies({EpisodeId});").ToList();
            return EpisodeEnemies;
        }
        public static void ConnectExistingEpisodesAndEnemies()
        {
            var Episodes = _context.Episodes.ToList();
            var Enemies = _context.Enemies.ToList();
            Episodes[0].Enemies.Add(Enemies[0]);
            Episodes[1].Enemies.Add(Enemies[1]);
            Episodes[2].Enemies.Add(Enemies[2]);
            Episodes[3].Enemies.Add(Enemies[3]);
            Episodes[4].Enemies.Add(Enemies[4]);
            Episodes[5].Enemies.Add(Enemies[0]);
            Episodes[6].Enemies.Add(Enemies[4]);
            Episodes[7].Enemies.Add(Enemies[6]);
            Episodes[8].Enemies.Add(Enemies[5]);
            Episodes[9].Enemies.Add(Enemies[7]);
            _context.SaveChanges();
        }

        public static void ConnectExistingEpisodesAndCompanions()
        {
            var Episodes = _context.Episodes.ToList();
            var companions = _context.Companions.ToList();
            Episodes[0].Companions.Add(companions[0]);
            Episodes[1].Companions.Add(companions[1]);
            Episodes[2].Companions.Add(companions[2]);
            Episodes[3].Companions.Add(companions[3]);
            Episodes[4].Companions.Add(companions[4]);
            Episodes[5].Companions.Add(companions[0]);
            Episodes[6].Companions.Add(companions[1]);
            Episodes[7].Companions.Add(companions[5]);
            Episodes[8].Companions.Add(companions[6]);
            Episodes[9].Companions.Add(companions[2]);
            _context.SaveChanges();
        }
    }
}