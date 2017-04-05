using System;

namespace MapeamentoOR
{
    public class Troco
    {
        virtual public int Id { get; set; }

        virtual public double ValorTotal { get; set; }

        virtual public double ValorRecebido { get; set; }

        virtual public double ValorPago { get; set; }

        virtual public string Notas { get; set; }

    }
}
