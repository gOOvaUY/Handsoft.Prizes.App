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
}