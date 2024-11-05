<<<<<<< HEAD
﻿using System.Net;
=======
﻿using JSE.Core.Comunication;
using System.Net;
>>>>>>> develop
using System.Text;
using System.Text.Json;

namespace JSE.Bff.Compras.Services
{
    public abstract class Service
    {
        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest) return false;

            response.EnsureSuccessStatusCode();
            return true;
        }
<<<<<<< HEAD
=======

        protected ResponseResult RetornoOk()
        {
            return new ResponseResult();
        }
>>>>>>> develop
    }
}