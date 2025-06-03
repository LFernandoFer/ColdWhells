using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PCLExt.FileStorage.Folders;

namespace AppListView.Services
{
   
    public class DatabaseService
    {      
        public SQLiteConnection conexao;
        public SQLiteConnection GetConexao()
        {
            var folder =
                new LocalRootFolder();
                var file =
                folder.CreateFile("list",
                    PCLExt.FileStorage.
                    CreationCollisionOption.
                    OpenIfExists);
            return
                new SQLiteConnection(file.Path);
        }
    }
}
