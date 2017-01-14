using System;
using System.Collections.Generic;
using Project.Domain;
using Project.Exceptions;
using System.IO;

namespace Project.Utils
{
    static class FileHandler
    {
        public static void CreateDocument(Domain.Document document)
        {
            switch (document.DocumentType)
            {
                case DOCUMENT_TYPE.WORD:
                    WordHandler.createDoc(document);
                    break;
                case DOCUMENT_TYPE.PDF:
                    PdfHandler.createPdf(document);
                    break;
                default:
                    throw new UtilException("Invalid document type");
            }
        }

        public static Domain.Document GetDocument(string fileName, DOCUMENT_TYPE type)
        {
            switch (type)
            {
                case DOCUMENT_TYPE.WORD:
                    return WordHandler.getDoc(fileName);
                case DOCUMENT_TYPE.PDF:
                    return PdfHandler.getPdf(fileName);
            }
            throw new UtilException("Invalid document type");
        }

        public static Domain.Document CopyDocument(String path, DOCUMENT_TYPE type)
        {
            switch (type)
            {
                case DOCUMENT_TYPE.WORD:
                    return WordHandler.CopyDocument(path);
                case DOCUMENT_TYPE.PDF:
                    return PdfHandler.CopyDocument(path);
            }
            throw new UtilException("Invalid document type");
        }

        public static void RenameDocument(String oldName, String newName)
        {
            String oldPath = Path.Combine(Environment.CurrentDirectory, oldName);
            String newPath = Path.Combine(Environment.CurrentDirectory, newName);
            System.IO.File.Move(oldPath, newPath);
        }

        public static List<Tuple<User, string>> GetSignatures(string fileName, DOCUMENT_TYPE type)
        {
            switch (type)
            {
                case DOCUMENT_TYPE.WORD:
                    return WordHandler.getSignatures(fileName);
                case DOCUMENT_TYPE.PDF:
                    return PdfHandler.getSignatures(fileName);
            }
            throw new UtilException("Invalid document type");
        }

        /// <summary>
        /// Returns a list of users who added a signature
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static List<User> ReviseDocument(Domain.Document document)
        {
            switch (document.DocumentType)
            {
                case DOCUMENT_TYPE.WORD:
                    return WordHandler.modifyDoc(document);
                case DOCUMENT_TYPE.PDF:
                    return PdfHandler.modifyPdf(document);
            }
            throw new UtilException("Invalid document type");
        }
    }
}
