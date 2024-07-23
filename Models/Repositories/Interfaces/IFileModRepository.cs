using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories.Interfaces
{
    public interface IFileModRepository
    {
        List<FileMod> GetFile();
        int AddFile(FileMod fileMod);
        bool PutFile(FileMod fileMod);
    }
}
