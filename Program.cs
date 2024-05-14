using System;
using System.Globalization;

namespace Calculadora
{
    class Program
    {
        static bool trabajarConDecimales = false;

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("¿Desea trabajar con enteros (1), decimales (2), o salir (3)?");
                int tipoNumero = Convert.ToInt32(Console.ReadLine());

                if (tipoNumero == 3)
                    return;

                trabajarConDecimales = tipoNumero == 2;

                bool salir = false;

                do
                {
                    Console.WriteLine("---------------CALCULADORA------------");
                    Console.WriteLine("Introduce el primer número:");
                    double a = LeerNumero();

                    Console.WriteLine("Introduzca el segundo número: ");
                    double b = LeerNumero();

                    Console.WriteLine("Elija una opción:");
                    Console.WriteLine("1- Sumar\n2 - Restar \n3 - Dividir \n4 - Multiplicar\n5 - Cambiar tipo de número\n6 - Salir ");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            suma(a, b);
                            break;
                        case 2:
                            resta(a, b);
                            break;
                        case 3:
                            division(a, b);
                            break;
                        case 4:
                            multiplicacion(a, b);
                            break;
                        case 5:
                            trabajarConDecimales = !trabajarConDecimales;
                            break;
                        case 6:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            Console.ReadLine();
                            break;
                    }

                    if (opcion != 5 && opcion != 6)
                    {
                        Console.WriteLine("Desea continuar: 1=si/0=no");
                        int OP = Convert.ToInt32(Console.ReadLine());
                        if (OP == 0)
                            salir = true;
                    }

                } while (!salir);

            } while (true);
        }

        static double LeerNumero()
        {
            string input = Console.ReadLine();
            if (!trabajarConDecimales)
            {
                if (!EsNumeroEntero(input))
                {
                    Console.WriteLine("Error: Debe ingresar un número entero.");
                    return LeerNumero();
                }
                return Convert.ToInt32(input);
            }
            else
            {
                if (!EsNumeroDecimal(input))
                {
                    Console.WriteLine("Error: Debe ingresar un número decimal.");
                    return LeerNumero();
                }
                return Convert.ToDouble(input, CultureInfo.InvariantCulture);
            }
        }

        private static bool EsNumeroEntero(string input)
        {
            int result;
            return int.TryParse(input, out result);
        }

        private static bool EsNumeroDecimal(string input)
        {
            double result;
            return double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        private static void multiplicacion(double a, double b)
        {
            double result = a * b;
            Console.WriteLine(result);
        }

        private static void division(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("La división es indeterminada");
                return;
            }

            double result = a / b;
            Console.WriteLine(result);
        }

        private static void resta(double a, double b)
        {
            double result = a - b;
            Console.WriteLine(result);
        }

        private static void suma(double a, double b)
        {
            double result = a + b;
            Console.WriteLine(result);
        }
    }
}

