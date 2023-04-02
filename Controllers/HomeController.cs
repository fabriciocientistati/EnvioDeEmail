using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EnvioDeEmail.Models;
using System.Net.Mail;
using System.Net;

namespace EnvioDeEmail.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult SendContact(ContactViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["message"] = "Informações Inválidas!";
        }

        var emailMessage = new MailMessage();
        emailMessage.Subject = "Contato de " + model.Name;

        emailMessage.From = new MailAddress("fabricio.cientistati@hotmail.com"); //Email para enviar os emails que o usuário inserir
        emailMessage.To.Add(model.Email); //Carrega o email preenchido na tela do usuário
        emailMessage.IsBodyHtml = true;

        emailMessage.Body = "<p>Nome: " + model.Name + "</p><p>E-mail: " + model.Email + "</p>" +
                            "Mensagem: " + model.Message;

        var client = new SmtpClient("smtp-mail.outlook.com", 587);

        client.Credentials = new NetworkCredential("fabricio.cientistati@hotmail.com", "SenhaAqui"); //Credenciais do email que enviara os todos emails
        client.EnableSsl = true;


        try
        {
            client.Send(emailMessage);
        }
        catch (Exception ex)
        {
            ViewData["message"] = "Falha ao enviar mensagem : " + ex.Message;
        }

        return View("SendContact");
    }
}
