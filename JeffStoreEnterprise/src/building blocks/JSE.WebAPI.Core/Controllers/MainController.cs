using FluentValidation.Results;
using JSE.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JSE.WebAPI.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

                protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
            {
                foreach (var mensagem in resposta.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in erros)
            {
                AddProcessingError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddProcessingError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool ValidOperation()
        {
            return !Errors.Any();
        }

        protected void AddProcessingError(string erro)
        {
            Errors.Add(erro);
        }

        protected void ClearProcessingErrors()
        {
            Errors.Clear();
        }
    }
}