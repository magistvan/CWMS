using System;
using System.Collections.Generic;
using Project.Domain;
using Project.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace Project.Repository
{
    class UserRepository : IRepository<User>
    {
        private String connectionString;

        public UserRepository()
        {
            this.connectionString = Properties.Settings.Default.databaseConnectionString;
        }

        public List<User> getAll()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from [User]", conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var elements = new List<User>();
                var unitRepository = new UnitRepository();
                var userFlowRepository = new UserFlowRepository();
                while (reader.Read())
                {
                    var unit = int.Parse(reader.GetValue(4).ToString());
                    int type = int.Parse(reader.GetValue(5).ToString());
                    User boss = null;
                    if (type != 0)
                    {
                        boss = getById(int.Parse(reader.GetValue(6).ToString()));
                    }
                    int id = int.Parse(reader.GetValue(0).ToString());
                    var flows = userFlowRepository.getFlowIdsByUserId(id);
                    User user = null;
                    if (type == 0)
                    {
                        user = new Admin(id, reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), unit, flows);
                    }
                    else if (type == 1)
                    {
                        user = new Manager(id, reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), unit, flows, boss);
                    }
                    else if (type == 2)
                    {
                        user = new Contributor(id, reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), unit, flows, boss);
                    }
                    else if (type == 3)
                    {
                        user = new Reader(id, reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), unit, flows, boss);
                    }
                    elements.Add(user);
                }
                return elements;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting all users!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public User add(User element)
        {
            SqlConnection conn = null;
            try
            {
                var users = getAll();
                int id = 1;
                while (true)
                {
                    bool found = false;
                    foreach (var user in users)
                    {
                        if (user.Id == id)
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
                SqlCommand command = null;
                if (element is Admin)
                {
                    var el = (Admin)element;
                    command = new SqlCommand("insert into [User] values (" + id + ", '" + el.Username + "','" + el.Password + "','" + el.Email + "'," + el.Unitid + ",0,0)", conn);
                }
                else if (element is Manager)
                {
                    var el = (Manager)element;
                    command = new SqlCommand("insert into [User] values (" + id + ", '" + el.Username + "','" + el.Password + "','" + el.Email + "'," + el.Unitid + ",1," + el.Boss.Id + ")", conn);
                }
                else if (element is Contributor)
                {
                    var el = (Contributor)element;
                    command = new SqlCommand("insert into [User] values (" + id + ", '" + el.Username + "','" + el.Password + "','" + el.Email + "'," + el.Unitid + ",2," + el.Boss.Id + ")", conn);
                }
                else if (element is Reader)
                {
                    var el = (Reader)element;
                    command = new SqlCommand("insert into [User] values (" + id + ", '" + el.Username + "','" + el.Password + "','" + el.Email + "'," + el.Unitid + ",3," + el.Boss.Id + ")", conn);
                }
                conn.Open();
                command.ExecuteNonQuery();
                element.Id = id;
                return element;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in adding a user!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void update(User element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                SqlCommand command = null;
                if (element is Admin)
                {
                    var el = (Admin)element;
                    command = new SqlCommand("update [User] set username='" + el.Username + "', password='" + el.Password + "', email='" + el.Email + "', unit=" + el.Unitid + ", type=0,boss_id=0 where id=" + el.Id, conn);
                }
                else if (element is Manager)
                {
                    var el = (Manager)element;
                    command = new SqlCommand("update [User] set username='" + el.Username + "', password='" + el.Password + "', email='" + el.Email + "', unit=" + el.Unitid + ", type=1,boss_id=" + el.Boss.Id + " where id=" + el.Id, conn);
                }
                else if (element is Contributor)
                {
                    var el = (Contributor)element;
                    command = new SqlCommand("update [User] set username='" + el.Username + "', password='" + el.Password + "', email='" + el.Email + "', unit=" + el.Unitid + ", type=2,boss_id=" + el.Boss.Id + " where id=" + el.Id, conn);
                }
                else if (element is Reader)
                {
                    var el = (Reader)element;
                    command = new SqlCommand("update [User] set username='" + el.Username + "', password='" + el.Password + "', email='" + el.Email + "', unit=" + el.Unitid + ", type=3,boss_id=" + el.Boss.Id + " where id=" + el.Id, conn);
                }
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in updating a user!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void delete(User element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("delete from [User] where id=" + element.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in deleting a user!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public User getById(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from [User] where id=" + id, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var unitRepository = new UnitRepository();
                var userFlowRepository = new UserFlowRepository();
                reader.Read();
                var unit = int.Parse(reader.GetValue(4).ToString());
                int type = int.Parse(reader.GetValue(5).ToString());
                User boss = null;
                if (type != 0)
                {
                    boss = getById(int.Parse(reader.GetValue(6).ToString()));
                }
                var flows = userFlowRepository.getFlowIdsByUserId(id);
                User user = null;
                if (type == 0)
                {
                    user = new Admin(id, reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), unit, flows);
                }
                else if (type == 1)
                {
                    user = new Manager(id, reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), unit, flows, boss);
                }
                else if (type == 2)
                {
                    user = new Contributor(id, reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), unit, flows, boss);
                }
                else if (type == 3)
                {
                    user = new Reader(id, reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), unit, flows, boss);
                }
                return user;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting a user!!");
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
                var command = new SqlCommand("select MAX(id) from [User]", conn);
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

