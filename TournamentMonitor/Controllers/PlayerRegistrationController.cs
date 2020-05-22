using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentMonitor.Models;
using TournamentMonitor.Models.RegistrationTables;
using TournamentMonitor.ViewModels;
using TournamentMonitor;
using System.Xml.Linq;
using System.Net.Mail;
using System;
using System.Xml;
using System.Net.Http;

namespace TournamentMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerRegistrationContoller : ControllerBase
    {
        private readonly PlayerPortalContext _context;

        public PlayerRegistrationContoller(PlayerPortalContext context)
        {
            _context = context;
            Console.Write("Player Registration Controller Generated");
        }


        // GET: api/PlayerRegistrationContoller - using for general testing
        [HttpGet]
        public async Task<ActionResult<ApiResult<Format>>> GetTester()
        {
            //var league = new League { TPCLeagueId = "2", Active = true, Description = "pls work", LeagueId = 4, Name = "Test League" };
            //_context.Leagues.Add(league);

            //var type = new TournamentType { TournamentTypeID = 4, Name = "Test Type" };
            //_context.TournamentTypes.Add(type);

            //var format2 = new Format { FormatID = 3, Name = "test format 2" };
            //_context.Formats.Add(format2);

            //var eventvar = new Event { EventID = 2, Name = "test event 2" };
            //_context.Events.Add(eventvar);

            //var tournament = new Tournament { TournamentID = 1, TournamentName = "test tournament", EventID = 2 };
            //_context.Tournaments.Add(tournament);

            var country = new Country { CountryID = 1, CountryName = "United Kingdom" };
            _context.Countries.Add(country);

            _context.SaveChangesAsync();
            var result = _context.Formats.FirstOrDefault();
            return new ApiResult<Format> { IsValid = true, Result = result, ErrorMessage = "GetTester" };

        }
        // GET: api/PlayerRegistrationContoller/Tournaments/EventID
        [HttpGet("tournaments/event/{eventid}")]
        public async Task<ActionResult<ApiResult<List<Tournament>>>> GetEventTournaments(int eventid)
        {
            var t = _context.Tournaments.Where(x => x.EventID.Equals(eventid));
            if (t.Count() == 0)
            {
                return new ApiResult<List<Tournament>> { IsValid = false, ErrorMessage = "Specified Event contains 0 Tournaments" };
            }
            return new ApiResult<List<Tournament>> { IsValid = true, Result = t.ToList() };
        }

        // GET: api/PlayerRegistrationContoller/Formats
        [HttpGet("Formats/")]
        public async Task<ActionResult<ApiResult<List<Format>>>> GetFormats()
        {
            var f = _context.Formats.ToList();
            if (f.Count() == 0)
            {
                return new ApiResult<List<Format>> { IsValid = false, ErrorMessage = "No Formats Found" };
            }
            return new ApiResult<List<Format>> { IsValid = true, Result = f };
        }

        // GET: api/PlayerRegistrationContoller/Products
        [HttpGet("Products/")]
        public async Task<ActionResult<ApiResult<List<Product>>>> GetProducts()
        {
            var p = _context.Products.ToList();
            if (p.Count() == 0)
            {
                return new ApiResult<List<Product>> { IsValid = false, ErrorMessage = "No Products Found" };
            }
            return new ApiResult<List<Product>> { IsValid = true, Result = p };
        }

        // GET: api/PlayerRegistrationContoller/Types
        [HttpGet("Types/")]
        public async Task<ActionResult<ApiResult<List<TournamentType>>>> GetTournamentTypes()
        {
            var types = _context.TournamentTypes.ToList();
            if (types.Count() == 0)
            {
                return new ApiResult<List<TournamentType>> { IsValid = false, ErrorMessage = "No Tournament Types Found" };
            }
            return new ApiResult<List<TournamentType>> { IsValid = true, Result = types };
        }

        // GET: api/PlayerRegistrationContoller/Tournaments
        [HttpGet("Tournaments/")]
        public async Task<ActionResult<ApiResult<List<Tournament>>>> GetTournaments()
        {
            var t = _context.Tournaments
                .Include("Format")
                .Include("Product")
                .Include("TournamentType")
                .Include("Event")
                .Include("Organiser")
                .ToList();
            if (t.Count() == 0)
            {
                return new ApiResult<List<Tournament>> { IsValid = false, ErrorMessage = "No Tournaments Found" };
            }
            return new ApiResult<List<Tournament>> { IsValid = true, Result = t };
        }

        // GET: api/PlayerRegistrationContoller/Venues
        [HttpGet("Venues/")]
        public async Task<ActionResult<ApiResult<List<Venue>>>> GetVenues()
        {
            var v = _context.Venues.Include("Country").ToList();
            if (v.Count() == 0)
            {
                return new ApiResult<List<Venue>> { IsValid = false, ErrorMessage = "No Venues Found" };
            }
            return new ApiResult<List<Venue>> { IsValid = true, Result = v };
        }

        // GET: api/PlayerRegistrationContoller/RegisteredPlayers/TournamentID
        [HttpGet("tournaments/registeredplayers/{tournamentid}")]
        public async Task<ActionResult<ApiResult<List<TournamentRegistration>>>> GetRegisteredPlayers(int tournamentid)
        {
            var t = _context.TournamentRegistrations.Where(x => x.TournamentID.Equals(tournamentid));
            if (t.Count() == 0)
            {
                return new ApiResult<List<TournamentRegistration>> { IsValid = false, ErrorMessage = "Specified Tournament contains 0 Players" };
            }
            return new ApiResult<List<TournamentRegistration>> { IsValid = true, Result = t.ToList() };
        }

        // GET: api/PlayerRegistrationContoller/RegisteredPlayers/TournamentID/PID
        [HttpGet("tournaments/registeredplayers/{tournamentid}/{pid}")]
        public async Task<ActionResult<ApiResult<List<TournamentRegistration>>>> GetRegisteredPlayerByPID(int tournamentid, int pid)
        {
            var p = _context.Players
                .Where(x => x.PID.Equals(pid));
            var p2 = p.FirstOrDefault().PlayerID;
            var t = _context.TournamentRegistrations
                .Where(x => x.TournamentID.Equals(tournamentid))
                .Where(x => x.PlayerID.Equals(p2));
            if (t.Count() == 0)
            {
                return new ApiResult<List<TournamentRegistration>> { IsValid = false, ErrorMessage = "Specified Player is not registred for specified Tournament" };
            }
            return new ApiResult<List<TournamentRegistration>> { IsValid = true, Result = t.ToList() };
        }

        // POST: api/NewFormats
        [HttpPost("NewFormats")]
        public async Task<ActionResult<ApiResult<string>>> PostNewFormat(FormatVM p)
        {
            Format f = new Format
            {
                FormatID = p.FormatID,
                Name = p.Name,
            };
            _context.Formats.Add(f);
            _context.SaveChanges();

            return new ApiResult<string> { IsValid = true, Result = "Format '" + f.Name + "' was successfully uploaded!" };
        }

        // Put: api/EditFormat/FormatID
        [HttpPut("EditFormat/{formatid}")]
        public async Task<ActionResult<ApiResult<string>>> PutFormat(long formatid, FormatVM p)
        {
            var f = _context.Formats.Where(x => x.FormatID.Equals(formatid)).FirstOrDefault();

            if (f != null)
            {
                f.Name = p.Name;
                _context.SaveChanges();

                return new ApiResult<string> { IsValid = true, Result = "Format '" + f.Name + "' was successfully updated!" };
            }

            return new ApiResult<string> { IsValid = false, Result = "Format not found" };
        }

        // POST: api/NewProducts
        [HttpPost("NewProducts")]
        public async Task<ActionResult<ApiResult<string>>> PostNewProduct(ProductVM p)
        {
            Product pr = new Product
            {
                ProductID = p.ProductID,
                Name = p.Name,
            };
            _context.Products.Add(pr);
            _context.SaveChanges();

            return new ApiResult<string> { IsValid = true, Result = "Product '" + pr.Name + "' was successfully uploaded!" };
        }

        // Put: api/EditProduct/ProductID
        [HttpPut("EditProduct/{productid}")]
        public async Task<ActionResult<ApiResult<string>>> PutProduct(long productid, ProductVM p)
        {
            var pr = _context.Products.Where(x => x.ProductID.Equals(productid)).FirstOrDefault();

            if (pr != null)
            {
                pr.Name = p.Name;
                pr.ShortName = p.Name;
                _context.SaveChanges();

                return new ApiResult<string> { IsValid = true, Result = "Product '" + pr.Name + "' was successfully updated!" };
            }

            return new ApiResult<string> { IsValid = false, Result = "Product not found" };
        }

        // POST: api/NewTypes
        [HttpPost("NewTypes")]
        public async Task<ActionResult<ApiResult<string>>> PostNewType(TournamentTypeVM p)
        {
            TournamentType t = new TournamentType
            {
                TournamentTypeID = p.TournamentTypeID,
                Name = p.Name,
            };
            _context.TournamentTypes.Add(t);
            _context.SaveChanges();

            return new ApiResult<string> { IsValid = true, Result = "Tournament Type '" + t.Name + "' was successfully uploaded!" };
        }

        // Put: api/EditTournamentType/TournamentTypeID
        [HttpPut("EditTournamentType/{tournamentypeid}")]
        public async Task<ActionResult<ApiResult<string>>> PutType(long tournamenttypeid, FormatVM p)
        {
            var t = _context.Formats.Where(x => x.FormatID.Equals(tournamenttypeid)).FirstOrDefault();

            if (t != null)
            {
                t.Name = p.Name;
                _context.SaveChanges();

                return new ApiResult<string> { IsValid = true, Result = "Tournament Type '" + t.Name + "' was successfully updated!" };
            }

            return new ApiResult<string> { IsValid = false, Result = "Tournament Type not found" };
        }

        // POST: api/NewVenue
        [HttpPost("NewVenues")]
        public async Task<ActionResult<ApiResult<string>>> PostNewVenue(VenueVM p)
        {
            Venue v = new Venue
            {
                VenueID = p.VenueID,
                Country = _context.Countries.Where(x => x.CountryID.Equals(1)).FirstOrDefault(),
                Name = p.Name,
                Address1 = p.Address1,
                Address2 = p.Address2,
                City = p.City,
                County = p.County,
                Postcode = p.Postcode

            };
            _context.Venues.Add(v);
            _context.SaveChanges();

            return new ApiResult<string> { IsValid = true, Result = "Venue '" + v.Name + "' was successfully uploaded!" };
        }

        // Put: api/EditVenue/VenueID
        [HttpPut("EditVenue/{venueid}")]
        public async Task<ActionResult<ApiResult<string>>> PutVenue(long venueid, VenueVM p)
        {
            var v = _context.Venues.Where(x => x.VenueID.Equals(venueid)).FirstOrDefault();

            if (v != null)
            {
                v.Country = p.Country;
                v.Name = p.Name;
                v.Address1 = p.Address1;
                v.Address2 = p.Address2;
                v.City = p.City;
                v.County = p.County;
                v.Postcode = p.Postcode;
                _context.SaveChanges();

                return new ApiResult<string> { IsValid = true, Result = "Venue '" + v.Name + "' was successfully updated!" };
            }

            return new ApiResult<string> { IsValid = false, Result = "Venue not found" };
        }

        // GET: api/PlayerRegistrationContoller/Countries
        [HttpGet("Countries/")]
        public async Task<ActionResult<ApiResult<List<Country>>>> GetCountries()
        {
            var countries = _context.Countries.ToList();
            if (countries.Count() == 0)
            {
                return new ApiResult<List<Country>> { IsValid = false, ErrorMessage = "No Countries Found" };
            }
            return new ApiResult<List<Country>> { IsValid = true, Result = countries };

        }

        // GET: api/PlayerRegistrationContoller/Organisers
        [HttpGet("Organisers/")]
        public async Task<ActionResult<ApiResult<List<Organiser>>>> GetOrganisers()
        {
            var organisers = _context.Organisers.ToList();
            if (organisers.Count() == 0)
            {
                return new ApiResult<List<Organiser>> { IsValid = false, ErrorMessage = "No Organisers Found" };
            }
            return new ApiResult<List<Organiser>> { IsValid = true, Result = organisers };
        }

        // POST: api/NewOrgansiers
        [HttpPost("NewOrgansiers")]
        public async Task<ActionResult<ApiResult<string>>> PostNewOrgansier(OrganiserVM p)
        {
            Organiser o = new Organiser
            {
                OrganiserID = p.OrganiserID,
                Email = p.Email,
                ContactNo = p.ContactNo,
                Website = p.Website,
                Forename = p.Forename,
                Surname = p.Surname

            };
            _context.Organisers.Add(o);
            _context.SaveChanges();

            return new ApiResult<string> { IsValid = true, Result = "Organiser '" + o.Forename + "' was successfully uploaded!" };
        }

        // Put: api/EditTournamentType/TournamentTypeID
        [HttpPut("EditTournamentType/{tournamentypeid}")]
        public async Task<ActionResult<ApiResult<string>>> PutOrganiser(long organiserid, OrganiserVM p)
        {
            var o = _context.Organisers.Where(x => x.OrganiserID.Equals(organiserid)).FirstOrDefault();

            if (o != null)
            {
                o.Email = p.Email;
                o.ContactNo = p.ContactNo;
                o.Website = p.Website;
                o.Forename = p.Forename;
                o.Surname = p.Surname;
                _context.SaveChanges();

                return new ApiResult<string> { IsValid = true, Result = "Organsier '" + o.Forename + "' was successfully updated!" };
            }

            return new ApiResult<string> { IsValid = false, Result = "Organiser not found" };
        }

        // GET: api/PlayerRegistrationContoller/Players
        [HttpGet("Players/")]
        public async Task<ActionResult<ApiResult<List<Player>>>> GetPlayers()
        {
            var players = _context.Players.ToList();
            if (players.Count() == 0)
            {
                return new ApiResult<List<Player>> { IsValid = false, ErrorMessage = "No Players Found" };
            }
            return new ApiResult<List<Player>> { IsValid = true, Result = players };
        }

        // POST: api/NewPlayers
        [HttpPost("NewPlayers")]
        public async Task<ActionResult<ApiResult<string>>> PostNewPlayer(PlayerVM p)
        {
            Player pl = new Player
            {
                PlayerID = p.PlayerID,
                PID = p.PID,
                Password = p.Password,
                Password2 = p.Password2,
                Password3 = p.Password3,
                Forename = p.Forename,
                Surname = p.Surname,
                DOB = p.DOB,
                Email = p.Email

            };
            _context.Players.Add(pl);
            _context.SaveChanges();

            return new ApiResult<string> { IsValid = true, Result = "Player '" + pl.Forename + "' was successfully uploaded!" };
        }

        // Put: api/EditTournamentType/TournamentTypeID
        [HttpPut("EditPlayer/{playerid}")]
        public async Task<ActionResult<ApiResult<string>>> PutPlayer(long playerid, PlayerVM p)
        {
            var pl = _context.Players.Where(x => x.PlayerID.Equals(playerid)).FirstOrDefault();

            if (pl != null)
            {
                pl.PlayerID = p.PlayerID;
                pl.PID = p.PID;
                pl.Password = p.Password;
                pl.Password2 = p.Password2;
                pl.Password3 = p.Password3;
                pl.Forename = p.Forename;
                pl.Surname = p.Surname;
                pl.DOB = p.DOB;
                pl.Email = p.Email;
                _context.SaveChanges();

                return new ApiResult<string> { IsValid = true, Result = "Organsier '" + pl.Forename + "' was successfully updated!" };
            }

            return new ApiResult<string> { IsValid = false, Result = "Organiser not found" };
        }

        // POST: api/NewRegistration
        [HttpPost("NewRegistration")]
        public async Task<ActionResult<ApiResult<string>>> PostNewRegistration(TournamentRegistrationVM p)
        {
            TournamentRegistration r = new TournamentRegistration
            {
                TournamentID = p.TournamentID,
                PlayerID = p.PlayerID,
                PaidAmount = p.PaidAmount,
                Division = p.Division,
             };
            _context.TournamentRegistrations.Add(r);
            _context.SaveChanges();

            return new ApiResult<string> { IsValid = true, Result = "Player '" + r.PlayerID + "' was successfully registered!" };
        }

        //POST: api/NewTournament
       [HttpPost("NewTournament")]
        public async Task<ActionResult<ApiResult<string>>> PostNewTournament(TournamentVM p)
        {
            Tournament t = new Tournament
            {
                TournamentID = p.TournamentID,
                Event = _context.Events.Where(x => x.EventID.Equals(1)).FirstOrDefault(),
                EventID = 2,
                Organiser = _context.Organisers.Where(x => x.OrganiserID.Equals(1)).FirstOrDefault(),
                Venue = _context.Venues.Where(x => x.VenueID.Equals(2)).FirstOrDefault(),
                Product = _context.Products.Where(x => x.ProductID.Equals(1)).FirstOrDefault(),
                TournamentType = _context.TournamentTypes.Where(x => x.TournamentTypeID.Equals(1)).FirstOrDefault(),
                Format = _context.Formats.Where(x => x.FormatID.Equals(1)).FirstOrDefault(),
                TournamentName = p.TournamentName,
                Description = p.Description,
                SanctionID = p.SanctionID,
                RegistrationRequired = p.RegistrationRequired
            };
            _context.Tournaments.Add(t);
            _context.SaveChanges();

            return new ApiResult<string> { IsValid = true, Result = "Tournament '" + t.TournamentName + "' was successfully uploaded!" };
        }

    }
}
    
