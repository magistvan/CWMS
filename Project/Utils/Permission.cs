using Project.Domain;
using Project.Exceptions;
using Project.Repository;
using System.Collections.Generic;

namespace Project.Utils
{
    class Permission
    {
        private Dictionary<ACTION_TYPE, int> permissionLevels;
        private FlowRepository flowRepo;
        private DocumentRepository documentRepo;

        public Permission()
        {
            permissionLevels = new Dictionary<ACTION_TYPE, int>();
            permissionLevels.Add(ACTION_TYPE.CREATE_DOCUMENT, 1);
            permissionLevels.Add(ACTION_TYPE.CREATE_FLOW, 1);
            permissionLevels.Add(ACTION_TYPE.DELETE_DOCUMENT, 3);
            permissionLevels.Add(ACTION_TYPE.MODIFY_DOCUMENT, 3);
            permissionLevels.Add(ACTION_TYPE.ADD_REVISION, 1);
            permissionLevels.Add(ACTION_TYPE.DELETE_FLOW, 3);
            permissionLevels.Add(ACTION_TYPE.VIEW_DOCUMENT, 3);
            permissionLevels.Add(ACTION_TYPE.VIEW_STATISTICS, 2);
            flowRepo = new FlowRepository();
            documentRepo = new DocumentRepository();
        }
        
        /// <summary>
        /// Use this before Creating documents or flows
        /// </summary>
        /// <param name="user"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool HasPermissionToCreate(User user, ACTION_TYPE action)
        {
            if (action != ACTION_TYPE.CREATE_DOCUMENT && action != ACTION_TYPE.CREATE_FLOW)
            {
                throw new UtilException("Wrong action type given");
            }
            return HasAccess(user, action);
        }

        /// <summary>
        /// Use this before deleting or modifying document (not for revision)
        /// Delete permission granted if the document is not part of any flows and is owned by the user (or user is admin)
        /// Modify permission if it is owned by the user (or user is admin)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="document"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool HasDocumentModificationPermission(User user, Document document, ACTION_TYPE action)
        {
            if (action != ACTION_TYPE.DELETE_DOCUMENT && action != ACTION_TYPE.MODIFY_DOCUMENT)
            {
                throw new UtilException("Wrong action type given");
            }
            List<Flow> flows = flowRepo.getAll();
            foreach (Flow flow in flows)
            {
                foreach (int id in flow.Documents)
                {
                    Document d = documentRepo.getById(id);
                    if (d.Equals(document))
                    {
                        if (action == ACTION_TYPE.DELETE_DOCUMENT)
                            return false;
                    }
                }
            }
            if (document.Author.Equals(user))
            {
                return true;
            }
            else
            {
                return HasAccess(user, action);
            }
        }

        /// <summary>
        /// Use it only for revisions.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="flow"></param>
        /// <returns>True if User is part of the current group of revisors and is at least a contributor</returns>
        public bool HasRevisionPermission(User user, Flow flow)
        {
            List<int> revisorIds = flow.Revisors[flow.Step];
            foreach (int id in revisorIds)
            {
                if (id == user.Id)
                {
                    return HasAccess(user, ACTION_TYPE.ADD_REVISION);
                }
            }
            return false;
        }

        /// <summary>
        /// Use it for viewing documents
        /// </summary>
        /// <param name="user"></param>
        /// <param name="document"></param>
        /// <returns>True if user is document owner or revisor of it (or user is admin)</returns>
        public bool HasDocumentOpenPermission(User user, Document document)
        {
            List<Flow> flows = flowRepo.getAll();
            if (document.Author.Equals(user))
            {
                return true;
            }
            foreach (Flow flow in flows)
            {
                bool containsDocument = false;
                foreach (int id in flow.Documents)
                {
                    if (id == document.Id)
                    {
                        containsDocument = true;
                        break;
                    }
                }
                if (containsDocument)
                {
                    if (flow.Status == FLOW_STATUS.FINISHED)
                    {
                        return true;
                    }
                    List<List<int>> revisors = flow.Revisors;
                    foreach (List<int> revisorList in revisors)
                    {
                        foreach (int id in revisorList)
                        {
                            if (id == user.Id)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return HasAccess(user, ACTION_TYPE.VIEW_DOCUMENT);
        }

        /// <summary>
        /// For statistics functions
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool HasStatisticsPermission(User user)
        {
            return HasAccess(user, ACTION_TYPE.VIEW_STATISTICS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="document"></param>
        /// <returns>True if document is in final status</returns>
        public bool CanAddDocumentToFlow(User user, Document document)
        {
            if (document.Status == DOCUMENT_STATUS.FINAL)
            {
                return true;
            }
            return false;
        }

        private bool HasAccess(User user, ACTION_TYPE action)
        {
            int value;
            permissionLevels.TryGetValue(action, out value);
            return user.AccessLevel() >= value;
        }
    }
}
