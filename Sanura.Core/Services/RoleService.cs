using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Sanura.Core.DTOs;
using Sanura.Core.Entities;
using Sanura.Core.Exceptions;
using Sanura.Core.Extension;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Services;
using Sanura.Core.Model;

namespace Sanura.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor context;
        private readonly int idUser;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.context = context;

            //var identity = this.context.HttpContext.User.Identity as ClaimsIdentity;
            //if (identity != null)
            //{
            //    var idUserString = identity.FindFirst(Model.Constants.IdUser).Value;
            //    this.idUser = Convert.ToInt32(idUserString);
            //}
            //TODO
            this.idUser = 1;
        }

        public async Task<ResponseOptions<IEnumerable<RoleDto>>> GetAsync(RequestOptions options)
        {
            var dinamycObject = await this.unitOfWork.RoleRepository.GetAsync(options.GetProperties());

            var entities = (IEnumerable<Role>)dinamycObject.GetType().GetProperty("records").GetValue(dinamycObject);
            var totalCount = (int)dinamycObject.GetType().GetProperty("count").GetValue(dinamycObject);

            return new ResponseOptions<IEnumerable<RoleDto>>(this.mapper.Map<IEnumerable<RoleDto>>(entities), totalCount);
        }

        public async Task SetAsync(RoleDto model)
        {
            var result = await this.unitOfWork.RoleRepository.SetAsync(this.mapper.Map<Role>(model), this.idUser);
            if (result < 0)
            {
                if (result == -101)
                {
                    throw new BusinessException("RoleExist");
                }
                else if (result == -102)
                {
                    throw new BusinessException("RoleNotExist");
                }
                else
                {
                    throw new BusinessException("RoleError");
                }
            }
        }
    }
}