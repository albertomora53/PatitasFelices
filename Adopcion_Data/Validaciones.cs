using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Adopcion_Data
{
    public class ADD
    {
        public bool ValidarRFC(string rfc, bool aceptarGenerico = true)
        {
            if (string.IsNullOrWhiteSpace(rfc))
                return false;

            rfc = rfc.Trim().ToUpper();

            var regex = new Regex(@"^([A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$");
            var match = regex.Match(rfc);

            if (!match.Success)
                return false;

            string digitoVerificador = match.Groups[4].Value;
            string rfcSinDigito = match.Groups[1].Value + match.Groups[2].Value + match.Groups[3].Value;
            int len = rfcSinDigito.Length;

            string diccionario = "0123456789ABCDEFGHIJKLMN&OPQRSTUVWXYZ Ñ";
            int indice = len + 1;
            int suma = (len == 12) ? 0 : 481;

            for (int i = 0; i < len; i++)
            {
                int valor = diccionario.IndexOf(rfcSinDigito[i]);
                suma += valor * (indice - i);
            }

            int residuo = suma % 11;
            string digitoEsperado;

            if (residuo == 0)
                digitoEsperado = "0";
            else if (residuo == 1)
                digitoEsperado = "A";
            else
                digitoEsperado = (11 - residuo).ToString();

            string rfcCompleto = rfcSinDigito + digitoVerificador;

            if (digitoVerificador != digitoEsperado)
            {
                if (!aceptarGenerico || rfcCompleto != "XAXX010101000")
                    return false;
            }

            if (!aceptarGenerico && rfcCompleto == "XEXX010101000")
                return false;

            return true;
        }

        public bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            return telefono.All(char.IsDigit);
        }

    }
}
