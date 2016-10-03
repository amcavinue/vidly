using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MembershipTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public MembershipTypesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/MembershipTypes
        [Authorize(Roles = "CanManageMovies")]
        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }
    }
}
