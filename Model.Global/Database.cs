using Model.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global
{
    public class Database
    {
        public List<Tache> taches { get; set; }

        public Database()
        {
            taches = new List<Tache>();
            taches.Add(new Tache() { Id = 1, Intitule = "Exemple", Description = "Ceci est une tâche d'exemple", CreationDate = DateTime.Now, IsDone = false, AttributeTo="Nobody" });
        }
    }
}
