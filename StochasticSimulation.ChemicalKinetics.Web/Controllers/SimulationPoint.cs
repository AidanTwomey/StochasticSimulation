namespace StochasticSimulation.ChemicalKinetics.Web.Controllers
{
    public class SimulationPoint
    {
        public double time { get; set; }
        public int a { get; set; }
        public int b { get; set; }

        public override string ToString()
        {
            return $"{time},{a},{b}";
        }
    }
}