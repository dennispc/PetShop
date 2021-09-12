using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DPcode.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DPcode.WebApi.Controllers
{
    [Route("[controller]")]
    public class OwnerController : Controller
    {

        private IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService){
            _ownerService=ownerService;
        }

    }
}