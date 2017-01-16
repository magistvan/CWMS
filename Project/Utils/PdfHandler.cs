using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Project.Domain;
using Project.Controllers;

namespace Project.Utils
{
    class PdfHandler
    {
        string connectionString;
        public PdfHandler(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void createPdf(Domain.Document document)
        {
            var fs = new FileStream(document.FileName, FileMode.CreateNew, FileAccess.Write, FileShare.None);
            var doc = new iTextSharp.text.Document();
            var writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.AddAuthor(document.Author.Username);
            doc.AddKeywords(document.Keywords);
            var lines = document.Abstract_string.Split('\n');
            for (int i = 0; i < lines.Length; ++i)
            {
                doc.Add(new Paragraph(lines[i]));
            }
            doc.Close();
        }

        public Domain.Document getPdf(string fileName)
        {
            var reader = new PdfReader(fileName);
            var dict = reader.Info;
            var author = new UserController(connectionString).getUserByUsername(dict["Author"]);
            var creationDate = PdfDate.Decode(dict["CreationDate"]);
            var modificationDate = PdfDate.Decode(dict["ModDate"]);
            var keywords = dict["Keywords"];
            int nrPage = reader.NumberOfPages;
            string result = "";
            for (int i = 1; i <= nrPage; ++i)
            {
                var text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                var words = text.Split('\n');
                for (int j = 0, len = words.Length; j < len; ++j)
                {
                    var line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                    result += line + "\n";
                }
            }
            reader.Close();
            return new Domain.Document(0, 0, 0, 0, 0, author, creationDate, modificationDate, result, keywords, fileName, null, DOCUMENT_TYPE.PDF);
        }

        /// <summary>
        /// Copies a PDF document into the project's directory
        /// </summary>
        /// <param name="path">Path to the file to be copied</param>
        /// <returns>Document object, which should be added later to the database</returns>
        public Domain.Document CopyDocument(String path)
        {
            var reader = new PdfReader(path);
            String fileName = System.IO.Path.GetFileName(path);
            var dict = reader.Info;
            var author = new UserController(connectionString).getUserByUsername(dict["Author"]);
            var creationDate = PdfDate.Decode(dict["CreationDate"]);
            var modificationDate = PdfDate.Decode(dict["ModDate"]);
            var keywords = dict["Keywords"];
            int nrPage = reader.NumberOfPages;
            string result = "";
            for (int i = 1; i <= nrPage; ++i)
            {
                var text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                var words = text.Split('\n');
                for (int j = 0, len = words.Length; j < len; ++j)
                {
                    var line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                    result += line + "\n";
                }
            }
            reader.Close();
            Domain.Document document = new Domain.Document(0, 0, 0, 0, 0, author, creationDate, modificationDate, result, keywords, fileName, null, DOCUMENT_TYPE.PDF);
            createPdf(document);
            return document;
        }

        public List<Tuple<User, string>> getSignatures(string fileName)
        {
            var reader = new PdfReader(fileName);
            var sb = new StringBuilder();
            var af = reader.AcroFields;
            var names = af.GetSignatureNames();
            var userController = new UserController(connectionString);
            var list = new List<Tuple<User, string>>();
            for (int i = 0; i < names.Count; ++i)
            {
                var pk = af.VerifySignature(names[i]);
                list.Add(new Tuple<User, string>(userController.getUserByUsername(pk.SignName), names[i]));
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// Returns a list if user who added a signature
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<User> modifyPdf(Domain.Document document)
        {
            var signatures1 = getSignatures(document.FileName);
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, document.FileName);
            Process.Start(path).WaitForExit();
            var signatures2 = getSignatures(document.FileName);
            foreach (var current in signatures1)
            {
                signatures2.RemoveAll((tuple) => current.Item2 == tuple.Item2);
            }
            var signatures = new List<User>();
            foreach (var current in signatures2)
            {
                signatures.Add(current.Item1);
            }
            return signatures;
        }
    }
}
