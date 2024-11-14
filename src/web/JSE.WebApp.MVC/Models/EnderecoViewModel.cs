using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JSE.WebApp.MVC.Models
{
    public class EnderecoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Número")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Estado { get; set; }

        public override string ToString()
        {
            return $"{Logradouro}, {Numero} {Complemento} - {Bairro} - {Cidade} - {Estado}";
        }
    }
}