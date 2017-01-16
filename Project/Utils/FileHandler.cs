using System;
using System.Collections.Generic;
using Project.Domain;
using Project.Exceptions;
using System.IO;

namespace Project.Utils
{
    class FileHandler
    {
        WordHandler wordHandler;
        PdfHandler pdfHandler;
        public FileHandler(string connectionString)
        {
            wordHandler = new WordHandler(connectionString);
            pdfHandler = new PdfHandler(connectionString);
        }
        public void CreateDocument(Domain.Document document)
        {
            switch (document.DocumentType)
            {
                case DOCUMENT_TYPE.WORD:
                    wordHandler.createDoc(document);
                    break;
                case DOCUMENT_TYPE.PDF:
                    pdfHandler.createPdf(document);
                    break;
                default:
                    throw new UtilException("Invalid document type");
            }
        }

        public Domain.Document GetDocument(string fileName, DOCUMENT_TYPE type)
        {
            switch (type)
            {
                case DOCUMENT_TYPE.WORD:
                    return wordHandler.getDoc(fileName);
                case DOCUMENT_TYPE.PDF:
                    return pdfHandler.getPdf(fileName);
            }
            throw new UtilException("Invalid document type");
        }

        public Domain.Document CopyDocument(String path, DOCUMENT_TYPE type)
        {
            switch (type)
            {
                case DOCUMENT_TYPE.WORD:
                    return wordHandler.CopyDocument(path);
                case DOCUMENT_TYPE.PDF:
                    return pdfHandler.CopyDocument(path);
            }
            throw new UtilException("Invalid document type");
        }

        public static void RenameDocument(String oldName, String newName)
        {
            String oldPath = Path.Combine(Environment.CurrentDirectory, oldName);
            String newPath = Path.Combine(Environment.CurrentDirectory, newName);
            System.IO.File.Move(oldPath, newPath);
        }

        public List<Tuple<User, string>> GetSignatures(string fileName, DOCUMENT_TYPE type)
        {
            switch (type)
            {
                case DOCUMENT_TYPE.WORD:
                    return wordHandler.getSignatures(fileName);
                case DOCUMENT_TYPE.PDF:
                    return pdfHandler.getSignatures(fileName);
            }
            throw new UtilException("Invalid document type");
        }

        /// <summary>
        /// Returns a list of users who added a signature
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public List<User> ReviseDocument(Domain.Document document)
        {
            switch (document.DocumentType)
            {
                case DOCUMENT_TYPE.WORD:
                    return wordHandler.modifyDoc(document);
                case DOCUMENT_TYPE.PDF:
                    return pdfHandler.modifyPdf(document);
            }
            throw new UtilException("Invalid document type");
        }
    }
}
