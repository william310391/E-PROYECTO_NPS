namespace AppNet6.Core.Entities
{
    public class Parametro: BaseEntity
    {
        public int IdParametro { get; set; }
        public int IdTipo { get; set; }
        public decimal CampoValor { get; set; }
        public string CampoDescripcion { get; set; }

    }
}
