using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpPizza.Api.Errors
{
    public class CodeErrorResponse
    {
        [JsonProperty(PropertyName = "statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string[]? Message { get; set; }


        public CodeErrorResponse(int statusCode, string[]? message = null)
        {
            StatusCode = statusCode;
            if(message is null)
            {
                Message = new string[0];
                var text = GetDefaultMessageStatusCode(statusCode);
                Message[0] = text;
            }else{
                Message = message;
            }


        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Request enviado tiene errores",
                401 => "No tienes authorization para este recurso",
                404 => "No se encontro el recurso solicitado",
                500 => "Se produjeron errores en el servidor",
                _ => string.Empty
            };

        }
    }
}