﻿using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class Employee
    {
        #region Properties
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public int NoOfHours { get; set; }

        [DataMember]
        public bool IsAdmin { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool IsEmployed { get; set; }

        [DataMember]
        public string Salt { get; set; }

        [DataMember]
        public int DepartmentId { get; set; }

        [DataMember]
        public byte[] RowVersion { get; set; }
        #endregion
    }
}
