using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StochasticSimulation.ChemicalKinetics.Web.Models
{
    public class SimulationModel
    {
        public int NumPaths { get; set; }
        public double TimeLimit { get; set; }
        public int NumPoints { get; set; }
        public string Algorithm { get; set; }

        public string Results { get; set; }
    }
}