﻿using PassportRecognitionProject.src.Models;
using System;
using System.Collections.Generic;

namespace PassportRecognitionProject.src.Database
{
    public class DatabaseService : IDatabaseService
    {
        public object CheckWriteAndReturnDocumentInfo(ExternalObjectModel externalModel)
        {
            throw new NotImplementedException();
        }

        public object GetDocumentInfo(Guid documentId, int[] pages)
        {
            throw new NotImplementedException();
        }

        public List<object> GetScannedDocuments()
        {
            throw new NotImplementedException();
        }
    }
}
