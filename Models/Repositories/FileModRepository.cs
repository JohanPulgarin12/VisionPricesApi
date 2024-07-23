using Dapper;
using Entities.Core;
using Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories
{
    public class FileModRepository : Repository
    {
        public List<FileMod> GetFile()
        {
            string sql = @"SELECT * FROM FileMod";
            var response = GetList<FileMod>(sql);
            return response;

        }

        public int AddFile(FileMod fileMod)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("FileNameMod", fileMod.FileNameMod);
            prms.Add("FileExtension", fileMod.FileExtension);
            prms.Add("FileByte", fileMod.FileByte);
            string sql = @"INSERT INTO FileMod (FileNameMod, FileExtension, FileByte) values (@FileNameMod, @FileExtension, @FileByte)
                        SELECT @@IDENTITY";
            var response = Get<int>(sql, prms);
            return response;
        }

        public bool PutFile(FileMod fileMod)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", fileMod.Id);
            prms.Add("FileNameMod", fileMod.FileNameMod);
            prms.Add("FileExtension", fileMod.FileExtension);
            prms.Add("FileByte", fileMod.FileByte);
            string sql = @"UPDATE FileMod
                            SET FileNameMod = @FileNameMod,
                                FileExtension = @FileExtension,
                                FileByte = @FileByte
                        WHERE Id = @Id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;

        }

    }
}
