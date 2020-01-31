using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Handsoft.Prizes.App.Models
{
    public class OkTestPlainResult : ContentResult
    {
        public OkTestPlainResult(string content) : base()
        {
            ContentType = "text/plain";
            StatusCode = (int)HttpStatusCode.OK;
            Content = content;
        }
    }

    public class TrackerCallbackDto
    {
        public long Origen { get; set; }
        public string Telco { get; set; }
        public int Destino { get; set; }
        public string Mensaje { get; set; }
        public int IdServicio { get; set; }
    }
}