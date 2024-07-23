using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set;}
        public bool Ssl {  get; set; }
        public bool UserDefault {  get; set; }

    }
}
