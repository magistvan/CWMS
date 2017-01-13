using System;
using System.Collections.Generic;
using Project.Domain;
using Project.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace Project.Repository
{
    class DocumentRepository : IRepository<Document>
    {
        private String connectionString;

        public DocumentRepository()
        {
            this.connectionString = Properties.Settings.Default.databaseConnectionString;
        }

        public List<Document> getAll()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Document", conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var elements = new List<Document>();
                var userRepository = new UserRepository();
                var flowDocumentRepository = new FlowDocumentRepository();
                while (reader.Read())
                {
                    int id = int.Parse(reader.GetValue(0).ToString());
                    var user = userRepository.getById(int.Parse(reader.GetValue(5).ToString()));
                    var flows = flowDocumentRepository.getFlowIdsByDocumentId(id);
                    elements.Add(new Document(int.Parse(reader.GetValue(0).ToString()), (DOCUMENT_STATUS)int.Parse(reader.GetValue(1).ToString()), int.Parse(reader.GetValue(2).ToString()), int.Parse(reader.GetValue(3).ToString()), int.Parse(reader.GetValue(4).ToString()), user, DateTime.Parse(reader.GetValue(6).ToString()), DateTime.Parse(reader.GetValue(7).ToString()), reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), reader.GetValue(10).ToString(), flows, (DOCUMENT_TYPE)int.Parse(reader.GetValue(11).ToString())));
                }
                return elements;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting all documents!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public Document add(Document element)
        {
            SqlConnection conn = null;
            try
            {
                var documents = getAll();
                int id = 1;
                while (true)
                {
                    bool found = false;
                    foreach (var doc in documents)
                    {
                        if (doc.Id == id)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                    ++id;
                }
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("insert into Document values (" + id + "," + (int)element.Status + "," + element.DraftVersion + "," + element.FinalVersion + "," + element.RevisionVersion + "," + element.Author.Id + ",'" + element.CreationDate.ToString() + "','" + element.ModificationDate.ToString() + "','" + element.Abstract_string + "','" + element.Keywords + "','" + element.FileName + "','" + (int)element.DocumentType + "')");
                conn.Open();
                command.ExecuteNonQuery();
                element.Id = id;
                return element;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in adding a document!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void update(Document element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("update Document set status=" + (int)element.Status + ", draftVersion=" + element.DraftVersion + ", finalVersion=" + element.FinalVersion + ", revisionVersion=" + element.RevisionVersion + ", author=" + element.Author.Id + ", creationDate='" + element.CreationDate.ToString() + "', modificationDate='" + element.ModificationDate.ToString() + "', abstract='" + element.Abstract_string + "', keywords='" + element.Keywords + "', fileName='" + element.FileName + "', type='" + element.DocumentType + "' where id=" + element.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in updating a document!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void delete(Document element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("delete from Document where id=" + element.Id, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in deleting a document!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public Document getById(int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Document where id=" + id.ToString(), conn);
                conn.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                var userRepository = new UserRepository();
                var flowDocumentRepository = new FlowDocumentRepository();
                var user = userRepository.getById(int.Parse(reader.GetValue(5).ToString()));
                var flows = flowDocumentRepository.getFlowIdsByDocumentId(id);
                var element = new Document(id, (DOCUMENT_STATUS)int.Parse(reader.GetValue(1).ToString()), int.Parse(reader.GetValue(2).ToString()), int.Parse(reader.GetValue(3).ToString()), int.Parse(reader.GetValue(4).ToString()), user, DateTime.Parse(reader.GetValue(6).ToString()), DateTime.Parse(reader.GetValue(7).ToString()), reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), reader.GetValue(10).ToString(), flows, (DOCUMENT_TYPE)int.Parse(reader.GetValue(11).ToString()));
                return element;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting a document!!");
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
                var command = new SqlCommand("select MAX(id) from Document", conn);
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
