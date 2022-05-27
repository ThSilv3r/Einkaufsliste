using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Domaine.Aggregate.Interfaces
{
    public interface IRecipe
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        List<Guid> Foods { get; set; }
    }
}
