using System;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SHL.IPropriedade.Model;

namespace SHL.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class PropertyReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="propriedade"></param>
        /// <returns></returns>
        public static String GetProperty(String grupo, String propriedade)
        {
            String retorno = "";

            JToken jsoncontent = String.Empty;
            JObject jobject = null;

            List<GRUPO> grupospropridades = null;
            GRUPO grupopropridade = null;

            try
            {
                jobject = JObject.Parse(File.ReadAllText(@"appsettings.json"));
                jsoncontent = jobject.GetValue("Grupo");

                grupospropridades = JsonConvert.DeserializeObject<List<GRUPO>>(jsoncontent.ToString());

                if (grupospropridades.Count > 0)
                {
                    grupopropridade = GetGrupoPropriedade(grupospropridades, grupo);

                    if (grupopropridade != null)
                    {
                        retorno = GetPropriedade(grupopropridade, propriedade);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupospropridades"></param>
        /// <param name="gruponome"></param>
        /// <returns></returns>
        private static GRUPO GetGrupoPropriedade(List<GRUPO> grupospropridades, String gruponome)
        {
            GRUPO grupopropridade = null;

            foreach (GRUPO grupo in grupospropridades)
            {
                if (grupo.Nome.ToUpper() == gruponome.ToUpper())
                {
                    grupopropridade = grupo;
                    break;
                }
            }

            return grupopropridade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupopropriedades"></param>
        /// <param name="nomepropridade"></param>
        /// <returns></returns>
        private static String GetPropriedade(GRUPO grupopropriedades, String nomepropridade)
        {
            String retorno = String.Empty;

            foreach (PROPRIEDADE propriedade in grupopropriedades.Propriedades)
            {
                if (propriedade.Nome.ToUpper() == nomepropridade.ToUpper())
                {
                    retorno = propriedade.Valor;
                    break;
                }
            }

            return retorno;
        }
    }
}
