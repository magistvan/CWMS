using System;
using System.Collections.Generic;
using System.Linq;
using Project.Domain;
using Project.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace Project.Repository
{
    class UnitRepository : IRepository<Unit>
    {
        private String connectionString;

        public UnitRepository()
        {
            this.connectionString = Properties.Settings.Default.databaseConnectionString;
        }

        public List<Unit> getAll()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Unit", conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var elements = new List<Unit>();
                IRepository<User> userRepository = new UserRepository();
                //var users = userRepository.getAll();
                while (reader.Read())
                {
                    int id = int.Parse(reader.GetValue(0).ToString());
                    var current_users = new List<User>();// users.Where(user => user.Unitid == id).ToList();
                    elements.Add(new Unit(id, reader.GetValue(1).ToString(), current_users));
                }
                return elements;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting all units!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public Unit add(Unit element)
        {
            SqlConnection conn = null;
            try
            {
                var units = getAll();
                int id = 1;
                while (true)
                {
                    bool found = false;
                    foreach (var unit in units)
                    {
                        if (unit.Id == id)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        break;
                    }
                    ++id;
                }
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("insert into Unit values (" + id + ",'" + element.Name + "')", conn);
                conn.Open();
                command.ExecuteNonQuery();
                element.Id = id;
                return element;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in adding a unit!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void update(Unit element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("update Unit set name='" + element.Name + "' where id=" + element.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in updating a unit!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void delete(Unit element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("delete from Unit where id=" + element.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in deleting a unit!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public Unit getById(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Unit where id=" + id.ToString(), conn);
                conn.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                IRepository<User> userRepository = new UserRepository();
                var users = userRepository.getAll();
                var current_users = users.Where(user => user.Unitid == id).ToList();
                return new Unit(id, reader.GetValue(1).ToString(), current_users);
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting a unit!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public int GetMaxId()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select MAX(id) from Unit", conn);
                conn.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                return int.Parse(reader.GetValue(0).ToString());
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting max id");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }
    }
}
