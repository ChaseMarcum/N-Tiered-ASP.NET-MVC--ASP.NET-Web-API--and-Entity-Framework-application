/****************************** Module Header ******************************\
* Module Name:  Applicant.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Applicant Model.
\***************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AIM.Service.Entities.Models
{
    [DataContract(Name = "QuestionType")]
    [Flags]
    public enum TypeEnum : int
    {
        [EnumMember]
        [Display(Name = "Multiple Choice")]
        MultipleChoice = 0,

        [EnumMember]
        [Display(Name = "Select All That Apply")]
        AllThatApply = 1,

        [EnumMember]
        [Display(Name = "Free Form Question")]
        FreeForm = 2
    }
}