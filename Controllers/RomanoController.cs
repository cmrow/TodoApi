using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TodoApi.Context;

namespace TodoApi.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class RomanoController : ControllerBase
    {
        private readonly IRomanoContext _romanoContext;

        public RomanoController (IRomanoContext romanoContext)
        {
            _romanoContext = romanoContext;
        }

        [HttpGet ("{numero}")]
        public ActionResult<object> GetRomanos (int numero)
        {
            try
            {
                return Ok (new
                {
                    rom = _romanoContext.ToRoman (numero),
                        dec = numero
                });
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                return StatusCode (406, new Exception(ex.Message));
            }
            catch (System.IndexOutOfRangeException ex)
            {
                return NotFound (new Exception(ex.Message));
            }
        }

    }
}