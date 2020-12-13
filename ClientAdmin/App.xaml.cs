using ClientAdmin.Common.Constants;
using ClientAdmin.Common.Extensions;
using ClientAdmin.Common.Interfaces;
using ClientAdmin.Common.Services;
using ClientAdmin.Configuration;
using ClientAdmin.Dialogs;
using ClientAdmin.ViewModels;
using ClientAdmin.ViewModels.ViewModels;
using ClientAdmin.Views;
using Prism.Ioc;
using Prism.Services.Dialogs;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ClientAdmin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var manager = Container.Resolve<IConfigurationManager>();
            manager.Configure(AppConstants.ConfigFile);
            var w = Container.Resolve<LoginPage>();
            return w;
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<AddTeacher, TeacherViewModel>();

            containerRegistry.RegisterForNavigation<TeachersPage, TeachersViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NotificationDialog, NotificationDialogViewModel>();
            containerRegistry.Register<ICustomerStore, DbCustomerStore>();
            containerRegistry.RegisterForNavigation<StudentsPage, StudentsViewModel>();
            containerRegistry.RegisterSingleton<IConfigurationManager, ConfigurationManager>();
            containerRegistry.RegisterSingleton<IUnauthorizedHandlerStrategy, UnauthorizedHandlerStrategy>();
            containerRegistry.RegisterSingleton<IHttpService, HttpService>();
            containerRegistry.RegisterSingleton<ICrashService, CrashService>();
            containerRegistry.RegisterSingleton<ITokenService, TokenService>();
            containerRegistry.RegisterSingleton<IDialogService, DialogService>();
            containerRegistry.RegisterSingleton<TeacherService>();
            containerRegistry.RegisterSingleton<DepartmentService>();



        }
        public static void RegisterServices(IContainerRegistry containerRegistry)
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

        public static void RegisterViewModels(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterTypeForViewModelNavigation<LoginPage, LoginViewModel>();
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
