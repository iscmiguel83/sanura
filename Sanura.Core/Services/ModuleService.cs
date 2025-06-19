using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Sanura.Core.DTOs;
using Sanura.Core.Entities;
using Sanura.Core.Exceptions;
using Sanura.Core.Extension;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Services;
using Sanura.Core.Model;

namespace Sanura.Core.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor context;
        private readonly int idUser;

        public ModuleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context)
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

        public async Task<ResponseOptions<IEnumerable<ModuleDto>>> GetAsync(RequestOptions options)
        {
            var dinamycObject = await this.unitOfWork.ModuleRepository.GetAsync(options.GetProperties());

            var entities = (IEnumerable<Module>)dinamycObject.GetType().GetProperty("records").GetValue(dinamycObject);
            var totalCount = (int)dinamycObject.GetType().GetProperty("count").GetValue(dinamycObject);

            return new ResponseOptions<IEnumerable<ModuleDto>>(this.mapper.Map<IEnumerable<ModuleDto>>(entities), totalCount);
        }

        public async Task SetAsync(ModuleDto model)
        {
            var result = await this.unitOfWork.ModuleRepository.SetAsync(this.mapper.Map<Module>(model), this.idUser);
            if (result < 0)
            {
                if (result == -101)
                {
                    throw new BusinessException("ModuleExist");
                }
                else if (result == -102)
                {
                    throw new BusinessException("ModuleNotExist");
                }
                else
                {
                    throw new BusinessException("ModuleError");
                }
            }
        }
    }
}