using EduHome_BackEndProject_.Data;
using EduHome_BackEndProject_.Models;
using EduHome_BackEndProject_.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var existUser = await _userManager.FindByNameAsync(registerVM.Username);
            if (existUser != null)
            {
                ModelState.AddModelError("Username", "This Username already exist");
                return View();
            }
            var user = new User
            {
                Fullname = registerVM.Fullname,
                UserName = registerVM.Username,
                Email = registerVM.Email
            };
            
            Random random = new Random();
            List<int> oldCodes = new List<int>();
            int verificationCode = random.Next(100000, 1000000);
            while (oldCodes.Contains(verificationCode))
            {
                verificationCode = random.Next(100000, 1000000);
            }
            oldCodes.Add(verificationCode);
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("codep320@gmail.com", "Fiorello");
            msg.To.Add(user.Email);
            msg.Body = $"Please Verify Your EduHome Account!" +
                $"<h2>Your verification code:\"{verificationCode}\"</h2>";
            msg.Subject = "Verify EduHome Account";
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("codep320@gmail.com", "codeacademyp320");
            smtp.Send(msg);
            user.VerificationCode = verificationCode;


            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, RoleConstants.UserRole);
            var cookie = JsonConvert.SerializeObject(user.Id);
            Response.Cookies.Append("user",cookie);
            return RedirectToAction(nameof(Verify));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var existUser = await _userManager.FindByNameAsync(loginVM.Username);
            if (existUser == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
            if (existUser.EmailConfirmed == false)
            {
                ModelState.AddModelError("", "Please Verify Your Account");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(existUser, loginVM.Password, loginVM.RememberMe, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "This user is locked out");
                return View();

            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Verify()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify(int? passcode)
        {
            var cookie = Request.Cookies["user"];
            if (string.IsNullOrEmpty(cookie))
            {
                return Content("Empty");
            }
            var userId = JsonConvert.DeserializeObject<string>(cookie);
            var user = await _userManager.FindByIdAsync(userId);
            if (passcode == user.VerificationCode)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                IdentityResult result =  await _userManager.ConfirmEmailAsync(user, token);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
                Response.Cookies.Delete("user");
            }
            
            return RedirectToAction(nameof(Login));
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ResetPasswordViewModel resetPasswordVM)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action(nameof(ResetPassword), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("codep320@gmail.com", "Fiorello");
            msg.To.Add(user.Email);


            msg.Body = $"<a href=\"{link}\">Please reset password with this link</a>";
            msg.Subject = "ResetPassword";
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("codep320@gmail.com", "codeacademyp320");
            smtp.Send(msg);

            return RedirectToAction(nameof(Login));
        }
        public async Task<IActionResult> ResetPassword(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            var resetPassword = new ResetPasswordViewModel()
            {
                Token = token,
                Email = email
            };
            return View(resetPassword);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user == null)
            {
                return BadRequest();
            }
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var resetVM = new ResetPasswordViewModel()
            {
                Token = resetPasswordViewModel.Token,
                Email = resetPasswordViewModel.Email
            };
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(resetVM);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
