using Entities.Core;
using Entities.DTO;
using Models.Repositories;
using Models.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utils.Util;
using System.Drawing;


namespace Models.Services
{
    public class ImagenService : Service, IImagenService
    {
        private ConfigurationSectionWebApi _config;

        public ImagenService(ConfigurationSectionWebApi Config) : base(Config.Repository)
        {
            this._config = Config;
        }

        public ResultOperation<List<Imagen>> GetImage()
        {
            var result = WrapExecuteTrans<ResultOperation<List<Imagen>>, ImagenRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<Imagen>>();
                try
                {
                    rst.Result = repo.GetImage();
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


        public ResultOperation<int> AddImage(Imagen imagen)
        {
            ResultOperation<int> result =
                WrapExecuteTrans<ResultOperation<int>, ImagenRepository>((repo, uow) =>
                {
                    ResultOperation<int> rst = new ResultOperation<int>();

                    try
                    {
                        rst.Result = repo.AddImage(imagen);
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

        public ResultOperation<bool> PutImage(Imagen imagen)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, ImagenRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.stateOperation = repo.PutImage(imagen);
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
