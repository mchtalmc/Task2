using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Authentication;
using ToDoList.DataLayer.Abstract;

namespace ToDoList.DataLayer.EntityFramework
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ITokenRepository _tokenRepository;

        public AuthRepository(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<UserLoginResponse> LoginUser(UserLoginRequest request)
        {
            UserLoginResponse response = new UserLoginResponse();
            
            if(string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password)){
                throw new ArgumentException(nameof(request));
            }
            if(request.Username=="ben" && request.Password == "123456")
            {
                //Username ve sifreyi kayitli kullanicilarin sifre ve idsi ile eslestirebilirim. onunn icin ResultUserDto'dan verileri cekebilmem lazim.
                //Ust method'dan Parametre olarak ResultUserDto'yu verecegim ve ve AuthRepository' icerisinde db'yle baglanti kurup password ve usernam'i alacagim
                //Daha sonra token'i giris yapan kullanicaya ozel olusturabilirim .
                //Burda da auth oluyor token uretiliyor , swager'a auth icin eklemelerimi yapiyorum fakat crud islemlerinde auth olamiyorum.
                //Internette .net 8 oncesi authentication ve authorize ilsmleri farkli . Sorun ne acaba
                var generatedToken = await _tokenRepository.GenerateToken(new GenerateTokenRequest { Username = request.Username });
                response.AuthenticateResult = true;
                response.AccessTokenExpireDate= generatedToken.TokenExpireDate;
                response.AuthToken = generatedToken.Token;
            }
            return response;
        }
    }
}
