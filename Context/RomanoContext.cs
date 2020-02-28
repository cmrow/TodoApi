using System.Collections.Generic;
using System.Linq;

using TodoApi.Models;

namespace TodoApi.Context
{
    public class RomanoContext : IRomanoContext
    {
        private List<Romano> valuesLeters;
        public RomanoContext ()
        {
            valuesLeters = new List<Romano> ();
            valuesLeters.Add (new Romano (1000, "M"));
            valuesLeters.Add (new Romano (900, "CM"));
            valuesLeters.Add (new Romano (500, "D"));
            valuesLeters.Add (new Romano (400, "CD"));
            valuesLeters.Add (new Romano (100, "C"));
            valuesLeters.Add (new Romano (90, "XC"));
            valuesLeters.Add (new Romano (50, "L"));
            valuesLeters.Add (new Romano (40, "XL"));
            valuesLeters.Add (new Romano (10, "X"));
            valuesLeters.Add (new Romano (9, "IX"));
            valuesLeters.Add (new Romano (5, "V"));
            valuesLeters.Add (new Romano (4, "IV"));
            valuesLeters.Add (new Romano (1, "I"));
        }

        public string ToRoman (int num)
        {
            //condición de salida
            if (num < 0 || num > 3999)
            {
                throw new System.ArgumentOutOfRangeException("Debe ingresar un número entre 1 y 3999");
            }
            else if (num < 1)
            {
                return "";
            }
            var romano = valuesLeters.First (x => num >= x.Valor);
            if (romano == null)
            {
                throw new System.IndexOutOfRangeException("No existe el número ingresado");
            }
            return romano.Simbolo + ToRoman (num - romano.Valor);

            /*foreach (var item in valuesLeters)
            {
                if (num >= item.Valor)
                {
                    return item.Simbolo + ToRoman (num - item.Valor);
                }
            }
            return "";*/

        }
    }
}