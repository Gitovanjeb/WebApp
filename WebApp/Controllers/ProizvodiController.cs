using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProizvodiController : ApiController
    {
        [HttpGet]
        public List<Proizvod> Get()
        {
            return Baza.proizvodi.Values.ToList();
        }
        [HttpGet]
        [Route("api/Proizvodi/pretraga")]

        public IHttpActionResult pretraga(string naziv, string grad, int minCena, int maxCena)
        {
            // Perform search logic using the provided parameters
            List<Proizvod> rezultatiPretrage = TraziProizvod(naziv, grad, minCena, maxCena);

            return Ok(rezultatiPretrage);
        }

        // Example method to simulate product search
        private List<Proizvod> TraziProizvod(string naziv, string grad, int minCena, int maxCena)
        {
            // Perform actual search logic here
            // This is just a sample implementation
            List<Proizvod> proizvodi = Baza.proizvodi.Values.ToList();

            var results = proizvodi
                .Where(p => p.Ime.Contains(naziv)
                            && (string.IsNullOrEmpty(grad) || p.Grad.Equals(grad, StringComparison.OrdinalIgnoreCase))
                            && p.Cena >= minCena
                            && p.Cena <= maxCena)
                .ToList();

            return results;
        }
    }
}
