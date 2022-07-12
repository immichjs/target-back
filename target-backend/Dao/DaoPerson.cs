using target_backend.Models;
using System.Data.SqlClient;

namespace target_backend.Dao
{
    public class DaoPerson
    {
        string connection = @"Data Source=IMMICH\SQLEXPRESS;Initial Catalog=target_api;Integrated Security=True";

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Person", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var person = new Person();

                                person.id = (int) reader["id"];
                                person.username = reader["username"].ToString();
                                person.fullname = reader["fullname"].ToString();
                                person.date = reader["date"].ToString();
                                person.role = reader["role"].ToString();
                                person.active = reader["active"].ToString(); 

                                people.Add(person);
                            }
                        }
                    }
                }
                conn.Close();
            }
            return people;
        }


        public void InsertPerson(Person person)
        {
            List<Person> people = new List<Person>();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Person (username, fullname, date, active, role) VALUES (@username, @fullname, @date, @active, @role) ", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@username", person.username);
                    cmd.Parameters.AddWithValue("@fullname", person.fullname);
                    cmd.Parameters.AddWithValue("@date", person.date);
                    cmd.Parameters.AddWithValue("@active", person.active);
                    cmd.Parameters.AddWithValue("@role", person.role);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }

            return;
        }
        

        public void UpdatePerson(Person person, int Id)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE Person SET username = @username, fullname = @fullname, date = @date, active = @active, role = @role WHERE id = @id", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@username", person.username);
                    cmd.Parameters.AddWithValue("@fullname", person.fullname);
                    cmd.Parameters.AddWithValue("@date", person.date);
                    cmd.Parameters.AddWithValue("@active", person.active);
                    cmd.Parameters.AddWithValue("@role", person.role);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
            return;
        }

        public void DeletePerson (int Id)
        {

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand cmdDelete = new SqlCommand("DELETE FROM Person WHERE id = @id", conn))
                {
                        cmdDelete.CommandType = System.Data.CommandType.Text;
                        cmdDelete.Parameters.AddWithValue("@id", Id);
                        cmdDelete.ExecuteNonQuery();
                }

                conn.Close();
            }
            return;
        }
    }
}
