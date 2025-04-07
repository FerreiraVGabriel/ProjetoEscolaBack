using Infra.Entities;
using Infra.Erros;
using Infra.Interfaces;
using OneOf;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario> GetByNomeAsync(string nome)
        {
            return await _userRepository.GetByNomeAsync(nome);
        }
    }
}
