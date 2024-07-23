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
    public class ModuloService : Service, IModuloService
    {
        private ConfigurationSectionWebApi _config;

        public ModuloService(ConfigurationSectionWebApi Config) : base(Config.Repository)
        {
            this._config = Config;
        }

        public ResultOperation<List<Modulo>> GetModulo()
        {
            var result = WrapExecuteTrans<ResultOperation<List<Modulo>>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<Modulo>>();
                try
                {
                    rst.Result = repo.GetModulo();
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

        public ResultOperation<int> AddModulo(Modulo modulo)
        {
            var result = WrapExecuteTrans<ResultOperation<int>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<int>();
                try
                {
                    rst.Result = repo.AddModulo(modulo);
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

        public ResultOperation<bool> PutModulo(Modulo modulo)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();
                try
                {
                    rst.Result = repo.PutModulo(modulo);
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

        public ResultOperation<bool> DeleteModulo(int id)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();
                try
                {
                    rst.Result = repo.DeleteModulo(id);
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

        public ResultOperation<List<Componente>> GetModuloComponente(int idModulo)
        {
            var result = WrapExecuteTrans<ResultOperation<List<Componente>>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<Componente>>();
                try
                {
                    rst.Result = repo.GetModuloComponente(idModulo);
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

        public ResultOperation<bool> AddModuloComponente(ModuloComponente moduloComponente)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();
                try
                {
                    rst.Result = repo.AddModuloComponente(moduloComponente);
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

        public ResultOperation<bool> PutModuloComponente(ModuloComponente moduloComponente)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();
                try
                {
                    rst.Result = repo.PutModuloComponente(moduloComponente);
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

        public ResultOperation<bool> DeleteModuloComponente(ModuloComponente moduloComponente)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();
                try
                {
                    rst.Result = repo.DeleteModuloComponente(moduloComponente);
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
        public ResultOperation<Imagen> GetImagenModulo(int idModulo)
        {
            var result = WrapExecuteTrans<ResultOperation<Imagen>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<Imagen>();
                try
                {
                    rst.Result = repo.GetImagenModulo(idModulo);
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
        public ResultOperation<Imagen> GetImagenCarrusel(int idCarrusel)
        {
            var result = WrapExecuteTrans<ResultOperation<Imagen>, ModuloRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<Imagen>();
                try
                {
                    rst.Result = repo.GetImagenCarrusel(idCarrusel);
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

        public ResultOperation<FileMod> GetFileModulo(int idModulo)
        {
            var result = WrapExecuteTrans<ResultOperation<FileMod>, ModuloRepository> ((repo, uow) =>
            {
                var rst = new ResultOperation<FileMod>();
                try
                {
                    rst.Result = repo.GetFileModulo(idModulo);
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
