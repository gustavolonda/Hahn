using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Domain.Models;


namespace Hahn.ApplicatonProcess.July2021.Web.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();

        }
    }
}