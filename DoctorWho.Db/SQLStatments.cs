using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class SQLStatments
    {
       public static string CreateCompanionNameFunction = @"CREATE FUNCTION fnCompanions (@EpisodeId INT)
                                                            RETURNS VARCHAR(50) AS
                                                            BEGIN
                                                               DECLARE @CompanionName VARCHAR(50);
	                                                           SELECT @CompanionName=[CompanionName]
	                                                           FROM CompanionEpisode Episodes JOIN  Companions Companions ON Episodes.CompanionsCompanionId=Companions.CompanionId
	                                                           WHERE Episodes.EpisodeId=@EpisodeId;
                                                               return @CompanionName
                                                               END ;";

        public static string CreateEnemyNameFunction = @"CREATE FUNCTION fnEnemies (@EpisodeId INT)
                                                         RETURNS VARCHAR(50) AS
                                                         BEGIN
                                                            DECLARE @EnemyName VARCHAR(50);
	                                                        SELECT @EnemyName=[EnemyName]
	                                                        FROM EnemyEpisode Episodes JOIN  Enemies Enemy ON Episodes.EnemiesEnemyId=Enemy.EnemyId
	                                                        WHERE Episodes.EpisodeId=@EpisodeId;
                                                            return @EnemyName 
                                                         END ;";

        public static string CanclleEpisodesWithoutDoctorsQuery=@"UPDATE Episodes 
                                                                  SET Title=CONCAT(Title,'_CANCELLED')
                                                                  WHERE DoctorId IS NULL AND Title NOT LIKE '%CANCELLED%';";

        public static string EpisodesSummaryProcedure = @"CREATE PROCEDURE dbo.spSummariseEpisodes AS
                                                          BEGIN
                                                             SELECT companionName AS FrequentCompanions
                                                             FROM Companions 
                                                             where companionId IN (SELECT TOP 3 CompanionsCompanionId FROM dbo.CompanionEpisode);
   
                                                             SELECT EnemyName AS FrequentEnemies
                                                             FROM Enemies
                                                             where EnemyId IN (SELECT TOP 3 EnemiesEnemyId FROM dbo.EnemyEpisode);
                                                          END;";

        public static string CreateEpisodeView = @"CREATE VIEW viewEpisodes AS
                                                   SELECT AuthorName, DoctorName, dbo.fnCompanions(Episodes.EpisodeId) AS CompanionName,dbo.fnEnemies(Episodes.EpisodeId) AS EnemyName
                                                   FROM Episodes Episodes, Authors Authors, Doctors Doctors
                                                   where Episodes.AuthorId=Authors.AuthorId AND Episodes.DoctorId=Doctors.DoctorId;";
    }
}
