using System;

namespace EX_28_1_MVC_CAD_JOGOS.Models
{
    public class JogoViewModel : PadraoViewModel
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataAquisicao { get; set; }
        public int CategoriaID { get; set; }

        public string DescricaoCategoria { get; set; }
    }
}
