using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SHL.Propriedades.Model;


namespace SHL.Propriedades
{
    /// <summary>
    /// Property reader.
    /// </summary>
    public static class PropertyReader
    {
        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <returns>The property.</returns>
        /// <param name="grupo">Grupo.</param>
        /// <param name="propriedade">Propriedade.</param>
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
