using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjProyectoAsistencia.Common
{
    public class Atendance
    {
        [PrimaryKey, AutoIncrement]

        public int IdAtendance { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Subject { get; set; }

        public string FirstNameStudent { get; set; }

        public string LastNameStudent { get; set; }

        public string FistNameMaster { get; set; }

        public string LastNameMaster { get; set; }

        public bool Asist { get; set; }
    }
}
