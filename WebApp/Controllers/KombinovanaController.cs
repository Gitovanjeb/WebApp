using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApp.Models;

public class KombinovanaController : ApiController
{
    // GET api/search
    public IHttpActionResult Get(string naziv, string grad, int minCena , int maxCena)
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

