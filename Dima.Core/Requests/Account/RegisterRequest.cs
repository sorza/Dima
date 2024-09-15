﻿using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Account
{
    public class RegisterRequest : Request
    {
        [Required(ErrorMessage ="O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage ="E-mail inválido.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage ="Senha inválida.")]
        public string Password { get; set; } = string.Empty;
    }
}
