using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnvioDeEmail.Models;

public class ContactViewModel
{
    [DisplayName("Nome")]
    [Required(ErrorMessage = "Campo Nome obrigatório!")]
    [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres")]
    public string Name { get; set; }


    [DisplayName("E-mail")]
    [Required(ErrorMessage = "Campo E-mail obrigatório!")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }


    [DisplayName("Mensagem")]
    [Required(ErrorMessage = "Campo Mensagem obrigatório!")]
    [MinLength(10, ErrorMessage = "Mensagem deve conter no mínimo 10 caracteres")]
    public string Message { get; set; }
}