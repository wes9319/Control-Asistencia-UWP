using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjProyectoAsistencia.Common
{
    public class Database
    {
        SQLiteConnection conn;
        public Database()
        {
            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                "ProyectoFinalV2.sqlite");
            //conn = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), 
                path);

            conn.CreateTable<User>();
            conn.CreateTable<Subject>();
            conn.CreateTable<RelaMasterSubject>();
            conn.CreateTable<RelaStudentSubject>();
            conn.CreateTable<Hours>();
            conn.CreateTable<Atendance>();

        }
        public int Register (User user)
        {
            int code = 1;
            try
            {
                conn.Insert(new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    Type = user.Type,
                    Title = user.Title,
                    FirstName = user.FirstName,
                    LastName = user.LastName

                });
            }
            catch (SQLiteException ex)
            {
                code = -1;
            }
            return code;
        }

        public int Login(string user, string password)
        {
            int tipo = 0;
            var queryADM = conn.Table<User>().
                Where(t => t.UserName == user && t.Password == password && t.Type == 0);
            var queryMAES = conn.Table<User>().
                Where(t => t.UserName == user && t.Password == password && t.Type == 1);
            var queryALUM = conn.Table<User>().
                Where(t => t.UserName == user && t.Password == password && t.Type == 2);

            if (queryADM.Count() > 0)
            {
                tipo = 0;
                return tipo;
            }
            else
            {
                if (queryMAES.Count() > 0)
                {
                    tipo = 1;
                    return tipo;
                }
                else
                {
                    if (queryALUM.Count() > 0)
                    {
                        tipo = 2;
                        return tipo;
                    }
                    else
                    {
                        tipo = 3;
                        return tipo;
                    }
                }

            }
                
            
        }
        public SQLiteConnection dbconn()
        {
            return conn;
        }

    }
}

