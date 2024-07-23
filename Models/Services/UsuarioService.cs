using Entities.Core;
using Entities.DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Models.Repositories;
using Models.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Xml.Linq;
using Utils.Security;
using Utils.Util;

namespace Models.Services
{
    public class UsuarioService : Service, IUsuarioService
    {
        private EncryptionService Encryption = new EncryptionService();

        private readonly ConfigurationSectionWebApi _config;
        private readonly EmailConfiguration _configEmail;
        
        public UsuarioService(ConfigurationSectionWebApi Config, EmailConfiguration ConfigEmail) : base(Config.Repository)
        {
            _config = Config;
            _configEmail = ConfigEmail;
        }
        public ResultOperation<List<Usuario>> GetUsuario()
        {
            var result = WrapExecuteTrans<ResultOperation<List<Usuario>>, UsuarioRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<Usuario>>();
                try
                {
                    rst.Result = repo.GetUsuario();
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

        public ResultOperation<bool> AddUser(Usuario usuario)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, UsuarioRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        usuario.Pass = EncodePass(usuario.Pass);
                        rst.Result = repo.AddUser(usuario);
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

        public ResultOperation<bool> PutUser(Usuario usuario)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, UsuarioRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        usuario.Pass = EncodePass(usuario.Pass);
                        rst.Result = repo.PutUser(usuario);
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

        public ResultOperation<bool> UpdateState(string identi)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, UsuarioRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        Usuario user = GetUsuarioByIdentificacion(identi).Result;
                        user.Estado = !user.Estado;
                        rst.Result = repo.PutUser(user);
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

        public ResultOperation<bool> DeleteUser(int id)
        {
            ResultOperation<bool> result =
                WrapExecuteTrans<ResultOperation<bool>, UsuarioRepository>((repo, uow) =>
                {
                    ResultOperation<bool> rst = new ResultOperation<bool>();

                    try
                    {
                        rst.Result = repo.DeleteUser(id);
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

        public ResultOperation<Usuario> GetUsuarioByIdentificacion(string identificacion)
        {
            var result = WrapExecuteTrans<ResultOperation<Usuario>, UsuarioRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<Usuario>();
                try
                {
                    rst.Result = repo.GetUsuarioByIdentificacion(identificacion);
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

        public ResultOperation<List<int>> GetUsuarioPermiso(string identiUser)
        {
            var result = WrapExecuteTrans<ResultOperation<List<int>>, UsuarioRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<int>>();
                try
                {
                    rst.Result = repo.GetUsuarioPermiso(identiUser);
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

        private bool VerifyPass(string password, string enPassword)
        {
            var encodePass = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            
            if(encodePass == enPassword)
            {
                return true;
            }else{
                return false;
            }
        }

        public ResultOperation<UsuarioLogin> Login(string identificacion, string password)
        {
            var result = WrapExecuteTrans<ResultOperation<UsuarioLogin>, UsuarioRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<UsuarioLogin>();
                try
                {
                    var user = GetUsuarioByIdentificacion(identificacion).Result;

                    if (user != null && user.Estado && VerifyPass(password, user.Pass))
                    {
                        UsuarioLogin usuario = new UsuarioLogin();
                        usuario.Username = user.Username;
                        usuario.NewUser = user.NewUser;
                        usuario.Permiso = GetUsuarioPermiso(identificacion).Result;

                        rst.Result = usuario;
                    }
                    else
                    {
                        rst.Result = null;
                    }
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

        private string EncodePass(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }

        private string DecodePass(string password)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(password));
        }

        private string DecodeUsername(string fromEmail)
        {
            string _Email = Encryption.DescifrarCadena(fromEmail);
            return _Email;
        }

        private string DecodePassword(string fromPass) 
        {
            string _Pass = Encryption.DescifrarCadena(fromPass);
            return _Pass;
        }

        public bool SendEmail(string fromEmail, string server, string fromPass, string identificacion)
        {
            var user = GetUsuarioByIdentificacion(identificacion).Result;

            var decryptIdentificacion = DecodeUsername(fromEmail);
            var decryptPassword = DecodePassword(fromPass);
            user.Pass = DecodePass(user.Pass);

            var correo = new MailMessage
            {
                From = new MailAddress(decryptIdentificacion), 
                Subject = "Este es su usuario y contraseña de Vision Price",
                Body = $"Señor(a): {user.Nombre} {user.Apellido}\r\n\nEste es su usuario y contraseña de acceso al Sistema Visión Price.\nRecuerde que esta información es su responsabilidad, por seguridad no la revele a nadie y cambie periódicamente su clave.\n\n" + "Estas son sus credenciales.\n" + "Usuario: " + identificacion + "  " + "\nContraseña: " + user.Pass + "\n\n" + "Para información personal este es su nombre de usuario:" + " " + user.Username,
                IsBodyHtml = false
            };
            correo.To.Add(user.Email);

            using (var clienteSmtp = new SmtpClient(server))
            {
                clienteSmtp.Port = 587;
                clienteSmtp.Credentials = new NetworkCredential(decryptIdentificacion, decryptPassword);
                clienteSmtp.EnableSsl = true;

                try
                {
                    clienteSmtp.Send(correo);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar el correo: " + ex.Message);
                    return false;
                }
            }
        }

        public bool ForgotEmail(string fromEmail, string server, string fromPass, string username, string identificacion, string telefono)
        {
            var user = GetUsuarioByIdentificacion(identificacion).Result;

            if (user != null && user.Username == username && user.Identificacion == identificacion && user.Telefono == telefono)
            {
                var decryptIdentificacion = DecodeUsername(fromEmail);
                var decryptPassword = DecodePassword(fromPass);
                user.Pass = DecodePass(user.Pass);

                var correo = new MailMessage
                {
                    From = new MailAddress(decryptIdentificacion),
                    Subject = "Tu contraseña de Vision Price actual es:",
                    Body = $"Señor(a): {user.Nombre} {user.Apellido}\r\n\nDe acuerdo a su solicitud estamos enviando la clave de acceso al Sistema.\nRecuerde que esta información es su responsabilidad, por seguridad no la revele a nadie y cambie periódicamente su clave.\n\n\n Su contraseña es: {user.Pass}",
                    IsBodyHtml = false
                };
                correo.To.Add(user.Email);

                using (var clienteSmtp = new SmtpClient(server))
                {
                    clienteSmtp.Port = 587;
                    clienteSmtp.Credentials = new NetworkCredential(decryptIdentificacion, decryptPassword);
                    clienteSmtp.EnableSsl = true;

                    try
                    {
                        clienteSmtp.Send(correo);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al enviar el correo: " + ex.Message);
                        return false;
                    }
                }
            }else{
                return false;
            }
        }

        public bool ChangeEmail(string fromEmail, string server, string fromPass, string oldPass, string newPass, string identificacion)
        {
            var user = GetUsuarioByIdentificacion(identificacion).Result;

            if (user != null)
            {
                if (user.Pass == EncodePass(oldPass))
                { 
                    try
                    {
                        user.Pass = newPass;
                        var response = PutUser(user);
                        var decryptIdentificacion = DecodeUsername(fromEmail);
                        var decryptPassword = DecodePassword(fromPass);

                        var correo = new MailMessage
                        {
                            From = new MailAddress(decryptIdentificacion),
                            Subject = "Se ha actualizado tu contraseña de Vision Price",
                            Body = $"Señor(a): {user.Nombre} {user.Apellido}\r\n\nDe acuerdo a su solicitud se ha actualizado la clave de acceso al Sistema Vision Price.\nRecuerde que esta información es su responsabilidad, por seguridad no la revele a nadie y cambie periódicamente su clave.\n\n\n Su contraseña es: {newPass}",
                            IsBodyHtml = false
                        };
                        correo.To.Add(user.Email);

                        using (var clienteSmtp = new SmtpClient(server))
                        {
                            clienteSmtp.Port = 587;
                            clienteSmtp.Credentials = new NetworkCredential(decryptIdentificacion, decryptPassword);
                            clienteSmtp.EnableSsl = true;

                            clienteSmtp.Send(correo);
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al enviar el correo: " + ex.Message);
                        return false;
                    }
                }else{ return false; }
            }else{ return false; }
        }

        public ResultOperation<List<CiudadUsuario>> GetUsuarioCiudad(int idUsuario)
        {
            var result = WrapExecuteTrans<ResultOperation<List<CiudadUsuario>>, UsuarioRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<CiudadUsuario>>();
                try
                {
                    rst.Result = repo.GetUsuarioCiudad(idUsuario);
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
