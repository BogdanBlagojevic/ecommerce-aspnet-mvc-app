using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.services
{
    public class PerformersService : EntityBaseRepository<Performer>, IPerformersService
    {
       
        public PerformersService(AppDbContext context) :base(context) { }
        

      
    }
}