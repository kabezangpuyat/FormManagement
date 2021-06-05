using QMS.Domain.Models.Form;
using QMS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses.FormCategory
{
    public class GetAllFormCategoryResponse : ICommandQueryResponse
    {
        public List<FormCategoryViewModel> FormCategories { get; set; }
    }
}
