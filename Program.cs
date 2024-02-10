using System;

class Program
{
    static int[] numeroPago = new int[10];
    static DateTime[] fechaHora = new DateTime[10];
    static string[] cedula = new string[10];
    static string[] nombre = new string[10];
    static string[] apellido1 = new string[10];
    static string[] apellido2 = new string[10];
    static int[] numeroCaja = new int[10];
    static int[] tipoServicio = new int[10];
    static int[] numeroFactura = new int[10];
    static float[] montoPagar = new float[10];
    static float[] montoComision = new float[10];
    static float[] montoDeducido = new float[10];
    static float[] montoPagaCliente = new float[10];
    static float[] vuelto = new float[10];

    static int posicionActual = 0;

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Realizar Pagos");
            Console.WriteLine("3. Consultar Pagos");
            Console.WriteLine("4. Modificar Pagos");
            Console.WriteLine("5. Eliminar Pagos");
            Console.WriteLine("6. Submenú Reportes");
            Console.WriteLine("7. Salir");
            Console.Write("Ingrese una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    RealizarPagos();
                    break;
                case 3:
                    ConsultarPagos();
                    break;
                case 4:
                    ModificarPagos();
                    break;
                case 5:
                    EliminarPagos();
                    break;
                case 6:
                    SubmenuReportes();
                    break;
                case 7:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                    break;
            }
        } while (opcion != 7);
    }

    static void InicializarVectores()
    {
        Console.WriteLine("Inicializando Vectores...");
        for (int i = 0; i < 10; i++)
        {
            numeroPago[i] = 0;
            fechaHora[i] = DateTime.MinValue;
            cedula[i] = "";
            nombre[i] = "";
            apellido1[i] = "";
            apellido2[i] = "";
            numeroCaja[i] = 0;
            tipoServicio[i] = 0;
            numeroFactura[i] = 0;
            montoPagar[i] = 0;
            montoComision[i] = 0;
            montoDeducido[i] = 0;
            montoPagaCliente[i] = 0;
            vuelto[i] = 0;
        }
        Console.WriteLine("Vectores inicializados correctamente.");
    }

    static void RealizarPagos()
    {
        if (posicionActual >= 10)
        {
            Console.WriteLine("Vectores Llenos");
            return;
        }

        Console.WriteLine("Realizar Pagos");

        numeroPago[posicionActual] = posicionActual + 1;

        Console.Write("Ingrese la fecha (dd/mm/aaaa): ");
        fechaHora[posicionActual] = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Ingrese la hora (hh:mm): ");
        fechaHora[posicionActual] = fechaHora[posicionActual].Add(TimeSpan.Parse(Console.ReadLine()));

        Console.Write("Ingrese la cédula: ");
        cedula[posicionActual] = Console.ReadLine();

        Console.Write("Ingrese el nombre: ");
        nombre[posicionActual] = Console.ReadLine();

        Console.Write("Ingrese el primer apellido: ");
        apellido1[posicionActual] = Console.ReadLine();

        Console.Write("Ingrese el segundo apellido: ");
        apellido2[posicionActual] = Console.ReadLine();

        Console.Write("Ingrese el número de caja (1-3): ");
        numeroCaja[posicionActual] = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el tipo de servicio (1 = Recibo de Luz, 2 = Recibo Teléfono, 3 = Recibo de Agua): ");
        tipoServicio[posicionActual] = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el número de factura: ");
        numeroFactura[posicionActual] = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el monto a pagar: ");
        montoPagar[posicionActual] = float.Parse(Console.ReadLine());

        // Calcular comisión
        switch (tipoServicio[posicionActual])
        {
            case 1:
                montoComision[posicionActual] = montoPagar[posicionActual] * 0.04f;
                break;
            case 2:
                montoComision[posicionActual] = montoPagar[posicionActual] * 0.055f;
                break;
            case 3:
                montoComision[posicionActual] = montoPagar[posicionActual] * 0.065f;
                break;
            default:
                Console.WriteLine("Tipo de servicio inválido.");
                break;
        }

        // Calcular monto deducido
        montoDeducido[posicionActual] = montoPagar[posicionActual] - montoComision[posicionActual];

        Console.Write("Ingrese el monto que paga el cliente: ");
        montoPagaCliente[posicionActual] = float.Parse(Console.ReadLine());
        if (montoPagaCliente[posicionActual] < montoPagar[posicionActual])
        {
            Console.WriteLine("El monto pagado por el cliente es menor al monto a pagar.");
            return;
        }

        // Calcular vuelto
        vuelto[posicionActual] = montoPagaCliente[posicionActual] - montoPagar[posicionActual];

        Console.WriteLine("Pago registrado correctamente.");
        posicionActual++;
    }

    static void ConsultarPagos()
    {
        Console.WriteLine("Consultar Pagos");
        Console.Write("Ingrese el número de pago que desea consultar: ");
        int numero = int.Parse(Console.ReadLine());
        int indice = Array.IndexOf(numeroPago, numero);
        if (indice != -1)
        {
            Console.WriteLine("Datos del pago:");
            Console.WriteLine($"Número de pago: {numeroPago[indice]}");
            Console.WriteLine($"Fecha y Hora: {fechaHora[indice]}");
            Console.WriteLine($"Cédula: {cedula[indice]}");
            Console.WriteLine($"Nombre: {nombre[indice]}");
            Console.WriteLine($"Apellido1: {apellido1[indice]}");
            Console.WriteLine($"Apellido2: {apellido2[indice]}");
            Console.WriteLine($"Número de Caja: {numeroCaja[indice]}");
            Console.WriteLine($"Tipo de Servicio: {tipoServicio[indice]}");
            Console.WriteLine($"Número de Factura: {numeroFactura[indice]}");
            Console.WriteLine($"Monto a Pagar: {montoPagar[indice]}");
            Console.WriteLine($"Monto Comisión: {montoComision[indice]}");
            Console.WriteLine($"Monto Deducido: {montoDeducido[indice]}");
            Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[indice]}");
            Console.WriteLine($"Vuelto: {vuelto[indice]}");
        }
        else
        {
            Console.WriteLine("Pago no se encuentra registrado.");
        }
    }

    static void ModificarPagos()
    {
        Console.WriteLine("Modificar Pagos");
        Console.Write("Ingrese el número de pago que desea modificar: ");
        int numero = int.Parse(Console.ReadLine());
        int indice = Array.IndexOf(numeroPago, numero);
        if (indice != -1)
        {
            Console.WriteLine("Datos del pago:");
            Console.WriteLine($"Número de pago: {numeroPago[indice]}");
            Console.WriteLine($"Fecha y Hora: {fechaHora[indice]}");
            Console.WriteLine($"Cédula: {cedula[indice]}");
            Console.WriteLine($"Nombre: {nombre[indice]}");
            Console.WriteLine($"Apellido1: {apellido1[indice]}");
            Console.WriteLine($"Apellido2: {apellido2[indice]}");
            Console.WriteLine($"Número de Caja: {numeroCaja[indice]}");
            Console.WriteLine($"Tipo de Servicio: {tipoServicio[indice]}");
            Console.WriteLine($"Número de Factura: {numeroFactura[indice]}");
            Console.WriteLine($"Monto a Pagar: {montoPagar[indice]}");
            Console.WriteLine($"Monto Comisión: {montoComision[indice]}");
            Console.WriteLine($"Monto Deducido: {montoDeducido[indice]}");
            Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[indice]}");
            Console.WriteLine($"Vuelto: {vuelto[indice]}");

            Console.WriteLine("¿Qué dato desea modificar?");
            Console.WriteLine("1. Fecha y Hora");
            Console.WriteLine("2. Cédula");
            Console.WriteLine("3. Nombre");
            Console.WriteLine("4. Apellido1");
            Console.WriteLine("5. Apellido2");
            Console.WriteLine("6. Número de Caja");
            Console.WriteLine("7. Tipo de Servicio");
            Console.WriteLine("8. Número de Factura");
            Console.WriteLine("9. Monto a Pagar");
            Console.WriteLine("10. Monto Paga Cliente");
            Console.WriteLine("Ingrese el número de opción que desea modificar:");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la nueva fecha y hora (dd/mm/aaaa hh:mm): ");
                    fechaHora[indice] = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);
                    break;
                case 2:
                    Console.Write("Ingrese la nueva cédula: ");
                    cedula[indice] = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Ingrese el nuevo nombre: ");
                    nombre[indice] = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Ingrese el nuevo primer apellido: ");
                    apellido1[indice] = Console.ReadLine();
                    break;
                case 5:
                    Console.Write("Ingrese el nuevo segundo apellido: ");
                    apellido2[indice] = Console.ReadLine();
                    break;
                case 6:
                    Console.Write("Ingrese el nuevo número de caja (1-3): ");
                    numeroCaja[indice] = int.Parse(Console.ReadLine());
                    break;
                case 7:
                    Console.Write("Ingrese el nuevo tipo de servicio (1 = Recibo de Luz, 2 = Recibo Teléfono, 3 = Recibo de Agua): ");
                    tipoServicio[indice] = int.Parse(Console.ReadLine());
                    break;
                case 8:
                    Console.Write("Ingrese el nuevo número de factura: ");
                    numeroFactura[indice] = int.Parse(Console.ReadLine());
                    break;
                case 9:
                    Console.Write("Ingrese el nuevo monto a pagar: ");
                    montoPagar[indice] = float.Parse(Console.ReadLine());
                    break;
                case 10:
                    Console.Write("Ingrese el nuevo monto que paga el cliente: ");
                    montoPagaCliente[indice] = float.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Pago no se encuentra registrado.");
        }
    }

    static void EliminarPagos()
    {
        Console.WriteLine("Eliminar Pagos");
        Console.Write("Ingrese el número de pago que desea eliminar: ");
        int numero = int.Parse(Console.ReadLine());
        int indice = Array.IndexOf(numeroPago, numero);
        if (indice != -1)
        {
            Console.WriteLine("Datos del pago a eliminar:");
            Console.WriteLine($"Número de pago: {numeroPago[indice]}");
            Console.WriteLine($"Fecha y Hora: {fechaHora[indice]}");
            Console.WriteLine($"Cédula: {cedula[indice]}");
            Console.WriteLine($"Nombre: {nombre[indice]}");
            Console.WriteLine($"Apellido1: {apellido1[indice]}");
            Console.WriteLine($"Apellido2: {apellido2[indice]}");
            Console.WriteLine($"Número de Caja: {numeroCaja[indice]}");
            Console.WriteLine($"Tipo de Servicio: {tipoServicio[indice]}");
            Console.WriteLine($"Número de Factura: {numeroFactura[indice]}");
            Console.WriteLine($"Monto a Pagar: {montoPagar[indice]}");
            Console.WriteLine($"Monto Comisión: {montoComision[indice]}");
            Console.WriteLine($"Monto Deducido: {montoDeducido[indice]}");
            Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[indice]}");
            Console.WriteLine($"Vuelto: {vuelto[indice]}");

            Console.Write("¿Está seguro de eliminar el dato? (S/N): ");
            string respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "S")
            {
                for (int i = indice; i < posicionActual - 1; i++)
                {
                    numeroPago[i] = numeroPago[i + 1];
                    fechaHora[i] = fechaHora[i + 1];
                    cedula[i] = cedula[i + 1];
                    nombre[i] = nombre[i + 1];
                    apellido1[i] = apellido1[i + 1];
                    apellido2[i] = apellido2[i + 1];
                    numeroCaja[i] = numeroCaja[i + 1];
                    tipoServicio[i] = tipoServicio[i + 1];
                    numeroFactura[i] = numeroFactura[i + 1];
                    montoPagar[i] = montoPagar[i + 1];
                    montoComision[i] = montoComision[i + 1];
                    montoDeducido[i] = montoDeducido[i + 1];
                    montoPagaCliente[i] = montoPagaCliente[i + 1];
                    vuelto[i] = vuelto[i + 1];
                }
                posicionActual--;
                Console.WriteLine("La información fue eliminada.");
            }
            else
            {
                Console.WriteLine("La información no fue eliminada.");
            }
        }
        else
        {
            Console.WriteLine("Pago no se encuentra registrado.");
        }
    }

    static void SubmenuReportes()
    {
        int opcion;
        do
        {
            Console.WriteLine("Submenú Reportes");
            Console.WriteLine("1. Ver todos los Pagos");
            Console.WriteLine("2. Ver Pagos por tipo de Servicio");
            Console.WriteLine("3. Ver Pagos por código de caja");
            Console.WriteLine("4. Ver Dinero Comisionado por servicios");
            Console.WriteLine("5. Regresar Menú Principal");
            Console.Write("Ingrese una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ReporteTodosPagos();
                    break;
                case 2:
                    ReportePagosPorTipoServicio();
                    break;
                case 3:
                    ReportePagosPorCodigoCaja();
                    break;
                case 4:
                    ReporteDineroComisionado();
                    break;
                case 5:
                    Console.WriteLine("Regresando al Menú Principal...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                    break;
            }
        } while (opcion != 5);
    }

    static void ReporteTodosPagos()
    {
        Console.WriteLine("Reporte Todos los Pagos");
        for (int i = 0; i < posicionActual; i++)
        {
            Console.WriteLine($"Número de pago: {numeroPago[i]}");
            Console.WriteLine($"Fecha y Hora: {fechaHora[i]}");
            Console.WriteLine($"Cédula: {cedula[i]}");
            Console.WriteLine($"Nombre: {nombre[i]}");
            Console.WriteLine($"Apellido1: {apellido1[i]}");
            Console.WriteLine($"Apellido2: {apellido2[i]}");
            Console.WriteLine($"Número de Caja: {numeroCaja[i]}");
            Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
            Console.WriteLine($"Número de Factura: {numeroFactura[i]}");
            Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
            Console.WriteLine($"Monto Comisión: {montoComision[i]}");
            Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
            Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
            Console.WriteLine($"Vuelto: {vuelto[i]}");
            Console.WriteLine();
        }
    }

    static void ReportePagosPorTipoServicio()
    {
        Console.WriteLine("Reporte Pagos por Tipo de Servicio");
        Console.Write("Ingrese el tipo de servicio (1 = Recibo de Luz, 2 = Recibo Teléfono, 3 = Recibo de Agua): ");
        int tipo = int.Parse(Console.ReadLine());
        for (int i = 0; i < posicionActual; i++)
        {
            if (tipoServicio[i] == tipo)
            {
                Console.WriteLine($"Número de pago: {numeroPago[i]}");
                Console.WriteLine($"Fecha y Hora: {fechaHora[i]}");
                Console.WriteLine($"Cédula: {cedula[i]}");
                Console.WriteLine($"Nombre: {nombre[i]}");
                Console.WriteLine($"Apellido1: {apellido1[i]}");
                Console.WriteLine($"Apellido2: {apellido2[i]}");
                Console.WriteLine($"Número de Caja: {numeroCaja[i]}");
                Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                Console.WriteLine($"Número de Factura: {numeroFactura[i]}");
                Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                Console.WriteLine($"Monto Comisión: {montoComision[i]}");
                Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
                Console.WriteLine($"Vuelto: {vuelto[i]}");
                Console.WriteLine();
            }
        }
    }

    static void ReportePagosPorCodigoCaja()
    {
        Console.WriteLine("Reporte Pagos por Código de Caja");
        Console.Write("Ingrese el número de caja (1-3): ");
        int caja = int.Parse(Console.ReadLine());
        for (int i = 0; i < posicionActual; i++)
        {
            if (numeroCaja[i] == caja)
            {
                Console.WriteLine($"Número de pago: {numeroPago[i]}");
                Console.WriteLine($"Fecha y Hora: {fechaHora[i]}");
                Console.WriteLine($"Cédula: {cedula[i]}");
                Console.WriteLine($"Nombre: {nombre[i]}");
                Console.WriteLine($"Apellido1: {apellido1[i]}");
                Console.WriteLine($"Apellido2: {apellido2[i]}");
                Console.WriteLine($"Número de Caja: {numeroCaja[i]}");
                Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                Console.WriteLine($"Número de Factura: {numeroFactura[i]}");
                Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                Console.WriteLine($"Monto Comisión: {montoComision[i]}");
                Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
                Console.WriteLine($"Vuelto: {vuelto[i]}");
                Console.WriteLine();
            }
        }
    }

    static void ReporteDineroComisionado()
    {
        Console.WriteLine("Ver Dinero Comisionado por servicios");
        double comisionLuz = 0;
        double comisionTelefono = 0;
        double comisionAgua = 0;
        int contadorLuz = 0;
        int contadorTelefono = 0;
        int contadorAgua = 0;

        for (int i = 0; i < posicionActual; i++)
        {
            switch (tipoServicio[i])
            {
                case 1:
                    comisionLuz += montoComision[i];
                    contadorLuz++;
                    break;
                case 2:
                    comisionTelefono += montoComision[i];
                    contadorTelefono++;
                    break;
                case 3:
                    comisionAgua += montoComision[i];
                    contadorAgua++;
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine($"Dinero comisionado por recibo de Luz: {comisionLuz}, Número de transacciones: {contadorLuz}");
        Console.WriteLine($"Dinero comisionado por recibo de Teléfono: {comisionTelefono}, Número de transacciones: {contadorTelefono}");
        Console.WriteLine($"Dinero comisionado por recibo de Agua: {comisionAgua}, Número de transacciones: {contadorAgua}");
    }
}

