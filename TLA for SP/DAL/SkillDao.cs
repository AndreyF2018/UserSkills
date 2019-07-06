using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DalInterface;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SkillDao : ConnectDB, ISkillDao
    {

        public IEnumerable<Skill> GetAllSkills()
        {
            List<Skill> skills = new List<Skill>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllSkills", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    skills.Add(new Skill
                    {
                        skillId = (int)reader[0],
                        skillTitle = reader[1].ToString(),
                        skillDescription = reader[2].ToString()

                    });
                }
                return skills;

            }
        }

        public IEnumerable<Skill> GetUserSkills(int _userId)
        {
            List<Skill> skills = new List<Skill>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetUserSkills", connection);
                command.Parameters.AddWithValue("@id", _userId);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    skills.Add(new Skill
                        {
                            skillId = (int)reader[0],
                            skillTitle = reader[1].ToString(),
                            skillDescription = reader[2].ToString()

                        });
                    
                }
                if (skills.Count == 0)
                {
                    return null;
                }
               else
                {
                    return skills;
                }
            }
        }

        public string AddSkill(Skill skill)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", skill.skillTitle);
                command.Parameters.AddWithValue("@description", skill.skillDescription);
                return command.ExecuteScalar().ToString();


            }
        }

        public string AssignSkill(int _assignedUserId, int _assignedSkillId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AssignSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@assignedUserId", _assignedUserId);
                command.Parameters.AddWithValue("@assignedSkillId", _assignedSkillId);
                return command.ExecuteScalar().ToString();


            }
        }

        public string DeleteUserSkill(int _deletedUserId, int _deletedSkillId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteUserSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@deletedUserId", _deletedUserId);
                command.Parameters.AddWithValue("@deletedSkillId", _deletedSkillId);
                return command.ExecuteScalar().ToString();
            }
        }

        public IEnumerable<Skill> SearchSkill(string title)
        {
            List<Skill> skills = new List<Skill>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SearchSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", title);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    skills.Add(new Skill
                    {
                        skillId = (int)reader[0],
                        skillTitle = reader[1].ToString(),
                        skillDescription = reader[2].ToString()

                    });
                }
                if (skills.Count == 0)
                {
                    return null;
                }
                else
                {
                    return skills;
                }
            }
        }
    }
}
