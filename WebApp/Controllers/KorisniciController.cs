using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class KorisniciController
    {
       

        // GET api/profile
        public IHttpActionResult Get()
        {
            Korisnik korisnik = korisnik.GetProfileUser(); // Retrieve the user profile from the database or any other data source
            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT api/profile
        public IHttpActionResult Put(User updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest("Invalid user data.");
            }

            User existingUser = _baza.GetProfileUser(); // Retrieve the user profile from the database or any other data source
            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the user information
            existingUser.Name = updatedUser.Name ?? existingUser.Name;
            existingUser.Surname = updatedUser.Surname ?? existingUser.Surname;
            existingUser.Password = updatedUser.Password ?? existingUser.Password;
            existingUser.Email = updatedUser.Email ?? existingUser.Email;
            existingUser.DateOfBirth = updatedUser.DateOfBirth ?? existingUser.DateOfBirth;

            return Ok(existingUser);
        }
        private List<Korisnik>  GetProfileUser()
        {
            List<Korisnik> profili = Baza.korisnici.Values.ToList(); // Retrieve the list of user profiles from the data source
            if (profili.Count == 0)
            {
                return null;
            }

            return profili[0]; // Return the first user profile from the list
        }
    }
}
