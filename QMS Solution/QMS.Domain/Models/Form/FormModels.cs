using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Form
{
    public class FormViewModel : _BaseViewModel
    {
        public Guid Key { get; set; }
        public bool IsNoteVisible { get; set; }
        public FormCategoryViewModel Category { get; set; }
        public FormTypeViewModel FormType { get; set; } 
        public List<FormQuestionViewModel> Questions { get; set; }
    }

    public class FormQuestionViewModel : _BaseViewModel
    {
        public bool IsNoteVisible { get; set; }
        public int SortOrder { get; set; }
        public long HtmlControlID { get; set; }
        public List<FormChoiceViewModel> Choices { get; set; } 
        public HtmlControlViewModel HtmlControl { get; set; }
    }

    public class FormChoiceViewModel: _BaseViewModel
    {
        public int Value { get; set; }
        public int SortOrder { get; set; }
    }

    public class FormCategoryViewModel : _BaseViewModel
    {

    }
    public class FormTypeViewModel : _BaseViewModel
    {

    }
    public class HtmlControlViewModel : _BaseViewModel
    {

    }
}
