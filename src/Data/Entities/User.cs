using System;
using System.Collections.Generic;

namespace Handsoft.Prizes.App.Data.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Cellphone { get; set; }
        public string Code { get; set; }
        public int? DrawId { get; set; }
        public string Message { get; set; }
        public bool? Sended { get; set; }
        public bool? WinSend { get; set; }
        public string Telco { get; set; }
        public DateTime? Time { get; set; }
        public int? RegistrationType { get; set; }
        public string ParticipantId { get; set; }
        public string PersonId { get; set; }
    }
}
