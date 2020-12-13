using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Ioc;
using Client.Common.Interfaces;
using Client.Common.Services;
using Client.Models;
using Client.ViewModels;
using Client.Views;

namespace Client.Common.Extensions
{
    public static class AppExtension
    {

        public async static Task<HttpContent> CloneAsync(this HttpContent content)
        {
            if (content == null) return null;

            var ms = new MemoryStream();
            await content.CopyToAsync(ms);
            ms.Position = 0;

            var clone = new StreamContent(ms);
            foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
            {
                clone.Headers.Add(header.Key, header.Value);
            }
            return clone;
        }

        public static bool IsEmpty(this TokensModel tokenModel)
        {
            return tokenModel == null || string.IsNullOrEmpty(tokenModel.AccessToken) || string.IsNullOrEmpty(tokenModel.RefreshToken);
        }

        public static bool IsJson(this string s)
        {
            try
            {
                JToken.Parse(s);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }

        public static TokensModel Clone(this TokensModel tokenModel)
        {
            return new TokensModel
            {
                AccessToken = tokenModel.AccessToken,
                RefreshToken = tokenModel.RefreshToken
            };
        }

        public static void RegisterServices(this IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterSingleton<ICrashService, CrashService>();
            //containerRegistry.Register<INavigatorService, NavigatorService>();
            //containerRegistry.RegisterSingleton<IConfigurationManager, ConfigurationManager>();
            //containerRegistry.RegisterSingleton<IHttpService, HttpService>();
            //containerRegistry.RegisterSingleton<IConnectivityService, ConnectivityService>();
            //containerRegistry.RegisterSingleton<IUnauthorizedHandlerStrategy, UnauthorizedHandlerStrategy>();
            //containerRegistry.RegisterSingleton<ITokenService, TokenService>();
            //containerRegistry.RegisterSingleton<ISecureStorageService, SecureStorageService>();
            //containerRegistry.RegisterSingleton<IDialogService, DialogService>();
            //containerRegistry.RegisterSingleton<IBiometricService, BiometricService>();
            //containerRegistry.RegisterSingleton<IBrowserService, BrowserService>();
            //containerRegistry.RegisterSingleton<IAuthService, AuthService>();
            //containerRegistry.RegisterSingleton<IPhotoService, PhotoService>();
            //containerRegistry.RegisterSingleton<IUserService, UserService>();
            //containerRegistry.RegisterSingleton<ICountryService, CountryService>();
            //containerRegistry.RegisterSingleton<IDoctorService, DoctorService>();
            //containerRegistry.RegisterSingleton<IPatientService, PatientService>();
            //containerRegistry.RegisterSingleton<IPhoneService, PhoneService>();
            //containerRegistry.RegisterSingleton<ISpecialtyService, SpecialtyService>();
        }

        public static void RegisterViewModels(this IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterTypeForViewModelNavigation<LoginPage, LoginViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<VerificationCodePage, VerificationCodeViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<ForgotPasswordPage, ForgotPasswordViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<ForgotPasswordSecondPage, ForgotPasswordSecondViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<GeneralRegistrationPage, GeneralRegistrationViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<PasswordRegistrationPage, PasswordRegistrationViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<CountryRegistrationPage, CountryRegistrationViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<TypeOfUserRegistrationPage, TypeOfUserRegistrationViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<UserMasterDetailPage, UserMasterDetailViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<DoctorMasterDetailPage, DoctorMasterDetailViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<UserHomePage, UserHomeViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<NotActivatedDoctorHomePage, NotActivatedDoctorHomeViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<PinCodePage, PinCodeViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<PersonalInformationPage, PersonalInformationViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<MedicalProfilePage, MedicalProfileViewModel>();
            //containerRegistry.RegisterTypeForViewModelNavigation<ReferenceCodePage, ReferenceCodeViewModel>();
            //containerRegistry.RegisterPopupTypeForViewModelNavigation<WorkExperiencePopupPage, WorkExperienceViewModel>();
            //containerRegistry.RegisterPopupTypeForViewModelNavigation<AddLicensePopupPage, AddLicenseViewModel>();
        }
    }
}
