using Entities.Core;
using Entities.DTO;
using Models.Repositories;
using Models.Repositories.Interfaces;
using Models.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Util;

namespace Models.Services
{
    public class ComponenteService : Service, IComponenteService
    {
        private ConfigurationSectionWebApi _config;

        public ComponenteService(ConfigurationSectionWebApi Config) : base(Config.Repository)
        {
            this._config = Config;
        }

        public ResultOperation<List<Componente>> GetComponente()
        {
            var result = WrapExecuteTrans<ResultOperation<List<Componente>>, ComponenteRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<Componente>>();
                try
                {
                    rst.Result = repo.GetComponente();
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


        public ResultOperation<bool> AddComponente(Componente componente)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, ComponenteRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.stateOperation = repo.AddComponente(componente);
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
        public ResultOperation<bool> PutComponente(Componente componente)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, ComponenteRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.stateOperation = repo.PutComponente(componente);
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


        public ResultOperation<bool> DeleteComponente(int id)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, ComponenteRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.stateOperation = repo.DeleteComponente(id);
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

        public ResultOperation<Imagen> GetImagenComponente(int idComponente)
        {
            var result = WrapExecuteTrans<ResultOperation<Imagen>, ComponenteRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<Imagen>();
                try
                {
                    rst.Result = repo.GetImagenComponente(idComponente);
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
    }
}
