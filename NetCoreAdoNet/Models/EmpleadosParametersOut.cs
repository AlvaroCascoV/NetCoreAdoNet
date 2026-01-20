using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAdoNet.Models
{
    public class EmpleadosParametersOut
    {
        public List<string> Apellidos { get; set; }
        public int SumaSalarial { get; set; }
        public int MediaSalarial { get; set; }
        public int Personas { get; set; }
        //si inicializamos la lista aqui, no hay empleados cuando count = 0
        //si inicializamos la lista en el repositorio, no hay empleados cuando apellidos = null
        public EmpleadosParametersOut()
        {
            this.Apellidos = new List<string>();
        }
    }
}
