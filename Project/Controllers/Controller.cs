﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain;
using Project.Repository;
using Project.Exceptions;
using Project.Utils;
using System.Net.Mail;

namespace Project.Controllers
{
    class Controller
    {
        private User user;
        private DocumentRepository documentRepository;
        private UserRepository userRepository;
        private FlowRepository flowRepository;
        private LogRepository logRepository;

        public Controller(User user)
        {
            documentRepository = new DocumentRepository();
            userRepository = new UserRepository();
            flowRepository = new FlowRepository();
            logRepository = new LogRepository();

            this.user = user;
        }

        //Add Methods
        public void AddDocumentFromString(DOCUMENT_STATUS status,string abstract_string, string keywords, string fileName, List<int> flows, DOCUMENT_TYPE documentType)
        {
            try
            {
                int id = documentRepository.GetMaxId() + 1;
                int draftVersion = 1, finalVersion = 1, revisionVersion = 0;
                DateTime now = DateTime.Now;
                Document document = new Document(id, status, draftVersion, finalVersion, revisionVersion, user, now, now, abstract_string, keywords, fileName, flows, documentType);
                documentRepository.add(document);
                FileHandler.CreateDocument(document);

                LogAction(ACTION_TYPE.CREATE_DOCUMENT);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        public void AddDocumentFromFile(String path, DOCUMENT_TYPE type)
        {
            try
            {
                Document document = FileHandler.CopyDocument(path, type);
                int id = documentRepository.GetMaxId() + 1;
                document.Id = id;
                documentRepository.add(document);
                LogAction(ACTION_TYPE.CREATE_DOCUMENT);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        public void AddFlow(List<int> documents, User creator, List<List<int>> revisors, int step, DateTime creationDate)
        {
            try
            {
                int id = flowRepository.GetMaxId() + 1;
                Flow flow = new Flow(id, documents, creator, revisors, step, FLOW_STATUS.IN_PROGRESS, creationDate, DateTime.MinValue);
                flowRepository.add(flow);
                LogAction(ACTION_TYPE.CREATE_FLOW);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        public void AddRevision(Flow flow, Document document)
        {
            try
            {
                FileHandler.ReviseDocument(document);
                TryToAdvanceFlow(flow);
                LogAction(ACTION_TYPE.ADD_REVISION);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }



        //Get Methods
        public Document getDocumentById(int id)
        {
            try
            {
                return documentRepository.getById(id);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        public List<Document> getDocumentsByAuthor(int author_id)
        {
            List<Document> documents = null;
            try
            {
                documents = documentRepository.getAll();
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
            return documents.Where(document => document.Author.Id == author_id).ToList();
        }

        public List<Document> GetDocumentsByRevisor(int revisorId)
        {
            List<Document> documents = new List<Document>();

            try
            {
                User user = userRepository.getById(revisorId);
                Flow flow;

                foreach (int flowId in user.Flows)
                {
                    flow = flowRepository.getById(flowId);
                    foreach (int documentId in flow.Documents)
                    {
                        documents.Add(documentRepository.getById(documentId));
                    }
                }
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }

            if (documents.Count == 0)
            {
                return null;
            }

            return documents.Distinct().ToList();
        }

        public List<Document> GetAllDocuments()
        {
            List<Document> documents = null;

            try
            {
                documents = documentRepository.getAll();
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }

            return documents;
        }


        //Statistics
        public int GetNumberOfActiveFlows()
        {
            List<Flow> flows = null;

            try
            {
                flows = flowRepository.getAll();
                LogAction(ACTION_TYPE.VIEW_STATISTICS);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }

            return flows.Where(flow => flow.Status == FLOW_STATUS.IN_PROGRESS).Count();
        }

        public double GetAverageNumberOfPeopleInFlows()
        {
            List<Flow> flows = null;
            double average = 0;

            try
            {
                flows = flowRepository.getAll();
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }

            foreach (Flow flow in flows)
            {
                foreach (List<int> revisors in flow.Revisors)
                {
                    average += revisors.Count;
                }
            }

            LogAction(ACTION_TYPE.VIEW_STATISTICS);

            return average / flows.Count;
        }

        public double GetAverageNumberOfDocumentsOfPeople()
        {
            List<User> users = null;
            double average = 0;

            try
            {
                users = userRepository.getAll();
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }

            List<Document> documents = null;

            try
            {
                documents = documentRepository.getAll();
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }

            foreach (User user in users)
            {
                foreach (Document document in documents)
                {
                    if (user.Id == document.Author.Id)
                    {
                        ++average;
                    }
                }
            }

            LogAction(ACTION_TYPE.VIEW_STATISTICS);

            return average / users.Count;
        }

        public int GetNumberOfPeople()
        {
            List<User> users = null;

            try
            {
                users = userRepository.getAll();
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }

            LogAction(ACTION_TYPE.VIEW_STATISTICS);

            return users.Count;
        }
        
        public double GetAverageTimeOfFlows()
        {
            List<Flow> flows = flowRepository.getAll();
            double sum = 0, nr = 0;

            foreach (Flow flow in flows)
            {
                if (flow.Status == FLOW_STATUS.FINISHED)
                {
                    sum += (flow.EndDate - flow.CreationDate).TotalDays;
                    ++nr;
                }
            }

            LogAction(ACTION_TYPE.VIEW_STATISTICS);

            return sum / nr;
        }

        //Modify Methods
        public void ModifyDocument(int id, string abstract_string, string keywords, string fileName)
        {
            try
            {
                Document document = documentRepository.getById(id);
                document.Abstract_string = abstract_string;
                document.Keywords = keywords;
                if (document.FileName != fileName)
                {
                    FileHandler.RenameDocument(document.FileName, fileName);
                    document.FileName = fileName;
                }
                if (document.Status == DOCUMENT_STATUS.DRAFT)
                {
                    document.DraftVersion += 1;
                }
                else if (document.Status == DOCUMENT_STATUS.FINAL)
                {
                    document.FinalVersion += 1;
                }
                else if (document.Status == DOCUMENT_STATUS.FINAL_REVISED)
                {
                    document.RevisionVersion += 1;
                    RevertFlows(document);
                }
                document.ModificationDate = DateTime.Now;

                LogAction(ACTION_TYPE.MODIFY_DOCUMENT);
                documentRepository.update(document);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        //Delete Methods
        public void DeleteDocument(Document document)
        {
            try
            {
                documentRepository.delete(document);
                LogAction(ACTION_TYPE.DELETE_DOCUMENT);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        //Other
        //TODO
        public void SendEmails(Flow flow)
        {
            
        }

        private void RevertFlows(Document document)
        {
            List<Flow> flows = flowRepository.getAll();

            foreach (Flow flow in flows)
            {
                foreach (int documentId in flow.Documents)
                {
                    if (documentId == document.Id)
                    {
                        flow.Step = 0;
                        SendEmails(flow);
                        flowRepository.update(flow);
                        break;
                    }
                }
            }
        }

        public void SetDocumentToFinal(int id)
        {
            try
            {
                Document document = documentRepository.getById(id);
                if (document.Status == DOCUMENT_STATUS.DRAFT)
                {
                    document.Status = DOCUMENT_STATUS.FINAL;
                    documentRepository.update(document);
                } else
                {
                    throw new ControllerException("Status cannot be set to final");
                }
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        public void SetDocumentToDraft(int id)
        {
            try
            {
                Document document = documentRepository.getById(id);
                if (document.Status == DOCUMENT_STATUS.FINAL)
                {
                    document.Status = DOCUMENT_STATUS.DRAFT;
                    documentRepository.update(document);
                }
                else
                {
                    throw new ControllerException("Status cannot be set to draft");
                }
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        public void StopFlow(int flowId)
        {
            try
            {
                Flow flow = flowRepository.getById(flowId);
                flow.Status = FLOW_STATUS.STOPPED;
                flow.EndDate = DateTime.Now;
                flowRepository.update(flow);
                LogAction(ACTION_TYPE.DELETE_FLOW);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        private void TryToAdvanceFlow(Flow flow)
        {
            List<int> currentRevisors = flow.Revisors[flow.Step];
            bool finished = true;

            //Check if every document has been signed by every member of this step
            foreach (int documentId in flow.Documents)
            {
                Document document = documentRepository.getById(documentId);
                List<Tuple<User, String>> revisedBy = FileHandler.GetSignatures(document.FileName, document.DocumentType);
                foreach (int revisorId in currentRevisors)
                {
                    bool signed = false;
                    foreach (Tuple<User, String> tuple in revisedBy)
                    {
                        if (tuple.Item1.Id == revisorId)
                        {
                            signed = true;
                            break;
                        }
                    }
                    if (!signed)
                    {
                        finished = false;
                        break;
                    }
                }
                if (!finished)
                {
                    break;
                }
            }

            //Step is done, advance to the next
            if (finished)
            {
                ++flow.Step;
                SendEmails(flow);
                if (flow.Step == flow.Revisors.Count)
                {
                    flow.Status = FLOW_STATUS.FINISHED;
                }
                else
                {
                    TryToAdvanceFlow(flow);
                }
                flowRepository.update(flow);
            }
        }

        private void LogAction(ACTION_TYPE action)
        {
            int id = logRepository.GetMaxId() + 1;
            var unit = new UnitRepository().getById(user.Unitid);
            Log log = new Log(id, user, unit, DateTime.Now, action);
            logRepository.add(log);
        }
    }
}
