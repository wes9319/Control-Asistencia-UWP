using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjProyectoAsistencia.Common
{
    public class Hours
    {

        [PrimaryKey, AutoIncrement]

        public int IdHour { get; set; }

        public string NameMaster { get; set; }

        public string LastNameMaster { get; set; }

        public string CompleteNameMaster { get; set; }

        public string UserMaster { get; set; }

        public string Subject { get; set; }

        public TimeSpan Hour { get; set; }

        public TimeSpan EndHour { get; set; }
    }
}
