using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjProyectoAsistencia.Common
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]

        public int IdSubject { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Room { get; set; }

    }
}
