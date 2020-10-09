using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace testeMOB.Android
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Usu { get; set; }
        [MaxLength(30)]
        public string Senha { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Nome, Email, Usu, Senha);
        }
    }
}
