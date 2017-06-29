using System.Collections.Generic;

namespace StochasticSimulation.ChemicalKinetics.Web.Controllers
{
    public class Simulation
    {
        public double timeLimit { get; set; }
        public int steps { get; set; }
        public List<Reaction> reactions { get; set; }
        public List<InitialPopulation> initialPopulations { get; set; }
    }
}