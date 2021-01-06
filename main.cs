using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] valoresNumericos = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            //Console.WriteLine("Números pares:");

            //IEnumerable<int> numerosPares = from numero in valoresNumericos where numero % 2 == 0 select numero;
            //foreach(int i in numerosPares)
            //{
            //    Console.WriteLine(i);
            //}

            ControlEmpresaEmpleados ad = new ControlEmpresaEmpleados();
            ad.getAnalistDeveloper();
            Console.WriteLine("===================================");
            ad.getEmpleadosOrdenados();
            Console.WriteLine("===================================");
            ad.getEmpleadosMayorSuedo();
            Console.WriteLine("===================================");
            ad.getEmpleadosMayor10000();
            Console.WriteLine("===================================");
            ad.getAnalistDeveloperfromEmpresaGoogle();
            Console.WriteLine("===================================");
            Console.WriteLine("Ingrese el número de empresa:");
            string entrada = Console.ReadLine();
                try
                {
                    int entradaID = Convert.ToInt32(entrada);
                    if (entradaID == 1) ad.getAnalistDeveloperfromEmpresa(entradaID);
                    else if (entradaID == 2) ad.getAnalistDeveloperfromEmpresa(entradaID);
                    else Console.WriteLine("Debes introducir el código 1 o 2");

                }
                catch (Exception)
                {
                    Console.WriteLine("Has ingreso un código que no corresponde, ingrese 1 0 2");
                }
            }

        
    }


    class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public void DatosEmpresa()
        {
            Console.WriteLine("Empresa {0} con Id: {1}", Nombre, Id);
        }
    }
    class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public decimal Sueldo { get; set; }
        public int EmpresaId { get; set; }//clave foranea


        public void DatosEmpleado()
        {
            Console.WriteLine("Empleado {0} con Id {1}, cargo {2} con salario {3} y perteneciente a empresa {4}", Nombre, Id, Cargo, Sueldo, EmpresaId);
        }
    }

    class ControlEmpresaEmpleados
    {
        public ControlEmpresaEmpleados()
        {
            listaEmpresas = new List<Empresa>();
            listaEmpleados = new List<Empleado>();

            listaEmpresas.Add(new Empresa { Id = 1, Nombre = "Google" });
            listaEmpresas.Add(new Empresa { Id = 2, Nombre = "Píldoras Informáticas" });
            listaEmpleados.Add(new Empleado { Id = 1, Nombre = "Oscar Osambela", Cargo = "Analista Programador", Sueldo = 4000, EmpresaId = 1 });
            listaEmpleados.Add(new Empleado { Id = 2, Nombre = "Juan Díaz", Cargo = "CEO", Sueldo = 14000, EmpresaId = 2 });
            listaEmpleados.Add(new Empleado { Id = 3, Nombre = "Jose Becerra", Cargo = "Analista Programador", Sueldo = 4000, EmpresaId = 1 });
            listaEmpleados.Add(new Empleado { Id = 4, Nombre = "Francisco Martínez", Cargo = "Team Leader Project", Sueldo = 4500, EmpresaId = 2 });

        }
        //metodos para obtener resultados de la lista
        public void getAnalistDeveloper()
        {
            IEnumerable<Empleado> analistaDeveloper = from e in listaEmpleados where e.Cargo == "Analista Programador" select e;
            foreach(Empleado empleado in analistaDeveloper)
            {
                empleado.DatosEmpleado();
            }
        }

        public void getEmpleadosOrdenados()
        {
            IEnumerable<Empleado> analistaDeveloper = from e in listaEmpleados orderby e.Nombre select e;
            foreach (Empleado empleado in analistaDeveloper)
            {
                empleado.DatosEmpleado();
            }
        }

        public void getEmpleadosMayorSuedo()
        {
            IEnumerable<Empleado> analistaDeveloper = from e in listaEmpleados orderby e.Sueldo descending select e;
            foreach (Empleado empleado in analistaDeveloper)
            {
                empleado.DatosEmpleado();
            }
        }

        public void getEmpleadosMayor10000()
        {
            IEnumerable<Empleado> analistaDeveloper = from e in listaEmpleados where e.Sueldo > 10000 select e;
            foreach (Empleado empleado in analistaDeveloper)
            {
                empleado.DatosEmpleado();
            }
        }

        public void getAnalistDeveloperfromEmpresaGoogle()
        {
            IEnumerable<Empleado> analistaDeveloper = from e in listaEmpleados where e.EmpresaId == 1 select e;
            foreach (Empleado empleado in analistaDeveloper)
            {
                empleado.DatosEmpleado();
            }
        }
        public void getAnalistDeveloperfromEmpresa(int Id)
        {
            IEnumerable<Empleado> analistaDeveloper = from e in listaEmpleados join empresa in listaEmpresas on e.EmpresaId equals empresa.Id where empresa.Id == Id select e;
            foreach (Empleado empleado in analistaDeveloper)
            {
                empleado.DatosEmpleado();
            }
        }
        public List<Empresa> listaEmpresas;
        public List<Empleado> listaEmpleados;
    }

}
