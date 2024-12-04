using SHL.HttpRequest;
using SHL.IRetorno.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;
using SHL.TokenSecurity;

namespace SHL.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="message"></param>
        /// <param name="retornos"></param>
        /// <returns></returns>
        public static Boolean SaveLog(String filename, String message, ref List<RETORNO> retornos)
        {
            Boolean ret = false;

            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename, true))
                {
                    outputFile.WriteLine(message);
                }

                ret = true;
            }
            catch (Exception ex)
            {
                RETORNO retorno = new RETORNO();
                retorno.dt_retorno = DateTime.Now;
                retorno.mensagem = ex.Message;
                retorno.status = "-199";
                retorno.transacao = "ALL";
                retorno.trace = ex.Message;
                retornos.Add(retorno);
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="credencial"></param>
        /// <param name="tokensecurity"></param>
        /// <param name="url"></param>
        /// <param name="retornos"></param>
        /// <returns></returns>
        public static Boolean ValidateAccess(String credencial, String tokensecurity, String url, ref List<RETORNO> retornos)
        {
            Boolean bAuthorization = false;
            String key = String.Empty;
            String test = String.Empty;

            try
            {
                key = TokenKey.GetCryptMessage(String.Format("{0}|{1}", credencial, tokensecurity), url);
                test = (String)Util.ControllerSelectEx<String>(Util.BuscarValorPropriedade("URLS", "TokenSecurity"), "TokenSecurity", "GetTestAccess", "key", key);
                bAuthorization = (Boolean)Util.ControllerSelectEx<Boolean>(Util.BuscarValorPropriedade("URLS", "TokenSecurity"), "TokenSecurity", "GetAccess", "key", key);

                if (!bAuthorization)
                {
                    RETORNO retorno = new RETORNO();
                    retorno.dt_retorno = DateTime.Now;
                    retorno.mensagem = "Acesso negado.";
                    retorno.status = "-1001";
                    retorno.transacao = "ALL";
                    retorno.trace = "url: " + url + " - " + test; 
                    retornos.Add(retorno);
                }
                else
                {
                    RETORNO retorno = new RETORNO();
                    retorno.dt_retorno = DateTime.Now;
                    retorno.mensagem = "Acesso liberado.";
                    retorno.status = "0";
                    retorno.transacao = "ALL";
                    retorno.trace = "url: " + url + " - " + test; 
                    retornos.Add(retorno);
                   
                }
            }
            catch (Exception ex)
            {
                RETORNO retorno = new RETORNO();
                retorno.dt_retorno = DateTime.Now;
                retorno.mensagem = "Acesso negado.";
                retorno.status = "-1002";
                retorno.transacao = "ALL";
                retorno.trace = ex.Message;
                retornos.Add(retorno);
            }

            return bAuthorization;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        /// <param name="propriedade"></param>
        /// <returns></returns>
        public static String BuscarValorPropriedade(string group, string propriedade)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessage reponse = new ResponseMessage();
            string strValorPropriedade = string.Empty;
            string url = string.Empty;

            try
            {
                IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

                url = configuration["URL_PROPRIEDADES"];

                if (String.IsNullOrEmpty(url))
                {
                    configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory() + "/../").AddJsonFile("SHL.Shared/sharedappsettings.json").Build();
                    url = configuration["URL_PROPRIEDADES"];
                }

                if (!url.EndsWith("/"))
                    url += "/";

                url += group.Replace("\"", "") + ", " + propriedade;
                request.RequestUrl = url;

                request.RequestUrl = url;

                reponse = SHLHttpRequest.Get(request);

                if (reponse.HttpResponseMessage.IsSuccessStatusCode)
                {
                    strValorPropriedade = reponse.HttpResponseMessage.Content.ReadAsStringAsync().Result.ToString();

                    if (strValorPropriedade.StartsWith("\""))
                        strValorPropriedade = strValorPropriedade.Substring(1, strValorPropriedade.Length - 1);

                    if (strValorPropriedade.EndsWith("\""))
                    {
                        strValorPropriedade = strValorPropriedade.Substring(0, strValorPropriedade.Length - 1);
                    }
                }
            }
            catch (Exception oException)
            {

                throw new Exception(oException.Message);
            }


            return strValorPropriedade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="oObject"></param>
        /// <param name="headears"></param>
        /// <param name="mediaType"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object SendPostT<T>(string url, Object oObject, List<HttpHeaders> headears, String mediaType, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();
            Boolean isimpar = true;
            String httpoperator = "?";

            try
            {
                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += httpoperator + p + "=";
                        httpoperator = "&";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.PostT<T>(request, true, headears, mediaType);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="oObject"></param>
        /// <param name="headers"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object SendPutT<T>(string url, Object oObject, List<HttpHeaders> headers, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();
            Boolean isimpar = true;
            String httpoperator = "?";

            try
            {
                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += httpoperator + p + "=";
                        httpoperator = "&";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.PutT<T>(request, true, headers);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="group"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerSelect<T>(string group, string url, string controller, string metodo, params string[] listparam)
        {
            Object ret = null;
            RequestMessage request = new RequestMessage();
            ResponseMessage response = new ResponseMessage();
            Boolean isimpar = true;

            try
            {
                url += controller + "/" + metodo + "?grupo="+group;
                
                foreach(String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += "&" + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.RequestUrl = url;

                response = SHLHttpRequest.Get(request);

                if (response.HttpResponseMessage.IsSuccessStatusCode)
                {
                    var result = response.HttpResponseMessage.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<T>(result);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="group"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPost<T>(string group, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            Object ret = null;
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();           
            Boolean isimpar = true;

            try
            {
                url += controller + "/" + metodo + "?grupo=" + group;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += "&" + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.RequestUrl = url;
                request.Object = oObject;

                response = SHLHttpRequest.PostT<T>(request, true, null, "application/json");

                if (response.HttpResponseMessage.IsSuccessStatusCode)
                {
                    var result = response.HttpResponseMessage.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<T>(result);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="group"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPut<T>(string group, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            Object ret = null;
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();
            Boolean isimpar = true;

            try
            {
                url += controller + "/" + metodo + "?grupo=" + group;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += "&" + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.RequestUrl = url;
                request.Object = oObject;

                response = SHLHttpRequest.PutT<T>(request, true, null, "application/json");

                if (response.HttpResponseMessage.IsSuccessStatusCode)
                {
                    var result = response.HttpResponseMessage.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<T>(result);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerSelectEx<T>(string url, string controller, string metodo, params string[] listparam)
        {
            Object ret = null;
            RequestMessage request = new RequestMessage();
            ResponseMessage response = new ResponseMessage();
            Boolean isimpar = true;
            String operador = "?";

            try
            {
                url += controller + "/" + metodo;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += operador + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }

                    operador = "&";
                }

                request = new RequestMessage();
                request.RequestUrl = url;

                response = SHLHttpRequest.Get(request);

                if (response.HttpResponseMessage.IsSuccessStatusCode)
                {
                    var result = response.HttpResponseMessage.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<T>(result);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPost(string group, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessage response = new ResponseMessage();
            Boolean isimpar = true;

            try
            {
                url += controller + "/" + metodo + "?grupo=" + group;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += "&" + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.Post(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialize"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPostEx(Boolean serialize, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessage response = new ResponseMessage();
            Boolean isimpar = true;
            String operador = "?";

            try
            {
                url += controller + "/" + metodo;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += operador + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }

                    operador = "&";
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.Post(request, serialize);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="group"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPostT<T>(string group, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();
            Boolean isimpar = true;

            try
            {
                url += controller + "/" + metodo + "?grupo=" + group;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += "&" + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.PostT<T>(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serialize"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPostExT<T>(Boolean serialize, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();
            Boolean isimpar = true;
            String operador = "?";

            try
            {
                url += controller + "/" + metodo;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += operador + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }

                    operador = "&";
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.PostT<T>(request, serialize);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPut(string group, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessage response = new ResponseMessage();
            Boolean isimpar = true;

            try
            {
                url += controller + "/" + metodo + "?grupo=" + group;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += "&" + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.Put(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPutEx(string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessage response = new ResponseMessage();
            Boolean isimpar = true;
            String operador = "?";

            try
            {
                url += controller + "/" + metodo;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += operador + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }

                    operador = "&";
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.Put(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="group"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPutT<T>(string group, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();
            Boolean isimpar = true;

            try
            {
                url += controller + "/" + metodo + "?grupo=" + group;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += "&" + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.PutT<T>(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerPutExT<T>(string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();
            Boolean isimpar = true;
            String operador = "?";

            try
            {
                url += controller + "/" + metodo;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += operador + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }

                    operador = "&";
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.PutT<T>(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerDelete(string group, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessage response = new ResponseMessage();
            Boolean isimpar = true;

            try
            {
                url += controller + "/" + metodo + "?grupo=" + group;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += "&" + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.Delete(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerDeleteEx(string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessage response = new ResponseMessage();
            Boolean isimpar = true;
            String operador = "?";

            try
            {
                url += controller + "/" + metodo;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += operador + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }

                    operador = "&";
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.Delete(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="group"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerDeleteT<T>(string group, string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();
            Boolean isimpar = true;

            try
            {
                url += controller + "/" + metodo + "?grupo=" + group;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += "&" + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.DeleteT<T>(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <param name="metodo"></param>
        /// <param name="oObject"></param>
        /// <param name="listparam"></param>
        /// <returns></returns>
        public static Object ControllerDeleteExT<T>(string url, string controller, string metodo, Object oObject, params string[] listparam)
        {
            RequestMessage request = new RequestMessage();
            ResponseMessageBase<T> response = new ResponseMessageBase<T>();
            Boolean isimpar = true;
            String operador = "?";

            try
            {
                url += controller + "/" + metodo;

                foreach (String p in listparam)
                {
                    if (isimpar)
                    {
                        isimpar = false;
                        url += operador + p + "=";
                    }
                    else
                    {
                        isimpar = true;
                        url += System.Web.HttpUtility.UrlEncode(p);
                    }

                    operador = "&";
                }

                request = new RequestMessage();
                request.Object = oObject;
                request.RequestUrl = url;

                response = SHLHttpRequest.DeleteT<T>(request);

            }
            catch (Exception)
            {

                throw;
            }

            return response.Return;
        }
        
    }
}
