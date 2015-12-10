using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKP.KRD.Gamification;

namespace WCFTest
{
    class Program
    {
        public static string connectioString =
           @"Data Source=(localdb)\v11.0;Initial Catalog=AdventureWorksDW2012;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            var character = new Character(new CharacterParameters("test2",2,2,Character.DefaultSkills()));
            SqlConnection sqlConnection = new SqlConnection(connectioString);
            string sqlInsert = @"INSERT INTO [dbo].[skpCharacter] VALUES('" + character.Name + "'," + character.GeneralExperience + "," + character.KrdExperience + ")";
            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sqlInsert, sqlConnection);
                command.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }


            try
            {
                sqlConnection.Open();
                SqlCommand selectId = new SqlCommand(@"SELECT CharacterId FROM [dbo].[skpCharacter] WHERE Name='" + character.Name + "'", sqlConnection);
                var dataReader = selectId.ExecuteReader();
                dataReader.Read();
                
                    string sqlInsertSkill = null;
                    var id = dataReader[0];
                    dataReader.Close();
                    foreach (var skill in character.Skills)
                    {
                        sqlInsertSkill += String.Format(@"INSERT INTO [dbo].[Skill] VALUES ('{0}','{1}',{2}) ", skill.Name, skill.Value, id);

                    }
                    SqlCommand insertSkill = new SqlCommand(sqlInsertSkill, sqlConnection);
                    insertSkill.ExecuteNonQuery();
                
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
