/****************************** Module Header ******************************\
* Module Name:  StatusEnum.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Status Enum Model.
\***************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AIM.Web.Admin.Models.EntityModels
{
    [DataContract(Name = "Status")]
    public enum StatusEnum : int
    {
        [EnumMember]
        [Display(Name = "Inital Application Not Submitted")]
        InitalApplicationNonSubmitted = 0,

        [EnumMember]
        [Display(Name = "Phone Interview Queue")]
        PhoneInterviewQueue = 1,

        [EnumMember]
        [Display(Name = "In Person Interview Queue")]
        InPersonInterviewQueue = 2,

        [EnumMember]
        [Display(Name = "Check Reference Queue")]
        CheckReferenceQueue = 3,

        [EnumMember]
        [Display(Name = "Rejected")]
        Rejected = 4,

        [EnumMember]
        [Display(Name = "Pending Review Queue")]
        PendingReviewQueue = 5,

        [EnumMember]
        [Display(Name = "Hired Status")]
        HiredStatus = 6
    }
}