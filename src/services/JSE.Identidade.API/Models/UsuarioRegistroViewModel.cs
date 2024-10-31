﻿using System.ComponentModel.DataAnnotations;

namespace JSE.Identidade.API.Models
{
    public class UsuarioRegistroViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid GenderId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime BirthdayDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }
    }
}