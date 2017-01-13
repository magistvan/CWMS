using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Project.Domain;
using Project.Exceptions;

namespace Project.Repository
{
    class FlowDocumentRepository
    {
        private String connectionString;

        public FlowDocumentRepository()
        {
            this.connectionString = Properties.Settings.Default.databaseConnectionString;
        }

        public void add(Flow flow, Document document)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("insert into FlowDocument values (" + document.Id + "," + flow.Id + ")", conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in connecting a flow and a document!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void delete(Flow flow, Document document)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("delete from FlowDocument where flow=" + flow.Id + " and document=" + document.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in deconnecting a document and a flow!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public List<int> getDocumentIdsByFlowId(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from FlowDocument where flow=" + id, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var elements = new List<int>();
                while (reader.Read())
                {
                    elements.Add(int.Parse(reader.GetValue(0).ToString()));
                }
                return elements;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting documents of flow!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public List<int> getFlowIdsByDocumentId(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from FlowDocument where document=" + id, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var elements = new List<int>();
                while (reader.Read())
                {
                    elements.Add(int.Parse(reader.GetValue(1).ToString()));
                }
                return elements;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting flows of documents!!");
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
