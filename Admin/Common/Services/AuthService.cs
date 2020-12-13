using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Navigation;
using Client.Common.Constants;
using Client.Common.Enum;
using Client.Common.Extensions;
using Client.Common.Interfaces;
//using Client.Models;
//using Client.ViewModels;
//using System.IdentityModel.Tokens.Jwt;
//using Prism.Regions;

//namespace Client.Common.Services
//{
//    public class AuthService
//    {
//        private bool? _canAutoAuthenticate;
//        private string _savedPincode;
//        private string _savedPhoneNumber;
//        private string _savedPhonePrefix;
//        private JwtPayload _savedClaims;
//        private readonly ISecureStorageService _secureStorageService;
//        private readonly IConfigurationManager _configurationManager;
//        private readonly IHttpService _httpService;
//        private readonly ITokenService _tokenService;
//        private readonly IDoctorService _doctorService;
//        private readonly IPatientService _patientService;

//        public AuthService(ISecureStorageService secureStorageService, IConfigurationManager configurationManager,
//            IHttpService httpService, ITokenService tokenService, IDoctorService doctorService, IPatientService patientService)
//        {
//            _tokenService = tokenService;
//            _doctorService = doctorService;
//            _patientService = patientService;
//            _configurationManager = configurationManager;
//            _secureStorageService = secureStorageService;
//            _httpService = httpService;
//        }

//        public async Task<bool> IdentificateByPinCodeAsync(string pincode)
//        {
//            _savedPincode = await _secureStorageService.GetAsync(AppConstants.SecurePinCode);
//            return _savedPincode.Equals(pincode);
//        }

//        public async Task<bool> CanAutoAuthenticateAsync()
//        {
//            if (_canAutoAuthenticate.HasValue)
//                return _canAutoAuthenticate.Value;
//            _canAutoAuthenticate = await _secureStorageService.AreValuesExistAsync(AppConstants.SecurePinCode, AppConstants.SecurePhoneNumber,
//                AppConstants.SecurePhonePrefix, AppConstants.SecurePassword);
//            return _canAutoAuthenticate.Value;
//        }

//        public async Task<bool> SaveLoginDataToStorageAsync(LoginModel loginModel, string pincode)
//        {
//            try
//            {
//                await _secureStorageService.SetAsync(AppConstants.SecurePhoneNumber, loginModel.PhoneNumber);
//                await _secureStorageService.SetAsync(AppConstants.SecurePhonePrefix, loginModel.PhonePrefix);
//                await _secureStorageService.SetAsync(AppConstants.SecurePassword, loginModel.Password);
//                await _secureStorageService.SetAsync(AppConstants.SecurePinCode, pincode);
//                return true;
//            }
//            catch { }
//            return false;
//        }

//        public async Task<bool> ResendVerificationCodeAsync()
//        {
//            var model = new { UserId = _savedClaims.UserId };
//            var result = await _httpService.PutAsync<string>(ApiConstants.ResendVerificationCode, model, _configurationManager.IdentityServerUrl);
//            return result.ValidateResponse();
//        }

//        public async Task<bool> ConfirmVerificationCodeAsync(string code)
//        {
//            var model = new { Token = code, UserId = _savedClaims.UserId };
//            var result = await _httpService.PutAsync<string>(ApiConstants.ConfirmVerificationCode, model, _configurationManager.IdentityServerUrl);
//            return result.ValidateResponse();
//        }

//        public async Task<bool> RegisterAsPatientAsync(string countryCode)
//        {
//            var model = new { CountryCode = countryCode };
//            var result = await _httpService.PostAsync<Patient>(ApiConstants.Patient, model);
//            return result.ValidateResponse();
//        }

//        //public async Task<bool> RegisterAsDoctorAsync(string countryCode)
//        //{
//        //    var model = new { CountryCode = countryCode };
//        //    var result = await _httpService.PostAsync<Doctor>(ApiConstants.Doctor, model);
//        //    return result.ValidateResponse();
//        //}

//        //public UserType GetUserRole()
//        //{
//        //    if (_savedClaims != null)
//        //        return _savedClaims.Role;
//        //    return UserType.Unknown;
//        //}

//        public async Task LoginByPincodeAsync(string pincode, INavigatorService navigatorService)
//        {
//            if(!pincode.Equals(_savedPincode) || !_canAutoAuthenticate.Value)
//                await ProccessLoginResponseAsync((LoginStatus.NotAuthorized, UserType.Unknown), navigatorService);
//            var loginModel = await GetLoginCredsAsync();
//            await LoginAsync(loginModel, navigatorService);
//        }

//        public async Task LoginByBiometricAsync(INavigatorService navigatorService)
//        {
//            var loginModel = await GetLoginCredsAsync();
//            await LoginAsync(loginModel, navigatorService);
//        }

//        public async Task LoginAsync(LoginModel loginModel, INavigatorService navigatorService)
//        {
//            var tokens = await _tokenService.GetAutorizationTokensAsync(loginModel.FullPhoneNumber, loginModel.Password);
//            if (tokens.IsEmpty())
//            {
//                await ProccessLoginResponseAsync((LoginStatus.NotAuthorized, UserType.Unknown), navigatorService);
//                return;
//            }

//            var claims = _tokenService.GetClaims(tokens.AccessToken);
//            if (claims == null)
//            {
//                await ProccessLoginResponseAsync((LoginStatus.NotAuthorized, UserType.Unknown), navigatorService);
//                return;
//            }

