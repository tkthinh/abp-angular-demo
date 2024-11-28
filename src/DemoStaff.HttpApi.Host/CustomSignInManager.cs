using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Volo.Abp.Identity;

public class CustomSignInManager : SignInManager<Volo.Abp.Identity.IdentityUser>
{
   private readonly IdentityUserManager _userManager;
   private readonly IIdentityUserRepository _userRepository;

   public CustomSignInManager(
       IdentityUserManager userManager,
       IIdentityUserRepository userRepository,
       Microsoft.AspNetCore.Http.IHttpContextAccessor contextAccessor,
       IUserClaimsPrincipalFactory<Volo.Abp.Identity.IdentityUser> claimsFactory,
       Microsoft.Extensions.Options.IOptions<IdentityOptions> optionsAccessor,
       Microsoft.Extensions.Logging.ILogger<SignInManager<Volo.Abp.Identity.IdentityUser>> logger,
       Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider schemes,
       IUserConfirmation<Volo.Abp.Identity.IdentityUser> confirmation)
       : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
   {
      _userManager = userManager;
      _userRepository = userRepository;
   }

   public override async Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor)
   {
      // kiem tra user da dang nhap vao he thong tu 1 provider chua (Google)
      var user = await _userManager.FindByLoginAsync(loginProvider, providerKey);
      if (user != null)
      {
         // da ton tai => dang nhap
         return await base.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypassTwoFactor);
      }

      // chua ton tai => tao moi
      var externalLoginInfo = await GetExternalLoginInfoAsync();
      if (externalLoginInfo != null)
      {
         var emailAddress = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);
         var name = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Name);

         // kiem tra email da ton tai chua
         var existingUser = await _userManager.FindByEmailAsync(emailAddress);
         if (existingUser != null)
         {
            // neu email da ton tai => them login provider vao user
            await _userManager.AddLoginAsync(existingUser, new UserLoginInfo(
                externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey,
                externalLoginInfo.LoginProvider
            ));

            // dang nhap
            return await SignInOrTwoFactorAsync(existingUser, isPersistent, loginProvider, bypassTwoFactor);
         }

         // tao moi user
         var newUser = new Volo.Abp.Identity.IdentityUser(Guid.NewGuid(), emailAddress, emailAddress)
         {
            Name = name,
         };

         var result = await _userManager.CreateAsync(newUser);
         if (result.Succeeded)
         {
            // tao external login info (Google, ...)
            await _userManager.AddLoginAsync(newUser, new UserLoginInfo(
                externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey,
                externalLoginInfo.LoginProvider
            ));

            // bo qua dang ky, dang nhap
            return await SignInOrTwoFactorAsync(newUser, isPersistent, loginProvider, bypassTwoFactor);
         }
      }

      return SignInResult.Failed;
   }

}