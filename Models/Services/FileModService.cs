using Entities.Core;
using Entities.DTO;
using Models.Repositories;
using Models.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Util;

namespace Models.Services
{
    public class FileModService: Service, IFileModService
    {
        private ConfigurationSectionWebApi _config;

        public FileModService(ConfigurationSectionWebApi Config) : base(Config.Repository)
        {
            this._config = Config;
        }

        public ResultOperation<List<FileMod>> GetFile()
        {
            var result = WrapExecuteTrans<ResultOperation<List<FileMod>>, FileModRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<FileMod>>();
                try
                {
                    rst.Result = repo.GetFile();
                }
                catch (Exception err)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.Result = null;
                    rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                }
                return rst;
            });
            return result;
        }

        public ResultOperation<int> AddFile(FileMod fileMod)
        {
            ResultOperation<int> result =
                WrapExecuteTrans<ResultOperation<int>, FileModRepository>((repo, uow) =>
                {
                    ResultOperation<int> rst = new ResultOperation<int>();

                    try
                    {
                        rst.Result = repo.AddFile(fileMod);
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }

        public ResultOperation<bool> PutFile(FileMod fileMod)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, FileModRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.stateOperation = repo.PutFile(fileMod);
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }

    }
}
