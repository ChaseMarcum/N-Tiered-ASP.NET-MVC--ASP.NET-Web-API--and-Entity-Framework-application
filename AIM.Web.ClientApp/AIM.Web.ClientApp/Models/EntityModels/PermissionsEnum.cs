/****************************** Module Header ******************************\
* Module Name:  PermissionsEnum.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Permissions Enum Model.
\***************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AIM.Web.ClientApp.Models.EntityModels
{
    [DataContract(Name = "EmployeePermissions")]
    [Flags]
    public enum PermissionsEnum : int
    {
        [EnumMember]
        [Display(Name = "Employee")]
        Employee = 0,

        [EnumMember]
        [Display(Name = "Hiring Manager")]
        HiringManager = 1,

        [EnumMember]
        [Display(Name = "Hiring Specialist")]
        HiringSpecialist = 2,

        [EnumMember]
        [Display(Name = "Staffing Expert")]
        StaffingExpert = 3,

        [EnumMember]
        [Display(Name = "Store Manager")]
        StoreManager = 4,

        [EnumMember]
        [Display(Name = "System Administrator")]
        SystemAdmin = 5
    }
}