using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string enderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string uri = string.Format(enderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(uri);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return endereco;
        }
    }
}
