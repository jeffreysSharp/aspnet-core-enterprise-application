using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using JSE.WebApp.MVC.Extensions;

namespace JSE.WebApp.MVC.Models
{
    public class UsuarioRegistroViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Nome")]
        public string FirstName {get; set;}
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Sobrenome")]
        public string LastName {get; set;}        

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Apelido")]
        public string Surname {get; set;}        

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Orientação sexual")]
        public string GenderId {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Telefone")]
        public string Phone {get; set;}
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data de Nascimento")]
        public string BirthdayDate {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("CPF")]
        [Cpf]
        public string DocumentNumber { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        [DisplayName("Confirme sua senha")]
        public string SenhaConfirmacao { get; set; }
    }
}
