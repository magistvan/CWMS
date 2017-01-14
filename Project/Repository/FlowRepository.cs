using System;
using System.Collections.Generic;
using Project.Domain;
using Project.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace Project.Repository
{
    class FlowRepository : IRepository<Flow>
    {
        private String connectionString;

        public FlowRepository()
        {
            this.connectionString = Properties.Settings.Default.databaseConnectionString;
        }

        public List<Flow> getAll()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Flow", conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var elements = new List<Flow>();
                var userRepository = new UserRepository();
                var userFlowRepository = new UserFlowRepository();
                var flowDocumentRepository = new FlowDocumentRepository();
                while (reader.Read())
                {
                    int id = int.Parse(reader.GetValue(0).ToString());
                    var creator = userRepository.getById(int.Parse(reader.GetValue(1).ToString()));
                    var revisors = userFlowRepository.getUserIdsByFlowId(id);
                    var documents = flowDocumentRepository.getDocumentIdsByFlowId(id);
                    Flow f = new Flow(id, documents, creator, revisors, int.Parse(reader.GetValue(2).ToString()), (FLOW_STATUS)int.Parse(reader.GetValue(3).ToString()), DateTime.Parse(reader.GetValue(4).ToString()), DateTime.Parse(reader.GetValue(5).ToString()));
                    elements.Add(f);
                }
                return elements;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting all flows!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public Flow add(Flow element)
        {
            SqlConnection conn = null;
            try
            {
                var flows = getAll();
                int id = 1;
                while (true)
                {
                    bool found = false;
                    foreach (var flow in flows)
                    {
                        if (flow.Id == id)
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
                var command = new SqlCommand("insert into Flow values (" + id + "," + element.Creator.Id + "," + element.Step + "," + (int)element.Status + ",'" + element.CreationDate.ToString(format) + "','" + element.EndDate.ToString(format) + "')", conn);
                conn.Open();
                command.ExecuteNonQuery();
                element.Id = id;
                return element;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in adding a flow!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void update(Flow element)
        {
            SqlConnection conn = null;
            try
            {
                
                conn = new SqlConnection(connectionString);
                string format = Properties.Settings.Default.dateFormat;
                var command = new SqlCommand("update Flow set creator=" + element.Creator.Id + ", step=" + element.Step + ", status=" + (int)element.Status + ", creationDate='" + element.CreationDate.ToString(format) + "', endDate='" + element.EndDate.ToString(format) + "' where id=" + element.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in updating a flow!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void delete(Flow element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("delete from Flow where id=" + element.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in deleting a flow!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public Flow getById(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Flow where id=" + id.ToString(), conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var userRepository = new UserRepository();
                var userFlowRepository = new UserFlowRepository();
                var flowDocumentRepository = new FlowDocumentRepository();
                reader.Read();
                var creator = userRepository.getById(int.Parse(reader.GetValue(1).ToString()));
                var revisors = userFlowRepository.getUserIdsByFlowId(id);
                var documents = flowDocumentRepository.getDocumentIdsByFlowId(id);
                Flow f = new Flow(id, documents, creator, revisors, int.Parse(reader.GetValue(2).ToString()), (FLOW_STATUS)int.Parse(reader.GetValue(3).ToString()), DateTime.Parse(reader.GetValue(4).ToString()), DateTime.Parse(reader.GetValue(5).ToString()));
                return f;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting a flow!!");
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
                var command = new SqlCommand("select MAX(id) from Flow", conn);
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

