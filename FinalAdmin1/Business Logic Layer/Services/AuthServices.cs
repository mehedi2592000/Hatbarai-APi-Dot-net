using Business_Entity_Layer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data_Entity_Layer;

namespace Business_Logic_Layer.Services
{
   public class AuthServices
    {
        /*
        static AuthServices()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<Token, TokenModel>();
                cfg.CreateMap<TokenModel, Token>();
            });
        }
        */
        public static TokanModel Auth(UserModel us)
        {
            var dbuser = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserModel, user>())).Map<user>(us);
            var tok = DataAccessFactory.AuthDataAccess().Authenticate(dbuser);
            var toke = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<token, TokanModel>())).Map<TokanModel>(tok);
            return toke;
        }

        public static bool CheckValidityToken(string tok)
        {
            var rs = DataAccessFactory.AuthDataAccess().IsAuthenticated(tok);
            return rs;
        }

        public static bool Logout(string token)
        {
            return DataAccessFactory.AuthDataAccess().Logout(token) ;
        }
    }
}
