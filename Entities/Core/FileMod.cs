using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Core
{
    public class FileMod
    {
        public int Id { get; set; }
        public string FileNameMod { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileByte { get; set; }
    }
}
