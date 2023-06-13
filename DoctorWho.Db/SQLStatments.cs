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

       }
}
