using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SHL.Criptografia;
using SHL.IRetorno.Model;
using SHL.TokenSecurity.Business;
using SHL.TokenSecurity.Model;
using SHL.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SHL.TokenSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenSecurityController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("GetAccess/")]
        public Boolean GetAccess(String key)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-US");
            Boolean bret = false;
            TOKEN token = null;
            TOKEN_BL tokenbl = null;
            String messageret = String.Empty;
            String[] message;
            String credencial = String.Empty;
            String url = String.Empty;
            String tokenaccess = String.Empty;
            DateTime timemessage;
            TimeSpan interval;

            try
            {
                messageret = TokenKey.GetDecryptMessage(key);

                message = messageret.Split("|");

                if (message.Length != 3)
                    return false;

                credencial = message[0].Trim();
                tokenaccess = message[1].Trim();
                url = message[2].Trim();

                tokenbl = new TOKEN_BL();
                token = new TOKEN();
                token.KEY = tokenaccess;
                token = tokenbl.Select(token);

                if(token != null)
                {
                    tokenbl.Delete(token);

                    if (token.URL.ToUpper() == url.ToUpper() && token.CREDENCIAL.ToUpper() == credencial.ToUpper())
                    { 
                        timemessage = DateTime.Parse(token.NOW, MyCultureInfo);
                        interval = DateTime.Now - timemessage;
                        #if DEBUG
                        if (interval.Seconds < 50)
                            bret = true;
                        #else
                        if (interval.Seconds < 50)
                            bret = true;
                        #endif
                    }
                }
            }
            catch (Exception)
            {

            }

            return bret;
        }

        [HttpGet]
        [Route("GetTestAccess/")]
        public String GetTestAccess(String key)
        {
            String retorno = String.Empty;
            CultureInfo MyCultureInfo = new CultureInfo("en-US");
            Boolean bret = false;
            TOKEN token = null;
            TOKEN_BL tokenbl = null;
            String messageret = String.Empty;
            String[] message;
            String credencial = String.Empty;
            String url = String.Empty;
            String tokenaccess = String.Empty;
            DateTime timemessage;
            TimeSpan interval;

            try
            {
                messageret = TokenKey.GetDecryptMessage(key);

                message = messageret.Split("|");

                if (message.Length != 3)
                {
                    return String.Format("Formato inválido\n{0}", messageret);
                }

                credencial = message[0].Trim();
                tokenaccess = message[1].Trim();
                url = message[2].Trim();

                tokenbl = new TOKEN_BL();
                token = new TOKEN();
                token.KEY = tokenaccess;
                token = tokenbl.Select(token);

                if (token != null)
                {
                    if (token.URL.ToUpper() == url.ToUpper() && token.CREDENCIAL.ToUpper() == credencial.ToUpper())
                    {
                        timemessage = DateTime.Parse(token.NOW, MyCultureInfo);
                        interval = DateTime.Now - timemessage;
                        if (interval.Seconds < 50)
                            retorno = String.Format("Acesso liberado: Url{0} - Credencial: {1}", token.URL.ToUpper(), token.CREDENCIAL.ToUpper());
                        else
                            retorno = String.Format("Acesso negado - Tempo superior 50 segundos: Url{0} - Credencial: {1}", token.URL.ToUpper(), token.CREDENCIAL.ToUpper());
                    }
                    else
                        retorno = String.Format("Acesso negado - Dados inconsistentes : Url{0} / {1} - Credencial: {2} / {3}", token.URL.ToUpper(), url.ToUpper(), token.CREDENCIAL.ToUpper(), credencial.ToUpper());

                }
                else
                    retorno = String.Format("Acesso negado: Url{0} - Credencial: {1} - Token: {2}", url.ToUpper(), credencial.ToUpper(), tokenaccess);
            }
            catch (Exception)
            {

            }

            return retorno;
        }

        // POST api/values
        [HttpGet]
        [Route("GetTokenSecurity/")]
        public String GetTokenSecurity(String key)
        {
            
            CultureInfo MyCultureInfo = new CultureInfo("en-US");
            String keyret = String.Empty;

            String messageret = String.Empty;
            String[] message;
            String sistemaorigem = String.Empty;
            String url = String.Empty;
            String GroupProperty = String.Empty;
            TOKEN token = null;
            TOKEN_BL tokenbl = null;
            List<RETORNO> retornos = null;
            String Step = String.Empty;
            Boolean logstep = false;
            String debugfilename = String.Empty;

            try
            {
                IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

                if(!String.IsNullOrEmpty(configuration["debug"].ToString()))
                {
                    logstep = configuration["debug"].ToString().ToUpper() == "ON";
                    debugfilename = Path.Combine(Directory.GetCurrentDirectory(), "tokensecurity.debug.log");
                }

                if (logstep)
                    Util.SaveLog(debugfilename, "Iniciando GetTokenSecurity", ref retornos);

                tokenbl = new TOKEN_BL();

                Step = "GetDecryptMessage()";
                messageret = TokenKey.GetDecryptMessage(key);
                if (logstep)
                {
                    Util.SaveLog(debugfilename, String.Format("key: {0}", key), ref retornos);
                    Util.SaveLog(debugfilename, String.Format("GetDecryptMessage(key): {0}", messageret), ref retornos);
                }

                message = messageret.Split("|");

                if (message.Length != 2)
                    return "";

                sistemaorigem = message[0];
                url = message[1];

                Step = "GroupProperty()";
                GroupProperty = sistemaorigem.ToUpper();
                if (logstep)
                {
                    Util.SaveLog(debugfilename, String.Format("GroupProperty: {0}", GroupProperty), ref retornos);
                }
                if (Util.BuscarValorPropriedade(GroupProperty, "ConnectionString") == String.Empty)
                    return "";

                token = new TOKEN();
                token.KEY = Guid.NewGuid().ToString();
                token.NOW = DateTime.Now.ToString(MyCultureInfo);
                token.CREDENCIAL = sistemaorigem;
                token.URL = url;
                if (logstep)
                {
                    Util.SaveLog(debugfilename, String.Format("token: {0}", token.ToString()), ref retornos);
                }

                retornos = new List<RETORNO>();

                Step = "Insert()";
                if (logstep)
                {
                    Util.SaveLog(debugfilename, "Insert()", ref retornos);
                }
                tokenbl.Insert(token, ref retornos);

                if (retornos != null && retornos.Count > 0)
                {
                    if (logstep)
                    {
                        Util.SaveLog(debugfilename, "retornos != null && retornos.Count > 0", ref retornos);
                    }
                    foreach (RETORNO retorno in retornos)
                    {
                        if (logstep)
                        {
                            Util.SaveLog(debugfilename, String.Format("Retorno: {0}", retorno.mensagem), ref retornos);
                        }
                        keyret += retorno.mensagem + "\n";
                    }
                }
                else
                {
                    if (logstep)
                    {
                        Util.SaveLog(debugfilename, String.Format("Token: ", token.KEY), ref retornos);
                    }
                    keyret = token.KEY;
                }
            }
            catch (Exception ex)
            {
                if (logstep)
                {
                    Util.SaveLog(debugfilename, String.Format("Error: {0}", ex.Message), ref retornos);
                    Util.SaveLog(debugfilename, String.Format("Trace: {0}", ex.StackTrace.ToString()), ref retornos);
                }

                keyret = "Step: " + Step + " - Error: " + ex.Message ;
            }

            return keyret;
        }
    }
}
