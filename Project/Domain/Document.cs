using System;
using System.Collections.Generic;

namespace Project.Domain
{
    class Document
    {
        private int id;
        private DOCUMENT_STATUS status;
        private int draftVersion;
        private int finalVersion;
        private int revisionVersion;
        private User author;
        private DateTime creationDate;
        private DateTime modificationDate;
        private String abstract_string;
        private String keywords;
        private String fileName;
        private DOCUMENT_TYPE type;
        private List<int> flows;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        internal DOCUMENT_STATUS Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int DraftVersion
        {
            get
            {
                return draftVersion;
            }

            set
            {
                draftVersion = value;
            }
        }

        public int FinalVersion
        {
            get
            {
                return finalVersion;
            }

            set
            {
                finalVersion = value;
            }
        }

        public int RevisionVersion
        {
            get
            {
                return revisionVersion;
            }

            set
            {
                revisionVersion = value;
            }
        }

        internal User Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }

            set
            {
                creationDate = value;
            }
        }

        public DateTime ModificationDate
        {
            get
            {
                return modificationDate;
            }

            set
            {
                modificationDate = value;
            }
        }

        public string Abstract_string
        {
            get
            {
                return abstract_string;
            }

            set
            {
                abstract_string = value;
            }
        }

        public string Keywords
        {
            get
            {
                return keywords;
            }

            set
            {
                keywords = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public List<int> Flows
        {
            get
            {
                return flows;
            }

            set
            {
                flows = value;
            }
        }

        public DOCUMENT_TYPE DocumentType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public Document(int id, DOCUMENT_STATUS status, int draftVersion, int finalVersion, int revisionVersion, User author, DateTime creationDate, DateTime modificationDate, string abstract_string, string keywords, string fileName, List<int> flows, DOCUMENT_TYPE type)
        {
            this.id = id;
            this.status = status;
            this.draftVersion = draftVersion;
            this.finalVersion = finalVersion;
            this.revisionVersion = revisionVersion;
            this.author = author;
            this.creationDate = creationDate;
            this.modificationDate = modificationDate;
            this.abstract_string = abstract_string;
            this.keywords = keywords;
            this.fileName = fileName;
            this.flows = flows;
            this.type = type;
        }

        public override bool Equals(object obj)
        {
            if (obj is Document)
            {
                Document other = (Document)obj;
                if (other.id == id)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id;
        }

        //Calculates and returns the version depending on the status
        public double Version()
        {
            if (status == DOCUMENT_STATUS.DRAFT)
            {
                double v = draftVersion;
                while (v >= 1)
                {
                    v /= 10.0;
                }
                return v;
            }
            else if (status == DOCUMENT_STATUS.FINAL)
            {
                return finalVersion;
            }
            else
            {
                double v = revisionVersion;
                while (v >= 1)
                {
                    v /= 10.0;
                }
                return finalVersion + v;
            }
        }
    }
}
