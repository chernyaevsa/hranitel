using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System;
using Chernyaev2.Models;
using Microsoft.AspNetCore.Authentication;

namespace Chernyaev2.Pages
{
    public class AuthModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string? returnUrl)
        {
                // �������� �� ����� email � ������
                var form = HttpContext.Request.Form;
                // ���� email �/��� ������ �� �����������, �������� ��������� ��� ������ 400
                if (!form.ContainsKey("login") || !form.ContainsKey("password"))
                    return BadRequest("Email �/��� ������ �� �����������");
                
                string email = form["login"];
                string password = form["password"];

            var db = new MaindbContext();
            // ������� ������������ 
            var staff = db.Staffs.FirstOrDefault(p => p.Login == email && p.Password == password);
                // ���� ������������ �� ������, ���������� ��������� ��� 401
                if (staff is null) return Unauthorized();

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, staff.Login) };
                // ������� ������ ClaimsIdentity
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                // ��������� ������������������ ����
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(returnUrl ?? "/");
            }
    }
}
