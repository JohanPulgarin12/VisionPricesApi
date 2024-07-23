using Entities.Core;
using Entities.DTO;
using Models.Repositories;
using Models.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Util;

namespace Models.Services
{
    public class RolService : Service, IRolService
    {
        private ConfigurationSectionWebApi _config;

        public RolService(ConfigurationSectionWebApi Config) : base(Config.Repository)
        {
            this._config = Config;
        }

        public ResultOperation<List<Rol>> GetRol()
        {
            var result = WrapExecuteTrans<ResultOperation<List<Rol>>, RolRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<Rol>>();
                try
                {   
                    var rol = repo.GetRol();

                    for(int i = 0; i < rol.Count; i++)
                    {
                        rol[i].ArrayPermiso = repo.GetRolPermiso(rol[i].Id);
                    }

                    rst.Result = rol;
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

        public ResultOperation<List<Permiso>> GetPermiso()
        {
            var result = WrapExecuteTrans<ResultOperation<List<Permiso>>, RolRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<Permiso>>();
                try
                {
                    rst.Result = repo.GetPermiso();
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


        public ResultOperation<int> PostRol(Rol rol)
        {
            var result = WrapExecuteTrans<ResultOperation<int>, RolRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<int>();
                try
                {
                    rst.Result = repo.PostRol(rol);
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

        public ResultOperation<bool> PutRol(RolPermiso rolPermiso)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, RolRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();
                try
                {
                    bool resultOperation = true;

                    var rolResponse = repo.PutRol(rolPermiso.Rol);
                    if (!rolResponse)
                    {
                        resultOperation = false;
                    }

                    if (resultOperation && rolPermiso.Permiso.Count > 0)
                    {
                        var deleteResponse = repo.DeleteRolPermiso(rolPermiso.Rol.Id);
                        if (deleteResponse)
                        {
                            var data = new RolPermiso();
                            data.IdRol = rolPermiso.Rol.Id;

                            for (int i = 0; i < rolPermiso.Permiso.Count; i++)
                            {
                                data.IdPermiso = rolPermiso.Permiso[i];

                                var postResponse = repo.AddRolPermiso(data);
                                if (!postResponse)
                                {
                                    resultOperation = false;
                                    i = rolPermiso.Permiso.Count;
                                }
                            }
                        }
                        else
                        {
                            resultOperation = false;
                        }
                    }

                    rst.Result = resultOperation;
                }
                catch (Exception err)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.Result = false;
                    rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                }
                return rst;
            });
            return result;
        }

        public ResultOperation<bool> DeleteRol(int id)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, RolRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();
                try
                {
                    rst.Result = repo.DeleteRol(id);
                }
                catch (Exception err)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.Result = false;
                    rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                }
                return rst;
            });
            return result;
        }


        public ResultOperation<List<Permiso>> GetRolPermiso(int idRol)
        {
            var result = WrapExecuteTrans<ResultOperation<List<Permiso>>, RolRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<Permiso>>();
                try
                {
                    rst.Result = repo.GetRolPermiso(idRol);
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
        public ResultOperation<bool> AddRolPermiso(RolPermiso rolPermiso)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, RolRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.stateOperation = repo.AddRolPermiso(rolPermiso);
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.Result = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }

        public ResultOperation<bool> DeleteRolPermiso(int idRol)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, RolRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();
                try
                {
                    rst.Result = repo.DeleteRolPermiso(idRol);
                }
                catch (Exception err)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.Result = false;
                    rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                }
                return rst;
            });
            return result;
        }

    }
}