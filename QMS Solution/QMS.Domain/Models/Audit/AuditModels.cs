using QMS.Domain.Models.Form;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Audit
{
    public class AuditViewModel : _BaseViewModel
    {
        public string Notes { get; set; }
        public FormViewModel Form { get; set; }
        public List<AuditDetailViewModels> Details { get; set; }
        public UserViewModel Teammate { get; set; }
        public UserViewModel AuditedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
     
    public class AuditDetailViewModels 
    {
        public long ID { get; set; }
        public long AuditID { get; set; }
        public long? QuestionId { get; set; }
        public long? ChoiceId { get; set; }
        public string Notes { get; set; }
        public long? CreatedByID { get; set; }
        public bool Active { get; set; }
        public FormQuestionViewModel Question { get; set; }
        public FormChoiceViewModel Choice { get; set; }
    }
}
