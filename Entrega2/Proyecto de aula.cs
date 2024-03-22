using Entrega2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entrega2
{


    public class Program
    {

        static List<Cliente> clientes = new List<Cliente>();


        static int costoEnergia = 850;
        static int costoAgua = 4600;
        static int costoExcesoAgua = 9200;

        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Ingresar nuevo cliente");
                Console.WriteLine("2. Calcular valor a pagar por servicios de energía y agua para un cliente");
                Console.WriteLine("3. Calcular promedio del consumo actual de energía");
                Console.WriteLine("4. Calcular valor total de descuentos por incentivo de energía");
                Console.WriteLine("5. Mostrar cantidad total de mt3 de agua consumidos por encima del promedio");
                Console.WriteLine("6. Mostrar porcentajes de consumo excesivo de agua por estrato");
                Console.WriteLine("7. Contabilizar clientes con consumo de agua mayor al promedio");
                Console.WriteLine("8. Actualizar informacion del cliente");
                Console.WriteLine("9. Elimiar la informacion del cliente");
                Console.WriteLine("10. Cliente que tuvo la mayor diferencia del consumo de enrgia con respecto a la meta de ahorro");
                Console.WriteLine("11. Estrato con mayor cantidad de ahorro en el agua");
                Console.WriteLine("12. Estrato con mayor y menor consumo de energia");
                Console.WriteLine("13. Valor total que deben pagar los clientes a la empresa por concepto de energia y de agua");
                Console.WriteLine("14. Salir");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        IngresarNuevoCliente();
                        break;

                    case "2":
                        CalcularValorAPagar();
                        break;

                    case "3":
                        CalcularPromedioConsumoEnergia();
                        break;

                    case "4":
                        CalcularValorTotalDescuentos();
                        break;

                    case "5":
                        MostrarCantidadTotalAguaEncimaPromedio();
                        break;

                    case "6":
                        MostrarPorcentajeConsumoExcesivoAguaPorEstrato();
                        break;

                    case "7":
                        ContabilizarClientesConConsumoAguaMayorPromedio();
                        break;

                    case "8":
                        EditarInformacionCliente();
                        break;

                    case "9":
                        EliminarCliente();
                        break;

                    case "10":
                        MayorDiferenciadeConsumoEnergia();
                        break;

                    case "11":
                        AhorroMayorCantidadAgua();
                        break;

                    case "12":
                        EstratoMayorMenorConsumoEnergia();
                        break;

                    case "13":
                        MostrarValorTotalAPagar();
                        break;

                    case "14":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public static void IngresarNuevoCliente()
        {
            Cliente nuevoCliente = new Cliente();

            Console.WriteLine("Ingrese la cédula del cliente:");
            nuevoCliente.Cedula = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el estrato del cliente:");
            nuevoCliente.Estrato = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la meta de ahorro de energía del cliente:");
            nuevoCliente.MetaAhorroEnergia = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el consumo actual de energía del cliente:");
            nuevoCliente.ConsumoActualEnergia = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el promedio de consumo de agua del cliente:");
            nuevoCliente.PromedioConsumoDeAgua = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el consumo actual de agua del cliente:");
            nuevoCliente.ConsumoActualDeAgua = int.Parse(Console.ReadLine());

            clientes.Add(nuevoCliente);

            Console.WriteLine("Cliente ingresado correctamente.");
        }
        public static void EditarInformacionCliente()
        {


            Console.WriteLine("Ingrese la cedula de la persona a la cual quiere modificar su informacion");
            int cedula = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.FirstOrDefault(c => c.Cedula == cedula);
            if (cliente == null)
            {
                Console.WriteLine("Ingrese el nuevo estrato del cliente:");
                cliente.Estrato = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la nueva meta de ahorro de energía del cliente:");
                cliente.MetaAhorroEnergia = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo consumo actual de energía del cliente:");
                cliente.ConsumoActualEnergia = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo promedio de consumo de agua del cliente:");
                cliente.PromedioConsumoDeAgua = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo consumo actual de agua del cliente:");
                cliente.ConsumoActualDeAgua = int.Parse(Console.ReadLine());

                Console.WriteLine("Información del cliente actualizada correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado. Verifique la cédula ingresada.");

            }




        }
        public static void EliminarCliente()
        {
            Console.WriteLine("Ingrese la cedula de la persona a la cual quiere modificar su informacion");
            int cedula = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.FirstOrDefault(c => c.Cedula == cedula);
            if (cliente == null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("El cliente ha sido eliminado correctamente");
            }
            else
            {
                Console.WriteLine("El cliente no ha sido encontrado");
            }

        }


        public static void CalcularValorAPagar()
        {
            Console.WriteLine("Ingrese la cédula del cliente:");
            int cedula = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.FirstOrDefault(c => c.Cedula == cedula);
            if (cliente != null)
            {
                double valorEnergia = cliente.ConsumoActualEnergia * costoEnergia;
                double valorTotalEnergia = valorEnergia - CalcularDescuentoEnergia(cliente);

                double valorTotalAgua = CalcularValorAgua(cliente);

                double valorTotal = valorTotalEnergia + valorTotalAgua;

                Console.WriteLine($"Valor a pagar por servicios de energía y agua: {valorTotal}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado. Verifique la cédula ingresada.");
            }
        }

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

        public static void CalcularPromedioConsumoEnergia()
        {
            double sumaEnergia = clientes.Sum(c => c.ConsumoActualEnergia);
            double promedioEnergia = sumaEnergia / clientes.Count;
            Console.WriteLine($"Promedio del consumo actual de energía: {promedioEnergia}");
        }

        static void CalcularValorTotalDescuentos()
        {
            double totalDescuentos = clientes.Sum(CalcularDescuentoEnergia);
            Console.WriteLine($"Valor total de descuentos por incentivo de energía: {totalDescuentos}");
        }

        public static void MostrarCantidadTotalAguaEncimaPromedio()
        {
            int totalAguaExcedente = clientes.Where(c => c.ConsumoActualDeAgua > c.PromedioConsumoDeAgua).Sum(c => c.ConsumoActualDeAgua - c.PromedioConsumoDeAgua);
            Console.WriteLine($"Cantidad total de mt3 de agua consumidos por encima del promedio: {totalAguaExcedente}");
        }

        public static void MostrarPorcentajeConsumoExcesivoAguaPorEstrato()
        {
            var gruposPorEstrato = clientes.GroupBy(c => c.Estrato);
            foreach (var grupo in gruposPorEstrato)
            {
                int totalClientes = grupo.Count();
                int clientesConExceso = grupo.Count(c => c.ConsumoActualDeAgua > c.PromedioConsumoDeAgua);
                double porcentaje = (double)clientesConExceso / totalClientes * 100;
                Console.WriteLine($"Porcentaje de consumo excesivo de agua para estrato {grupo.Key}: {porcentaje}%");
            }
        }
        public static void ContabilizarClientesConConsumoAguaMayorPromedio()
        {
            int clientesConExceso = clientes.Count(c => c.ConsumoActualDeAgua > c.PromedioConsumoDeAgua);
            Console.WriteLine($"Cantidad de clientes con consumo de agua mayor al promedio: {clientesConExceso}");
        }

        public static void MayorDiferenciadeConsumoEnergia()
        {
            Cliente clienteMayorDesfase = clientes.OrderByDescending(c => Math.Abs(c.MetaAhorroEnergia - c.ConsumoActualEnergia)).FirstOrDefault();
            if (clienteMayorDesfase != null)
            {
                Console.WriteLine($"Datos del cliente con mayor desfase entre consumo de energía y meta de ahorro:");
                Console.WriteLine($"Cédula: {clienteMayorDesfase.Cedula}");
                Console.WriteLine($"Estrato: {clienteMayorDesfase.Estrato}");
                Console.WriteLine($"Meta de ahorro de energía: {clienteMayorDesfase.MetaAhorroEnergia}");
                Console.WriteLine($"Consumo actual de energía: {clienteMayorDesfase.ConsumoActualEnergia}");
                Console.WriteLine($"Promedio de consumo de agua: {clienteMayorDesfase.PromedioConsumoDeAgua}");
                Console.WriteLine($"Consumo actual de agua: {clienteMayorDesfase.ConsumoActualDeAgua}");
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.");
            }
        }

        public static void AhorroMayorCantidadAgua()
        {
            var clienteMayorGastoDeAguaEstrato = clientes.GroupBy(c => c.Estrato).OrderByDescending(grupo => grupo.Sum(c => c.PromedioConsumoDeAgua - c.ConsumoActualDeAgua)).FirstOrDefault();
            if (clienteMayorGastoDeAguaEstrato != null)
            {
                Console.WriteLine($"El estrato con mayor ahorro de agua es el {clienteMayorGastoDeAguaEstrato.Key}.");
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.");
            }
        }

        public static void EstratoMayorMenorConsumoEnergia()
        {
            var estratoMayorConsumoEnergia = clientes.GroupBy(c => c.Estrato).OrderByDescending(grupo => grupo.Sum(c => c.ConsumoActualEnergia)).FirstOrDefault();

            var estratoMenorConsumoEnergia = clientes.GroupBy(c => c.Estrato).OrderBy(grupo => grupo.Sum(c => c.ConsumoActualEnergia)).FirstOrDefault();

            if (estratoMayorConsumoEnergia != null)
            {
                Console.WriteLine($"El estrato con mayor consumo de energía es el {estratoMayorConsumoEnergia.Key}.");
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.");
            }

            if (estratoMenorConsumoEnergia != null)
            {
                Console.WriteLine($"El estrato con menor consumo de energía es el {estratoMenorConsumoEnergia.Key}.");
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.");
            }
        }

        public static void MostrarValorTotalAPagar()
        {
            double totalAPagar = 0;

            foreach (var cliente in clientes)
            {
                double valorEnergia = cliente.ConsumoActualEnergia * costoEnergia;
                double valorAgua = CalcularValorAgua(cliente);

                double valorTotal = valorEnergia + valorAgua;

                totalAPagar += valorTotal;
            }

            Console.WriteLine($"El valor total que los clientes le pagan a la empresa por concepto de energía y agua es: {totalAPagar}");
        }
    }
}