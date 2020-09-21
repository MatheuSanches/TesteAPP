using System;
using System.Collections.Generic;
using System.Text;

namespace testeMOB
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }//retorna o caminho do banco de dados SQLite usado na plataforma
        //ISQLitePlatform Plataforma { get; }//retorna a plataforma criada no Config.cs do TesteMOB.Android
    }
}
