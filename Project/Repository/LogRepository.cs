using System;
using System.Collections.Generic;
using Project.Domain;
using Project.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace Project.Repository
{
    class LogRepository : IRepository<Log>
    {
        private String connectionString;

        public LogRepository()
        {
            this.connectionString = Properties.Settings.Default.databaseConnectionString;
        }

        public List<Log> getAll()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Log", conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var elements = new List<Log>();
                var userRepository = new UserRepository();
                var unitRepository = new UnitRepository();
                while (reader.Read())
                {
                    var user = userRepository.getById(int.Parse(reader.GetValue(1).ToString()));
                    var unit = unitRepository.getById(int.Parse(reader.GetValue(2).ToString()));
                    elements.Add(new Log(int.Parse(reader.GetValue(0).ToString()), user, unit, DateTime.Parse(reader.GetValue(3).ToString()), (ACTION_TYPE)int.Parse(reader.GetValue(4).ToString())));
                }
                return elements;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting all logs!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public Log add(Log element)
        {
            SqlConnection conn = null;
            try
            {
                var logs = getAll();
                int id = 1;
                while (true)
                {
                    bool found = false;
                    foreach (var log in logs)
                    {
                        if (log.Id == id)
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
                string format = Properties.Settings.Default.dateFormat;
                SqlCommand command = new SqlCommand("insert into Log values (" + id + "," + element.User.Id + "," + element.Unit.Id + ",'" + element.Date.ToString(format) + "'," + (int)element.ActionType + ")", conn);
                conn.Open();
                command.ExecuteNonQuery();
                element.Id = id;
                return element;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in adding a log!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void update(Log element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                string format = Properties.Settings.Default.dateFormat;
                SqlCommand command = new SqlCommand("update Log set [user]=" + element.User.Id + ", unit=" + element.Unit.Id + ", date='" + element.Date.ToString(format) + "', actionType=" + (int)element.ActionType + " where id=" + element.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in updating a log!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void delete(Log element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("delete from Log where id=" + element.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in deleting a log!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public Log getById(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Log where id=" + id, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var userRepository = new UserRepository();
                var unitRepository = new UnitRepository();
                reader.Read();
                var user = userRepository.getById(int.Parse(reader.GetValue(1).ToString()));
                var unit = unitRepository.getById(int.Parse(reader.GetValue(2).ToString()));
                return new Log(id, user, unit, DateTime.Parse(reader.GetValue(3).ToString()), (ACTION_TYPE)int.Parse(reader.GetValue(4).ToString()));
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting a log!!");
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
                var command = new SqlCommand("select MAX(id) from Log", conn);
                conn.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                if (reader.GetValue(0).ToString() == "")
                {
                    return 0;
                }
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
