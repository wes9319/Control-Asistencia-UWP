using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjProyectoAsistencia.Common
{
    public class RelaStudentSubject
    {

        [PrimaryKey, AutoIncrement]

        public int IdRelaAlumSubj { get; set; }

        public string NameStudent { get; set; }

        public string LastNameStudent { get; set; }

        public string UserStudent { get; set; }

        public string CompleteNameStudent { get; set; }

        public string Subject { get; set; }

        public Boolean Atend { get; set; }
    }
}
