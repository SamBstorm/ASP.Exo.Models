using System;

namespace Model.Common.Models
{
    public class Tache
    {
        public int Id { get; set; }
        public string Intitule { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string AttributeTo { get; set; }
        public bool IsDone { get; set; }
    }
}
