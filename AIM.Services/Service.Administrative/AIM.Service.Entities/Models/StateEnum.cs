/****************************** Module Header ******************************\
* Module Name:  StateEnum.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* State Enum Model.
\***************************************************************************/

using System;
using System.Runtime.Serialization;

namespace AIM.Service.Entities.Models
{
    [DataContract(Name = "StateAbbreviation")]
    [Flags]
    public enum StateEnum : int
    {
        [EnumMember]
        AL = 0,

        [EnumMember]
        AK = 1,

        [EnumMember]
        AZ = 2,

        [EnumMember]
        AR = 3,

        [EnumMember]
        CA = 4,

        [EnumMember]
        CO = 5,

        [EnumMember]
        CT = 6,

        [EnumMember]
        DE = 7,

        [EnumMember]
        FL = 8,

        [EnumMember]
        GA = 9,

        [EnumMember]
        HI = 10,

        [EnumMember]
        ID = 11,

        [EnumMember]
        IL = 12,

        [EnumMember]
        IN = 13,

        [EnumMember]
        IA = 14,

        [EnumMember]
        KS = 15,

        [EnumMember]
        KY = 16,

        [EnumMember]
        LA = 17,

        [EnumMember]
        ME = 18,

        [EnumMember]
        MD = 19,

        [EnumMember]
        MA = 20,

        [EnumMember]
        MI = 21,

        [EnumMember]
        MN = 22,

        [EnumMember]
        MS = 23,

        [EnumMember]
        MO = 24,

        [EnumMember]
        MT = 25,

        [EnumMember]
        NE = 26,

        [EnumMember]
        NV = 27,

        [EnumMember]
        NH = 28,

        [EnumMember]
        NJ = 29,

        [EnumMember]
        NM = 30,

        [EnumMember]
        NY = 31,

        [EnumMember]
        NC = 32,

        [EnumMember]
        ND = 33,

        [EnumMember]
        OH = 34,

        [EnumMember]
        OK = 35,

        [EnumMember]
        OR = 36,

        [EnumMember]
        PA = 37,

        [EnumMember]
        RI = 38,

        [EnumMember]
        SC = 39,

        [EnumMember]
        SD = 40,

        [EnumMember]
        TN = 41,

        [EnumMember]
        TX = 42,

        [EnumMember]
        UT = 43,

        [EnumMember]
        VT = 44,

        [EnumMember]
        VA = 45,

        [EnumMember]
        WA = 46,

        [EnumMember]
        WV = 47,

        [EnumMember]
        WI = 48,

        [EnumMember]
        WY = 49
    }
}