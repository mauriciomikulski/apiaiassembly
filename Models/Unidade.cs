using System;
namespace fdassembly.Models
{
    public class Unidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Locate { get; set; }
        public string LiveCamURL { get; set; }
        public int MaxLimit { get; set; }
        public int MinLimit { get; set; }
        public virtual List<Registros> Registros { get; set; }
    }
}
