using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace testeMOB
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Tipo { get; set; }
        [MaxLength(30)]
        public string CDB{ get; set; }
        [MaxLength(30)]
        public string Preco { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Nome, Tipo, CDB, Preco);
        }
    }
}
