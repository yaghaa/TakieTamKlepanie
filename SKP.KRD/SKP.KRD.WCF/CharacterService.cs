using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using SKP.KRD.Gamification;

namespace KRD.SKP.Service.Library
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CharacterService : ICharacterService
    {
        string connectioString =
            @"Data Source=(localdb)\v11.0;Initial Catalog=SKP.KRD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string sqlSelectAll = @"SELECT * FROM [dbo].[skpCharacter]";


        public List<Character> GetCharacters()
        {
            List<Character> characters = new List<Character>();
            SqlConnection sqlConnection = new SqlConnection(connectioString);
            SqlDataReader dataReader = null;
            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sqlSelectAll, sqlConnection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var ignore = dataReader[0];
                    var charParam = new CharacterParameters((string)dataReader[1], (int)dataReader[2], (int)dataReader[3], Character.DefaultSkills());
                    characters.Add(new Character(charParam));
                }
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            return characters;
        }

        public void AddCharacter(Character character)
        {
            SqlConnection sqlConnection = new SqlConnection(connectioString);
            string sqlInsert = @"INSERT INTO [dbo].[skpCharacter] VALUES('" + character.Name + "'," + character.GeneralExperience + "," + character.KrdExperience + ")";
            SqlDataReader dataReader = null;
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
                dataReader = selectId.ExecuteReader();
                while (dataReader.Read())
                {
                    string sqlInsertSkill = null;
                    var id = dataReader[0];
                    foreach (var skill in character.Skills)
                    {
                         sqlInsertSkill += String.Format(@"INSERT INTO [dbo].[Skill] VALUES ('{0}','{1}',{2}),", skill.Name, skill.Value, id);
                        
                    }
                    sqlInsertSkill = sqlInsertSkill.Remove(sqlInsertSkill.LastIndexOf(','));
                    SqlCommand insertSkill = new SqlCommand(sqlInsertSkill, sqlConnection);
                    insertSkill.ExecuteNonQuery();
                }
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }


        }
    }
}