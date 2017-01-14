using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Project.Domain;
using Project.Exceptions;

namespace Project.Repository
{
    class UserFlowRepository
    {
        private String connectionString;

        public UserFlowRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void add(User user, Flow flow, int step)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("insert into UserFlow values (" + user.Id + "," + flow.Id + "," + step +")", conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in connecting a user and a flow!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void delete(User user, Flow flow)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("delete from UserFlow where [user]=" + user.Id + " and flow=" + flow.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in deconnecting a user and a flow!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public List<List<int>> getUserIdsByFlowId(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from UserFlow where flow=" + id, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                try
                {
                    var elements = new List<Tuple<int, int>>();
                    while (reader.Read())
                    {
                        elements.Add(new Tuple<int, int>(int.Parse(reader.GetValue(0).ToString()), int.Parse(reader.GetValue(2).ToString())));
                    }
                    var result = new List<List<int>>();
                    for (int i = 0; ; ++i)
                    {
                        int nr = 0;
                        foreach (var tuple in elements)
                        {
                            if (tuple.Item2 == i)
                            {
                                if (nr == 0)
                                {
                                    result.Add(new List<int>());
                                }
                                result[i].Add(tuple.Item1);
                                ++nr;
                            }
                        }
                        if (nr == 0)
                        {
                            break;
                        }
                    }
                    return result;
                }
                catch (Exception)
                {
                    return new List<List<int>>();
                }
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting users of flow!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public List<int> getFlowIdsByUserId(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from UserFlow where [user]=" + id, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                try
                {
                    var elements = new List<int>();
                    while (reader.Read())
                    {
                        elements.Add(int.Parse(reader.GetValue(1).ToString()));
                    }
                    return elements;
                }
                catch (Exception)
                {
                    return new List<int>();
                }
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting flows of user!!");
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
