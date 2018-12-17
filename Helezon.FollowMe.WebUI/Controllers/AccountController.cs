using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using FollowMe.Web.Models;
using System.Collections.Generic;
using Helezon.FollowMe.WebUI;

namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult LoginV2(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("Login - Copy");
        }


        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.ListCountry = GetListCountry();
            return View();
        }

        private List<SelectListItem> GetListCountry()
        {
           return new List<SelectListItem>
            {

        new SelectListItem { Value =  "" ,Text ="Country"},
        new SelectListItem { Value = "AF",Text ="Afghanistan"},
        new SelectListItem { Value = "AL",Text ="Albania"},
        new SelectListItem { Value = "DZ",Text ="Algeria"},
        new SelectListItem { Value = "AS",Text ="American Samoa"},
        new SelectListItem { Value = "AD",Text ="Andorra"},
        new SelectListItem { Value = "AO",Text ="Angola"},
        new SelectListItem { Value = "AI",Text ="Anguilla"},
        new SelectListItem { Value = "AR",Text ="Argentina"},
        new SelectListItem { Value = "AM",Text ="Armenia"},
        new SelectListItem { Value = "AW",Text ="Aruba"},
        new SelectListItem { Value = "AU",Text ="Australia"},
        new SelectListItem { Value = "AT",Text ="Austria"},
        new SelectListItem { Value = "AZ",Text ="Azerbaijan"},
        new SelectListItem { Value = "BS",Text ="Bahamas"},
        new SelectListItem { Value = "BH",Text ="Bahrain"},
        new SelectListItem { Value = "BD",Text ="Bangladesh"},
        new SelectListItem { Value = "BB",Text ="Barbados"},
        new SelectListItem { Value = "BY",Text ="Belarus"},
        new SelectListItem { Value = "BE",Text ="Belgium"},
        new SelectListItem { Value = "BZ",Text ="Belize"},
        new SelectListItem { Value = "BJ",Text ="Benin"},
        new SelectListItem { Value = "BM",Text ="Bermuda"},
        new SelectListItem { Value = "BT",Text ="Bhutan"},
        new SelectListItem { Value = "BO",Text ="Bolivia"},
        new SelectListItem { Value = "BA",Text ="Bosnia and Herzegowina"},
        new SelectListItem { Value = "BW",Text ="Botswana"},
        new SelectListItem { Value = "BV",Text ="Bouvet Island"},
        new SelectListItem { Value = "BR",Text ="Brazil"},
        new SelectListItem { Value = "IO",Text ="British Indian Ocean Territory"},
        new SelectListItem { Value = "BN",Text ="Brunei Darussalam"},
        new SelectListItem { Value = "BG",Text ="Bulgaria"},
        new SelectListItem { Value = "BF",Text ="Burkina Faso"},
        new SelectListItem { Value = "BI",Text ="Burundi"},
        new SelectListItem { Value = "KH",Text ="Cambodia"},
        new SelectListItem { Value = "CM",Text ="Cameroon"},
        new SelectListItem { Value = "CA",Text ="Canada"},
        new SelectListItem { Value = "CV",Text ="Cape Verde"},
        new SelectListItem { Value = "KY",Text ="Cayman Islands"},
        new SelectListItem { Value = "CF",Text ="Central African Republic"},
        new SelectListItem { Value = "TD",Text ="Chad"},
        new SelectListItem { Value = "CL",Text ="Chile"},
        new SelectListItem { Value = "CN",Text ="China"},
        new SelectListItem { Value = "CX",Text ="Christmas Island"},
        new SelectListItem { Value = "CC",Text ="Cocos (Keeling} Islands"},
        new SelectListItem { Value = "CO",Text ="Colombia"},
        new SelectListItem { Value = "KM",Text ="Comoros"},
        new SelectListItem { Value = "CG",Text ="Congo"},
        new SelectListItem { Value = "CD",Text ="Congo, the Democratic Republic of the"},
        new SelectListItem { Value = "CK",Text ="Cook Islands"},
        new SelectListItem { Value = "CR",Text ="Costa Rica"},
        new SelectListItem { Value = "CI",Text ="Cote d'Ivoire"},
        new SelectListItem { Value = "HR",Text ="Croatia (Hrvatska}"},
        new SelectListItem { Value = "CU",Text ="Cuba"},
        new SelectListItem { Value = "CY",Text ="Cyprus"},
        new SelectListItem { Value = "CZ",Text ="Czech Republic"},
        new SelectListItem { Value = "DK",Text ="Denmark"},
        new SelectListItem { Value = "DJ",Text ="Djibouti"},
        new SelectListItem { Value = "DM",Text ="Dominica"},
        new SelectListItem { Value = "DO",Text ="Dominican Republic"},
        new SelectListItem { Value = "EC",Text ="Ecuador"},
        new SelectListItem { Value = "EG",Text ="Egypt"},
        new SelectListItem { Value = "SV",Text ="El Salvador"},
        new SelectListItem { Value = "GQ",Text ="Equatorial Guinea"},
        new SelectListItem { Value = "ER",Text ="Eritrea"},
        new SelectListItem { Value = "EE",Text ="Estonia"},
        new SelectListItem { Value = "ET",Text ="Ethiopia"},
        new SelectListItem { Value = "FK",Text ="Falkland Islands (Malvinas}"},
        new SelectListItem { Value = "FO",Text ="Faroe Islands"},
        new SelectListItem { Value = "FJ",Text ="Fiji"},
        new SelectListItem { Value = "FI",Text ="Finland"},
        new SelectListItem { Value = "FR",Text ="France"},
        new SelectListItem { Value = "GF",Text ="French Guiana"},
        new SelectListItem { Value = "PF",Text ="French Polynesia"},
        new SelectListItem { Value = "TF",Text ="French Southern Territories"},
        new SelectListItem { Value = "GA",Text ="Gabon"},
        new SelectListItem { Value = "GM",Text ="Gambia"},
        new SelectListItem { Value = "GE",Text ="Georgia"},
        new SelectListItem { Value = "DE",Text ="Germany"},
        new SelectListItem { Value = "GH",Text ="Ghana"},
        new SelectListItem { Value = "GI",Text ="Gibraltar"},
        new SelectListItem { Value = "GR",Text ="Greece"},
        new SelectListItem { Value = "GL",Text ="Greenland"},
        new SelectListItem { Value = "GD",Text ="Grenada"},
        new SelectListItem { Value = "GP",Text ="Guadeloupe"},
        new SelectListItem { Value = "GU",Text ="Guam"},
        new SelectListItem { Value = "GT",Text ="Guatemala"},
        new SelectListItem { Value = "GN",Text ="Guinea"},
        new SelectListItem { Value = "GW",Text ="Guinea-Bissau"},
        new SelectListItem { Value = "GY",Text ="Guyana"},
        new SelectListItem { Value = "HT",Text ="Haiti"},
        new SelectListItem { Value = "HM",Text ="Heard and Mc Donald Islands"},
        new SelectListItem { Value = "VA",Text ="Holy See (Vatican City State}"},
        new SelectListItem { Value = "HN",Text ="Honduras"},
        new SelectListItem { Value = "HK",Text ="Hong Kong"},
        new SelectListItem { Value = "HU",Text ="Hungary"},
        new SelectListItem { Value = "IS",Text ="Iceland"},
        new SelectListItem { Value = "IN",Text ="India"},
        new SelectListItem { Value = "ID",Text ="Indonesia"},
        new SelectListItem { Value = "IR",Text ="Iran (Islamic Republic of}"},
        new SelectListItem { Value = "IQ",Text ="Iraq"},
        new SelectListItem { Value = "IE",Text ="Ireland"},
        new SelectListItem { Value = "IL",Text ="Israel"},
        new SelectListItem { Value = "IT",Text ="Italy"},
        new SelectListItem { Value = "JM",Text ="Jamaica"},
        new SelectListItem { Value = "JP",Text ="Japan"},
        new SelectListItem { Value = "JO",Text ="Jordan"},
        new SelectListItem { Value = "KZ",Text ="Kazakhstan"},
        new SelectListItem { Value = "KE",Text ="Kenya"},
        new SelectListItem { Value = "KI",Text ="Kiribati"},
        new SelectListItem { Value = "KP",Text ="Korea, Democratic People's Republic of"},
        new SelectListItem { Value = "KR",Text ="Korea, Republic of"},
        new SelectListItem { Value = "KW",Text ="Kuwait"},
        new SelectListItem { Value = "KG",Text ="Kyrgyzstan"},
        new SelectListItem { Value = "LA",Text ="Lao People's Democratic Republic"},
        new SelectListItem { Value = "LV",Text ="Latvia"},
        new SelectListItem { Value = "LB",Text ="Lebanon"},
        new SelectListItem { Value = "LS",Text ="Lesotho"},
        new SelectListItem { Value = "LR",Text ="Liberia"},
        new SelectListItem { Value = "LY",Text ="Libyan Arab Jamahiriya"},
        new SelectListItem { Value = "LI",Text ="Liechtenstein"},
        new SelectListItem { Value = "LT",Text ="Lithuania"},
        new SelectListItem { Value = "LU",Text ="Luxembourg"},
        new SelectListItem { Value = "MO",Text ="Macau"},
        new SelectListItem { Value = "MK",Text ="Macedonia, The Former Yugoslav Republic of"},
        new SelectListItem { Value = "MG",Text ="Madagascar"},
        new SelectListItem { Value = "MW",Text ="Malawi"},
        new SelectListItem { Value = "MY",Text ="Malaysia"},
        new SelectListItem { Value = "MV",Text ="Maldives"},
        new SelectListItem { Value = "ML",Text ="Mali"},
        new SelectListItem { Value = "MT",Text ="Malta"},
        new SelectListItem { Value = "MH",Text ="Marshall Islands"},
        new SelectListItem { Value = "MQ",Text ="Martinique"},
        new SelectListItem { Value = "MR",Text ="Mauritania"},
        new SelectListItem { Value = "MU",Text ="Mauritius"},
        new SelectListItem { Value = "YT",Text ="Mayotte"},
        new SelectListItem { Value = "MX",Text ="Mexico"},
        new SelectListItem { Value = "FM",Text ="Micronesia, Federated States of"},
        new SelectListItem { Value = "MD",Text ="Moldova, Republic of"},
        new SelectListItem { Value = "MC",Text ="Monaco"},
        new SelectListItem { Value = "MN",Text ="Mongolia"},
        new SelectListItem { Value = "MS",Text ="Montserrat"},
        new SelectListItem { Value = "MA",Text ="Morocco"},
        new SelectListItem { Value = "MZ",Text ="Mozambique"},
        new SelectListItem { Value = "MM",Text ="Myanmar"},
        new SelectListItem { Value = "NA",Text ="Namibia"},
        new SelectListItem { Value = "NR",Text ="Nauru"},
        new SelectListItem { Value = "NP",Text ="Nepal"},
        new SelectListItem { Value = "NL",Text ="Netherlands"},
        new SelectListItem { Value = "AN",Text ="Netherlands Antilles"},
        new SelectListItem { Value = "NC",Text ="New Caledonia"},
        new SelectListItem { Value = "NZ",Text ="New Zealand"},
        new SelectListItem { Value = "NI",Text ="Nicaragua"},
        new SelectListItem { Value = "NE",Text ="Niger"},
        new SelectListItem { Value = "NG",Text ="Nigeria"},
        new SelectListItem { Value = "NU",Text ="Niue"},
        new SelectListItem { Value = "NF",Text ="Norfolk Island"},
        new SelectListItem { Value = "MP",Text ="Northern Mariana Islands"},
        new SelectListItem { Value = "NO",Text ="Norway"},
        new SelectListItem { Value = "OM",Text ="Oman"},
        new SelectListItem { Value = "PK",Text ="Pakistan"},
        new SelectListItem { Value = "PW",Text ="Palau"},
        new SelectListItem { Value = "PA",Text ="Panama"},
        new SelectListItem { Value = "PG",Text ="Papua New Guinea"},
        new SelectListItem { Value = "PY",Text ="Paraguay"},
        new SelectListItem { Value = "PE",Text ="Peru"},
        new SelectListItem { Value = "PH",Text ="Philippines"},
        new SelectListItem { Value = "PN",Text ="Pitcairn"},
        new SelectListItem { Value = "PL",Text ="Poland"},
        new SelectListItem { Value = "PT",Text ="Portugal"},
        new SelectListItem { Value = "PR",Text ="Puerto Rico"},
        new SelectListItem { Value = "QA",Text ="Qatar"},
        new SelectListItem { Value = "RE",Text ="Reunion"},
        new SelectListItem { Value = "RO",Text ="Romania"},
        new SelectListItem { Value = "RU",Text ="Russian Federation"},
        new SelectListItem { Value = "RW",Text ="Rwanda"},
        new SelectListItem { Value = "KN",Text ="Saint Kitts and Nevis"},
        new SelectListItem { Value = "LC",Text ="Saint LUCIA"},
        new SelectListItem { Value = "VC",Text ="Saint Vincent and the Grenadines"},
        new SelectListItem { Value = "WS",Text ="Samoa"},
        new SelectListItem { Value = "SM",Text ="San Marino"},
        new SelectListItem { Value = "ST",Text ="Sao Tome and Principe"},
        new SelectListItem { Value = "SA",Text ="Saudi Arabia"},
        new SelectListItem { Value = "SN",Text ="Senegal"},
        new SelectListItem { Value = "SC",Text ="Seychelles"},
        new SelectListItem { Value = "SL",Text ="Sierra Leone"},
        new SelectListItem { Value = "SG",Text ="Singapore"},
        new SelectListItem { Value = "SK",Text ="Slovakia (Slovak Republic}"},
        new SelectListItem { Value = "SI",Text ="Slovenia"},
        new SelectListItem { Value = "SB",Text ="Solomon Islands"},
        new SelectListItem { Value = "SO",Text ="Somalia"},
        new SelectListItem { Value = "ZA",Text ="South Africa"},
        new SelectListItem { Value = "GS",Text ="South Georgia and the South Sandwich Islands"},
        new SelectListItem { Value = "ES",Text ="Spain"},
        new SelectListItem { Value = "LK",Text ="Sri Lanka"},
        new SelectListItem { Value = "SH",Text ="St. Helena"},
        new SelectListItem { Value = "PM",Text ="St. Pierre and Miquelon"},
        new SelectListItem { Value = "SD",Text ="Sudan"},
        new SelectListItem { Value = "SR",Text ="Suriname"},
        new SelectListItem { Value = "SJ",Text ="Svalbard and Jan Mayen Islands"},
        new SelectListItem { Value = "SZ",Text ="Swaziland"},
        new SelectListItem { Value = "SE",Text ="Sweden"},
        new SelectListItem { Value = "CH",Text ="Switzerland"},
        new SelectListItem { Value = "SY",Text ="Syrian Arab Republic"},
        new SelectListItem { Value = "TW",Text ="Taiwan, Province of China"},
        new SelectListItem { Value = "TJ",Text ="Tajikistan"},
        new SelectListItem { Value = "TZ",Text ="Tanzania, United Republic of"},
        new SelectListItem { Value = "TH",Text ="Thailand"},
        new SelectListItem { Value = "TG",Text ="Togo"},
        new SelectListItem { Value = "TK",Text ="Tokelau"},
        new SelectListItem { Value = "TO",Text ="Tonga"},
        new SelectListItem { Value = "TT",Text ="Trinidad and Tobago"},
        new SelectListItem { Value = "TN",Text ="Tunisia"},
        new SelectListItem { Value = "TR",Text ="Turkey"},
        new SelectListItem { Value = "TM",Text ="Turkmenistan"},
        new SelectListItem { Value = "TC",Text ="Turks and Caicos Islands"},
        new SelectListItem { Value = "TV",Text ="Tuvalu"},
        new SelectListItem { Value = "UG",Text ="Uganda"},
        new SelectListItem { Value = "UA",Text ="Ukraine"},
        new SelectListItem { Value = "AE",Text ="United Arab Emirates"},
        new SelectListItem { Value = "GB",Text ="United Kingdom"},
        new SelectListItem { Value = "US",Text ="United States"},
        new SelectListItem { Value = "UM",Text ="United States Minor Outlying Islands"},
        new SelectListItem { Value = "UY",Text ="Uruguay"},
        new SelectListItem { Value = "UZ",Text ="Uzbekistan"},
        new SelectListItem { Value = "VU",Text ="Vanuatu"},
        new SelectListItem { Value = "VE",Text ="Venezuela"},
        new SelectListItem { Value = "VN",Text ="Viet Nam"},
        new SelectListItem { Value = "VG",Text ="Virgin Islands (British}"},
        new SelectListItem { Value = "VI",Text ="Virgin Islands (U.S.}"},
        new SelectListItem { Value = "WF",Text ="Wallis and Futuna Islands"},
        new SelectListItem { Value = "EH",Text ="Western Sahara"},
        new SelectListItem { Value = "YE",Text ="Yemen"},
        new SelectListItem { Value = "ZM",Text ="Zambia"},
        new SelectListItem { Value = "ZW",Text ="Zimbabwe"}
    };
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    Fullname = model.Fullname,
                    Tnc = model.Tnc
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("DashBoard", "GuideBook");
                }
                AddErrors(result);
            }

            ViewBag.ListCountry = GetListCountry();
            ViewBag.ShowRegisterForm = true;
            // If we got this far, something failed, redisplay form
            return View();
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByNameAsync(model.Email);

            if (user == null)
            {
                user = await UserManager.FindByEmailAsync(model.Email);
            }

            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);

            if (!result.Succeeded) {
                result = await UserManager.RemovePasswordAsync(user.Id);
                if (result.Succeeded)
                {
                    result = await UserManager.AddPasswordAsync(user.Id,model.Password);
                }
            }

            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction(actionName: "DashBoard", controllerName: "GuideBook");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(actionName: "DashBoard",controllerName: "GuideBook");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}