using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_BlackJack.Results
{
    public class ResultadoBase
    {
        public string Error { set; get; }
        public int CodigoEstado { set; get; }
        public  bool Ok { set; get; }

        public void setOk()
        {
            this.Ok = true;
            this.CodigoEstado = 200;
            this.Error = "No hay ningun error";
        }

        public void setError(string error)
        {
            this.Ok = false;
            this.Error = error;
            this.CodigoEstado = 400;
        }
    }
}
