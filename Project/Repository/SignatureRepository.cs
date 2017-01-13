﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain;
using System.Data;
using System.Data.SqlClient;
using Project.Exceptions;

namespace Project.Repository
{
    class SignatureRepository : IRepository<Signature>
    {
        private String connectionString;

        public SignatureRepository()
        {
            this.connectionString = Properties.Settings.Default.databaseConnectionString;
        }

        public List<Signature> getAll()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Signature", conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var elements = new List<Signature>();
                while (reader.Read())
                {
                    int userid = int.Parse(reader.GetValue(0).ToString());
                    var documentid = int.Parse(reader.GetValue(1).ToString());
                    elements.Add(new Signature(userid, documentid));
                }
                return elements;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting all signatures!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public Signature getById(int id)
        {
            return null;
        }

        public Signature add(Signature element)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("insert into Signatures values (" + element.Userid + "," + element.Documentid + ")");
                conn.Open();
                command.ExecuteNonQuery();
                return element;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in adding a signature!!");
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        public void update(Signature element)
        {
        }

        public void delete(Signature element)
        {
        }

        public int GetMaxId()
        {
            return 0;
        }

        public List<Signature> getSignaturesOfDocument(int documentid)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                var command = new SqlCommand("select * from Signature where documentid=" + documentid, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                var elements = new List<Signature>();
                while (reader.Read())
                {
                    int userid = int.Parse(reader.GetValue(0).ToString());
                    elements.Add(new Signature(userid, documentid));
                }
                return elements;
            }
            catch (Exception)
            {
                throw new RepositoryException("Error in getting all signatures of a document!!");
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