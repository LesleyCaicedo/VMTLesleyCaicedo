using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Helper
{
    public static class CuentaHelper
    {
        private static readonly Random random = new Random();
        private const string LetrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
        private const string LetrasMayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numeros = "0123456789";

        public static string GenerarContraseña()
        {
            int longitud = random.Next(8, 31); 
            StringBuilder contraseña = new StringBuilder();

            contraseña.Append(LetrasMayusculas[random.Next(LetrasMayusculas.Length)]);
            contraseña.Append(Numeros[random.Next(Numeros.Length)]);

            string todosLosCaracteres = LetrasMinusculas + LetrasMayusculas + Numeros;
            for (int i = 2; i < longitud; i++)
            {
                contraseña.Append(todosLosCaracteres[random.Next(todosLosCaracteres.Length)]);
            }

            return new string(contraseña.ToString().OrderBy(_ => random.Next()).ToArray());
        }
    }
}
