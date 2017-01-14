using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using Project.Domain;
using Project.Controllers;

namespace Project.Utils
{
    static class WordHandler
    {
        public static void createDoc(Domain.Document document)
        {
            var app = new Application();
            app.Visible = false;
            var doc = app.Documents.Add();
            var properties = doc.BuiltInDocumentProperties;
            properties["Author"].Value = document.Author.Username;
            properties["Keywords"].Value = document.Keywords;
            var lines = document.Abstract_string.Split('\n');
            for (int i = 0; i < lines.Length; ++i)
            {
                var par = doc.Content.Paragraphs.Add();
                par.Range.Text = lines[i];
                par.Range.InsertParagraphAfter();
            }
            string path = Path.Combine(Environment.CurrentDirectory, document.FileName);
            doc.SaveAs(path);
            app.Quit();
        }

        public static Domain.Document getDoc(string fileName)
        {
            var word = new Application();
            word.Visible = false;
            object path = Path.Combine(Environment.CurrentDirectory, fileName);
            var doc = word.Documents.Open(ref path);
            var properties = doc.BuiltInDocumentProperties;
            var author = new UserController().getUserByUsername(properties["Author"].Value);
            var creationDate = properties["Creation Date"].Value;
            var modificationDate = properties["Last Save Time"].Value;
            var keywords = properties["Keywords"].Value;
            string result = "";
            for (int i = 0; i < doc.Paragraphs.Count; ++i)
            {
                string line = doc.Paragraphs[i + 1].Range.Text.Trim();
                if (line != string.Empty)
                {
                    result += line + "\n";
                }
            }
            doc.Close();
            word.Quit();
            return new Domain.Document(0, 0, 0, 0, 0, author, creationDate, modificationDate, result, keywords, fileName, null, DOCUMENT_TYPE.WORD);
        }

        /// <summary>
        /// Copies a Word document into the project's directory
        /// </summary>
        /// <param name="path">Path to the file to be copied</param>
        /// <returns>Document object, which should be added later to the database</returns>
        public static Domain.Document CopyDocument(String path)
        {
            var word = new Application();
            word.Visible = false;
            object fullPath = Path.GetFullPath(path);
            String fileName = Path.GetFileName(path);
            var doc = word.Documents.Open(ref fullPath);
            var properties = doc.BuiltInDocumentProperties;
            var author = new UserController().getUserByUsername(properties["Author"].Value);
            var creationDate = properties["Creation Date"].Value;
            var modificationDate = properties["Last Save Time"].Value;
            var keywords = properties["Keywords"].Value;
            string result = "";
            for (int i = 0; i < doc.Paragraphs.Count; ++i)
            {
                string line = doc.Paragraphs[i + 1].Range.Text.Trim();
                if (line != string.Empty)
                {
                    result += line + "\n";
                }
            }
            doc.Close();
            word.Quit();
            Domain.Document document = new Domain.Document(0, 0, 0, 0, 0, author, creationDate, modificationDate, result, keywords, fileName, null, DOCUMENT_TYPE.WORD);
            createDoc(document);
            return document;
        }

        public static List<Tuple<User, string>> getSignatures(string fileName)
        {
            var word = new Application();
            word.Visible = false;
            object path = Path.Combine(Environment.CurrentDirectory, fileName);
            var doc = word.Documents.Open(ref path);
            var userController = new UserController();
            var list = new List<Tuple<User, string>>();
            foreach (Microsoft.Office.Core.Signature signature in doc.Signatures)
            {
                list.Add(new Tuple<User, string>(userController.getUserByUsername(signature.Signer), signature.SignDate.ToString()));
            }
            doc.Close();
            word.Quit();
            return list;
        }

        /// <summary>
        /// Returns a list if user who added a signature
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static List<User> modifyDoc(Domain.Document document)
        {
            var signatures1 = getSignatures(document.FileName);
            var path = Path.Combine(Environment.CurrentDirectory, document.FileName);
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
