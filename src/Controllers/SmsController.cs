using Handsoft.Prizes.App.Data;
using Handsoft.Prizes.App.Data.Entities;
using Handsoft.Prizes.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Handsoft.Prizes.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly PrizesContext _prizesContext;
        private readonly ILogger<SmsController> _logger;

        public SmsController(PrizesContext prizesContext, ILogger<SmsController> logger)
        {
            _prizesContext = prizesContext;
            _logger = logger;
        }

        [Consumes("application/x-www-form-urlencoded")]
        [ProducesResponseType(200)]
        [Produces("text/plain")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromForm] TrackerCallbackDto trackerCallback)
        {
            try
            {
                var serviceId = trackerCallback.IdServicio;
                var message = trackerCallback.Mensaje;
                var phoneNumber = FormatPhoneNumber(trackerCallback.Origen);
                var telco = trackerCallback.Telco;
                var shortNumber = trackerCallback.Destino.ToString().Trim();

                // Obtener sorteos para el serviceId y numero destino
                var draws = await _prizesContext.Draws
                    .Include(_ => _.Trackerservice)
                    .Where(_ => _.Trackerservice.Tid == serviceId
                        && _.InputNumber == shortNumber
                        && _.Deleted == false
                        && _.Active == true)
                    .ToListAsync();

                // Recorrer y encontrar cual matchea la expresion regular
                for (var i = 0; i < draws.Count; i++)
                {
                    if (!string.IsNullOrEmpty(draws[i].Keyword))
                    {
                        var regex = new Regex(draws[i].Keyword, RegexOptions.IgnoreCase);
                        var matches = regex.IsMatch(message);
                        if (!matches)
                        {
                            continue;
                        }
                    }

                    // Verificar si está activo
                    if (draws[i].EndDate > DateTime.Now && draws[i].StartDate < DateTime.Now)
                    {
                        // Persistir usuario (es necesario usar los generateCode?)
                        var user = new User
                        {
                            DrawId = draws[i].Id,
                            Message = message,
                            Telco = telco.ToUpper(),
                            Time = DateTime.Now,
                            ParticipantId = telco.ToUpper() + "-" + phoneNumber,
                            Cellphone = phoneNumber,
                            RegistrationType = 0
                        };

                        await _prizesContext.Users.AddAsync(user);

                        await _prizesContext.SaveChangesAsync();

                        // Si el mensaje sorteo es null o vacio
                        if (string.IsNullOrWhiteSpace(draws[i].Message))
                        {
                            // Retornar no answer
                            return new OkTestPlainResult("<_NO_ANSWER_>");
                        }
                        else
                        {
                            // Sino retornar mensaje de sorteo
                            return new OkTestPlainResult(draws[i].Message);
                        }
                    }
                    else
                    {
                        // Está inactivo retornar mensaje de inactividad
                        return new OkTestPlainResult(draws[i].InnactiveMessage);
                    }
                }

                // No se encontró sorteo que matchee la expresión regular
                // Retornar mensaje de sorteo incorrecto
                var _help = await _prizesContext.Help.FirstOrDefaultAsync(_ => _.InNumber == shortNumber);
                if (_help != null && !string.IsNullOrWhiteSpace(_help.Message))
                {
                    return new OkTestPlainResult(_help.Message);
                }
                else
                {
                    return new OkTestPlainResult("El mensaje no es valido, verifique la forma de participar e intente nuevamente.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error trying to register user");
                return new OkTestPlainResult("<_NO_ANSWER_>");
            }
        }

        private string FormatPhoneNumber(long origin)
        {
            string phoneNumber = origin.ToString().Trim();

            if (phoneNumber.StartsWith("0"))
            {
                phoneNumber = phoneNumber.StartsWith("0") ?
                    phoneNumber.Remove(0, 1) : phoneNumber;
                return "598" + phoneNumber;
            }
            else if (phoneNumber.StartsWith("9"))
            {
                return "598" + phoneNumber;
            }
            else if (phoneNumber.StartsWith("598"))
            {
                return phoneNumber;
            }
            else
            {
                throw new Exception("El formato en el número de origen es incorrecto");
            }
        }
    }
}