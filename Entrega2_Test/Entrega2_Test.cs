using Entrega2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_de_aula
{
    public static class Proyecto_de_aula
    {
        static List<Cliente> clientes = new List<Cliente>();

        static int costoEnergia = 850;
        static int costoAgua = 4600;
        static int costoExcesoAgua = 9200;

        public static int CalcularDescuentoEnergia(Cliente cliente)
        {
            int descuento = cliente.MetaAhorroEnergia - cliente.ConsumoActualEnergia;
            if (descuento > 0)
            {
                return descuento * costoEnergia;
            }
            else
            {
                return 0;
            }
        }

        public static double CalcularValorAgua(Cliente cliente)
        {
            double valorAgua = cliente.ConsumoActualDeAgua * costoAgua;
            double valorExceso = cliente.ConsumoActualDeAgua > cliente.PromedioConsumoDeAgua ?
                (cliente.ConsumoActualDeAgua - cliente.PromedioConsumoDeAgua) * costoExcesoAgua : 0;
            return valorAgua + valorExceso;
        }

        public static double CalcularValorAPagar(int cedula)
        {
            Cliente cliente = clientes.FirstOrDefault(c => c.Cedula == cedula);
            if (cliente != null)
            {
                double valorEnergia = cliente.ConsumoActualEnergia * costoEnergia;
                double valorTotalEnergia = valorEnergia - CalcularDescuentoEnergia(cliente);
                double valorTotalAgua = CalcularValorAgua(cliente);
                return valorTotalEnergia + valorTotalAgua;
            }
            else
            {
                throw new ArgumentException("Cliente no encontrado. Verifique la cédula ingresada.");
            }
        }
    }
}