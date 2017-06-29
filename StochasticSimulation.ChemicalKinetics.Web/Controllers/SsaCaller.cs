using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StochasticSimulation.ChemicalKinetics.Web.Models;

namespace StochasticSimulation.ChemicalKinetics.Web.Controllers
{
    public class SsaCaller
    {
        private static readonly HttpClient _client = new HttpClient();

        static SsaCaller()
        {
            _client.BaseAddress = new Uri("https://crypto-monolith-156009.appspot.com");
            _client.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<string> Run(SimulationModel model)
        {
            var simulation = new Simulation()
            {
                timeLimit = model.TimeLimit,
                steps = model.NumPoints,
                reactions = new List<Reaction>()
                {
                    new Reaction() {equation = "2A->0", rate = 0.001},
                    new Reaction() {equation = "A + B ->0", rate = 0.01},
                    new Reaction() {equation = "0->A", rate = 1.2},
                    new Reaction() {equation = "0->B", rate = 1.0}
                },
                initialPopulations = new List<InitialPopulation>()
                {
                    new InitialPopulation() {species = "A", count = 0},
                    new InitialPopulation() {species = "B", count = 0}
                }
            };

            var jsonSimulation = JsonConvert.SerializeObject(simulation);

            var response = await _client
                .PostAsync("ssa/gillespie", new StringContent(jsonSimulation, Encoding.UTF8, "application/json"))
                .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new NotImplementedException();
            }

            return await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
        }
    }
}