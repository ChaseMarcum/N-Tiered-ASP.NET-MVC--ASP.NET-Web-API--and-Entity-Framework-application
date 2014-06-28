using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AIM.Web.ClientApp.Models.EntityModels;

namespace AIM.Web.ClientApp.Models
{
    public class JsonQuestion
    {
        [Display(Name = @"Question Id")]
        public int? QJsonId { get; set; }

        [Display(Name = @"Question Type")]
        public TypeEnum? QJsonType { get; set; }

        [Display(Name = @"Question")]
        public string QJsonText { get; set; }

        [Display(Name = @"Question Option")]
        public IList<string> QJsonOptionList { get; set; }

        [Display(Name = @"Desired Answer")]
        public IList<string> QJsonAnswerList { get; set; }
    }
}