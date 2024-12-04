using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SHL.HttpRequest
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseMessageBase<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public ResponseMessageBase()
        {
            Return = (T)Activator.CreateInstance(typeof(T));
        }

        /// <summary>
        /// Lista de retorno da chamada ao serviço de persitência
        /// </summary>
        public T Return { get; set; }


        /// <summary>
        /// Objeto de retorno da execução da requisição receberá sempre System.Net.Http.HttpResponseMessage
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
