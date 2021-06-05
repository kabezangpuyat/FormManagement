using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMS.Domain.Constants
{
    public static class MessagesConstants
    {
        #region Exceptions
        public const string ErrorCreatingUser = "Unable to create user. Please Contact your system Administrator.";
        public const string ErrorCreatingUserRole = "Unable to create user role. Please Contact your system Administrator.";
        public const string DataNotFound = "Data not found.";
        public const string FailedToDeleteData = "Failed to delete data.";
        public const string FailedToModifyData = "Failed to modify data.";
        public const string DataDeleted = "Data deleted.";
        public const string DataCreated = "Data created.";
        public const string DataModified = "Data modified.";
        public const string UnableToExecuteTransaction = "Unable to execute the transaction. Please contact your system administrator.";
        #endregion

        #region Form Messages
        public const string FailedFormCreation = "Failed to create form.";
        public const string DeleteFormPhysically = "Form physically deleted and it's related data."; 
        #endregion
    }
}
