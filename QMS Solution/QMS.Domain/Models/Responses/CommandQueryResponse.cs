using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Domain.Models.Responses
{
    public class CommandQueryResponse : ICommandQueryResponse
    {
        public CommandQueryResponse(string message, bool? success)
        {
            this.Message = message;
            this.Success = success;
        }
        public string Message { get; set; }
        public bool? Success { get; set; }
    }
}
