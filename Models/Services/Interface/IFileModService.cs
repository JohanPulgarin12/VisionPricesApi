using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Util;

namespace Models.Services.Interface
{
    public interface IFileModService
    {
        ResultOperation<List<FileMod>> GetFile();
        ResultOperation<int> AddFile(FileMod fileMod);
        ResultOperation<bool> PutFile(FileMod fileMod);
    }
}
