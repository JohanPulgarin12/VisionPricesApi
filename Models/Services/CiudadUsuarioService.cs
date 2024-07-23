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
    public class CiudadUsuarioService: Service, ICiudadUsuarioService
    {
        private ConfigurationSectionWebApi _config;

        public CiudadUsuarioService(ConfigurationSectionWebApi Config) : base(Config.Repository)
        {
            this._config = Config;
        }

        public ResultOperation<List<CiudadUsuario>> GetCiudad()
        {
            var result = WrapExecuteTrans<ResultOperation<List<CiudadUsuario>>, CiudadUsuarioRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<CiudadUsuario>>();
                try
                {
                    rst.Result = repo.GetCiudad();
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

        public ResultOperation<bool> AddCiudad(CiudadUsuario ciudadUsuario)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, CiudadUsuarioRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.stateOperation = repo.AddCiudad(ciudadUsuario);
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

        public ResultOperation<bool> PutCiudad(CiudadUsuario ciudadUsuario)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, CiudadUsuarioRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.stateOperation = repo.PutCiudad(ciudadUsuario);
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

        public ResultOperation<bool> DeleteCiudad(int id)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, CiudadUsuarioRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.stateOperation = repo.DeleteCiudad(id);
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
