using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjProyectoAsistencia.Common
{
    public class RelaMasterSubject
    {
        [PrimaryKey, AutoIncrement]

        public int IdRelaMastSubj { get; set; }

        public string NameMaster { get; set; }

        public string LastNameMaster { get; set; }

        public string UserMaster { get; set; }

        public string CompleteName { get; set; }

        public string Subject { get; set; }



    }
}
