using AutoMapper;
using EducationCenter.Data.IRepositories;
using EducationCenter.Domain.Configurations;
using EducationCenter.Domain.Entities.Users;
using EducationCenter.Domain.Enums;
using EducationCenter.Service.DTOs.Users;
using EducationCenter.Service.Exceptions;
using EducationCenter.Service.Extensions;
using EducationCenter.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<User> AddAsync(UserForCrerationDTO user)
        {
            var existedUser = await unitOfWork.Users.GetAsync(u => 
                u.Username.Equals(user.Username) && u.State != ItemState.Deleted);

            if (existedUser is not null)
                throw new EducationCenterException(400, "User already exist");

            var newUser = mapper.Map<User>(user);
            newUser = await unitOfWork.Users.CreateAsync(newUser);

            await unitOfWork.SaveChangesAsync();

            return newUser;
        }

        public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var existedUser = await unitOfWork.Users.GetAsync(expression);

            if (existedUser is null)
                throw new EducationCenterException(404, "User not found");

            existedUser.State = ItemState.Deleted;
            existedUser.UpdatedAt = DateTime.UtcNow;

            await unitOfWork.Users.UpdateAsync(existedUser);
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<User>> GetAllAync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            var users = unitOfWork.Users.GetAll(expression);

            return await users.ToPagedList(@params).ToListAsync();
        }

        public async Task<User> GetAync(Expression<Func<User, bool>> expression)
        {
            var user = await unitOfWork.Users.GetAsync(expression);
            if (user is null)
                throw new EducationCenterException(404, "User not found"); 

            return user;
        }

        public async Task<User> UpdateAsync(long id, UserForCrerationDTO dto)
        {
            var user = await unitOfWork.Users.GetAsync(u => u.Id == id && u.State != ItemState.Deleted);
            if (user is null)
                throw new EducationCenterException(404, "User not found");

            var existUser = await unitOfWork.Users.GetAsync(u =>
                u.Username.Equals(dto.Username) && u.Id != id && u.State != ItemState.Deleted);

            if (existUser is not null)
                throw new EducationCenterException(400, "This username already taken");

            var mappedUser = mapper.Map(dto, user);

            mappedUser.State = ItemState.Updated;
            mappedUser.UpdatedAt = DateTime.UtcNow;

            var updatedUser = await unitOfWork.Users.UpdateAsync(mappedUser);

            await unitOfWork.SaveChangesAsync();

            return updatedUser;
        }
    }
}
