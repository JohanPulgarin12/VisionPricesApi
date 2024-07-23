﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    public class JwtUser
    {
        [JsonProperty("Login")]
        public string Login { get; set; }
        [JsonProperty("Password")]
        public byte[] Password { get; set; }
        [JsonProperty("Salt")]
        public byte[] Salt { get; set; }
    }
}
