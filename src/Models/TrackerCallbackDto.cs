using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Handsoft.Prizes.App.Models
{

    public class TrackerCallbackDto
    {
        public long Origen { get; set; }
        public string Telco { get; set; }
        public int Destino { get; set; }
        public string Mensaje { get; set; }
        public int IdServicio { get; set; }
    }
}