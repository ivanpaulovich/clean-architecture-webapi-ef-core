namespace MyWallet.WebApi.Filters {
    using System.Net;
    using MyWallet.Domain;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class DomainExceptionFilter : IExceptionFilter {
        public void OnException (ExceptionContext context) {
            DomainException domainException = context.Exception as DomainException;
            if (domainException != null) {
                string json = JsonConvert.SerializeObject (domainException.Message);

                context.Result = new BadRequestObjectResult (json);
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
    }
}