//            _savedClaims = claims;
//            if (!claims.PhoneNumberVerified)
//                await ProccessLoginResponseAsync((LoginStatus.NeedMobileVerification, claims.Role), navigatorService);
//            else
//            {
//                IResult<BaseUser> userResponse;
//                if (claims.Role == UserType.Patient || claims.Role == UserType.Admin) //Todo: remove admin
//                    userResponse = await _patientService.GetProfileAsync();
//                else if (claims.Role == UserType.Doctor)
//                    userResponse = await _doctorService.GetProfileAsync();
//                else
//                {
//                    await ProccessLoginResponseAsync((LoginStatus.NotAuthorized, UserType.Unknown), navigatorService);
//                    return;
//                }

//                if (userResponse.IsSuccess)
//                    await ProccessLoginResponseAsync((LoginStatus.Authorized, claims.Role), navigatorService);
//                else if (userResponse.StatusCode == 404)
//                    await ProccessLoginResponseAsync((LoginStatus.ApiNotCreatedYet, claims.Role), navigatorService);
//                else
//                {
//                    userResponse.ValidateResponse();
//                    await ProccessLoginResponseAsync((LoginStatus.NotAuthorized, claims.Role), navigatorService);
//                }
//            }
//        }

//        public async Task<bool> RegisterAsync(UserRegister userRegisterModel)
//        {
//            var result = await _httpService.PostAsync<SimpleResponse<string>>(ApiConstants.Account, userRegisterModel, _configurationManager.IdentityServerUrl);
//            return result.ValidateResponse();
//        }

//        public async Task<bool> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
//        {
//            //Todo: add android hash key
//            var result = await _httpService.PostAsync<SimpleResponse<string>>(ApiConstants.ForgotPassword, forgotPasswordModel, _configurationManager.IdentityServerUrl);
//            return result.ValidateResponse();
//        }

//        public async Task<bool> ForgotPasswordConfirmAsync(ForgotPasswordConfirmationModel forgotPasswordModel)
//        {
//            var result = await _httpService.PostAsync<SimpleResponse<string>>(ApiConstants.ForgotPasswordConfirm, forgotPasswordModel, _configurationManager.IdentityServerUrl);
//            if (result.ValidateResponse())
//            {
//                await _secureStorageService.SetAsync(AppConstants.SecurePassword, forgotPasswordModel.Password);
//                return true;
//            }
//            return false;
//        }

//        private async Task<LoginModel> GetLoginCredsAsync()
//        {
//            LoginModel model = null;
//            try
//            {
//                _savedPhoneNumber = await _secureStorageService.GetAsync(AppConstants.SecurePhoneNumber);
//                _savedPhonePrefix = await _secureStorageService.GetAsync(AppConstants.SecurePhonePrefix);
//                var pasword = await _secureStorageService.GetAsync(AppConstants.SecurePassword);
//                if (string.IsNullOrEmpty(_savedPhoneNumber) || string.IsNullOrEmpty(_savedPhonePrefix) || string.IsNullOrEmpty(pasword))
//                    throw new ArgumentNullException();
//                model = new LoginModel
//                {
//                    PhoneNumber = _savedPhoneNumber,
//                    PhonePrefix = _savedPhonePrefix,
//                    Password = pasword
//                };
//            }
//            catch { }
//            return model;
//        }

//        private async Task ProccessLoginResponseAsync((LoginStatus loginStatus, UserType userType) t, INavigatorService navigationService)
//        {
//            switch (t.loginStatus)
//            {
//                case LoginStatus.Authorized when t.userType == UserType.Patient:
//                    {
//                        await navigationService.NavigateFromMenuAsync<UserMasterDetailViewModel, UserHomeViewModel>();
//                        break;
//                    }
//                case LoginStatus.Authorized when t.userType == UserType.Doctor:
//                    {
//                        await navigationService.NavigateFromMenuAsync<DoctorMasterDetailViewModel, NotActivatedDoctorHomeViewModel>();
//                        break;
//                    }
//                case LoginStatus.NeedMobileVerification:
//                    {
//                        var resent = await ResendVerificationCodeAsync();
//                        if (resent)
//                        {
//                            var user = GetRegisterModel();
//                            var navPar = new NavigationParameters
//                                {
//                                    { nameof(VerificationCodeViewModel.User), user },
//                                    { nameof(UserType), user.Role }
//                                };
//                            await navigationService.NavigateAsync<VerificationCodeViewModel>(navPar);
//                        }
//                        break;
//                    }
//                case LoginStatus.ApiNotCreatedYet:
//                    {
//                        var user = GetRegisterModel();
//                        var navPar = new NavigationParameters
//                                {
//                                    { nameof(CountryRegistrationViewModel.User), user },
//                                    { nameof(UserType), user.Role }
//                                };
//                        await navigationService.NavigateAsync<CountryRegistrationViewModel>(navPar);
//                        break;
//                    }
//                default:
//                    break;
//            }
//        }

//        public UserRegisterViewModel GetRegisterModel()
//        {
//            if (!_canAutoAuthenticate.HasValue || !_canAutoAuthenticate.Value || string.IsNullOrEmpty(_savedPhonePrefix) || string.IsNullOrEmpty(_savedPhoneNumber))
//                return null;
//            else
//            {
//                var model = new UserRegister
//                {
//                    Role = GetUserRole(),
//                    PhonePrefix = _savedPhonePrefix,
//                    PhoneNumber = _savedPhoneNumber
//                };
//                return new UserRegisterViewModel(model);
//            }
//        }
//    }
//}
