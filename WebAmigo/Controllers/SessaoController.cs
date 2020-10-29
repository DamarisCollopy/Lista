using System.Threading.Tasks;
using ListaAmigosClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAmigo.Controllers
{
    public class SessaoController : Controller
    {
        private readonly IGerenciamentoCookie gCookie;

        public SessaoController(IGerenciamentoCookie gCookie)
        {
            this.gCookie = gCookie;
        }

        // GET: SessaoController
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,Nome,Sobrenome,Email,DataNascimento")] Table table)
        {
            if (ModelState.IsValid)
            {
                gCookie.Create(" Nome", "Sobrenome" , "Email ", "data");
                //string data = table.DataNascimento.ToString("dd/MM/yyyy HH:mm:ss");
                //CookieOptions option = new CookieOptions();
                //option.Expires = DateTime.Now.AddMinutes(10);
                //Response.Cookies.Append("nome", table.Nome, option);
                //Response.Cookies.Append("Sobrenome", table.Sobrenome, option);
                //Response.Cookies.Append("email", table.Email, option);
                //Response.Cookies.Append("data", data, option);

                return RedirectToAction("SalvarInformacao");

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SalvarInformacao()
        {
            string nome = Request.Cookies["Nome"];
            string sobrenome = Request.Cookies["sobrenome"];
            string email = Request.Cookies["Email"];
            if (nome == null)
            {
                ViewBag.Dados = "No cookie found";
            }
            else
            {

                ViewData["Message"] = new Table()
                {
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Email = email,
                   
                };

                return View();
            }
            return View(); 
        }

        public IActionResult RemoveCookie()
        {
            //Delete the cookie
            Response.Cookies.Delete("UserName");
            return View("Index");
        }

        // GET: SessaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: SessaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SessaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SessaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SessaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
