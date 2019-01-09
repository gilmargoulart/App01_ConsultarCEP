using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscarCep.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            // TODO - lógica do programa

            // TODO - Validações


            // TODO - Buscar
            string cep = txtCep.Text.Trim();
            if (IsValidCEP(cep))
            {
                try
                {
                    Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    txtResultado.Text = string.Format("{0}, {1}, {2} - {3}", endereco.logradouro, endereco.bairro, endereco.localidade, endereco.uf);
                }
                catch (Exception e)
                {
                    txtResultado.Text = "ERRO";
                    DisplayAlert("Erro ao consultar CEP", e.Message, "Ok");
                }
            }
            else
            {
                txtResultado.Text = "ERRO";
            }
        }

        private bool IsValidCEP(string cep)
        {
            bool retorno = true;
            string msgErr = "";
            if (cep.Length != 8)
            {
                // ERRO
                msgErr += "CEP inválido. Deve conter 8 dígitos.";
                retorno = false; ;
            }
            int cepNum = 0;
            if (!int.TryParse(cep, out cepNum))
            {
                //ERRO
                if (msgErr.Length > 1)
                {
                    msgErr += "\n";
                }
                msgErr += "CEP inválido. Deve conter apenas números.";
                retorno = false; ;
            }

            if (!retorno)
            {
                DisplayAlert("Erro", msgErr, "Ok");
            }
            return retorno;
        }
    }
}
