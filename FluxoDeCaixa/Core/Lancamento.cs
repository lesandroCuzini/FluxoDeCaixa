using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Core
{
    public class Lancamento
    {
        public int _id { get; private set; }
        public DateTime _data { get; private set; }
        public decimal _valor { get; private set; }
        public string _tipo { get; private set; }

        public Lancamento(DateTime data, decimal valor,
            string tipo)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor do lançamento deve ser maior que (0) zero.");
            }
            if (tipo != "C" && tipo != "D")
            {
                throw new ArgumentException("Tipo do lançamento deve ser C=Crédito ou D=Débito.");
            }

            _data = data;
            _valor = valor;
            _tipo = tipo;
        }
    }
}
