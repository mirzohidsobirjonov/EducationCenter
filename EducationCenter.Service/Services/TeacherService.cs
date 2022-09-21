using AutoMapper;
using EducationCenter.Data.IRepositories;
using EducationCenter.Domain.Configurations;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Domain.Enums;
using EducationCenter.Service.DTOs.Teachers;
using EducationCenter.Service.Exceptions;
using EducationCenter.Service.Extensions;
using EducationCenter.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EducationCenter.Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Teacher> AddAsync(TeacherForCreationDTO teacher)
        {
            var newTeacher = mapper.Map<Teacher>(teacher);

            newTeacher = await unitOfWork.Teachers.CreateAsync(newTeacher);
            await unitOfWork.SaveChangesAsync();

            return newTeacher;

        }

        public async Task<bool> DeleteAsync(Expression<Func<Teacher, bool>> expression)
        {
            var teacher = await unitOfWork.Teachers.GetAsync(expression);
            if (teacher is null)
                throw new EducationCenterException(404, "Teacher not found");

            teacher.State = ItemState.Deleted;
            teacher.UpdatedAt = DateTime.UtcNow;

            await unitOfWork.Teachers.UpdateAsync(teacher);
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Teacher>> GetAllAync(PaginationParams @params, Expression<Func<Teacher, bool>> expression)
        {
            var teachers = unitOfWork.Teachers.GetAll(expression);

            return await teachers.ToPagedList(@params).ToListAsync();
        }

        public async Task<Teacher> GetAsync(Expression<Func<Teacher, bool>> expression)
        {
            var teacher = await unitOfWork.Teachers.GetAsync(expression);
            if (teacher is null)
                throw new EducationCenterException(404, "Teacher not found");

            return teacher;
        }

        public async Task<Teacher> UpdateAsync(long id, TeacherForCreationDTO teacher)
        {
            var existTeacher = await unitOfWork.Teachers.GetAsync(t => t.Id == id);
            if (existTeacher is null)
                throw new EducationCenterException(404, "Teacher not found");

            var mappedTeacher = mapper.Map(teacher, existTeacher);

            mappedTeacher.State = ItemState.Updated;
            mappedTeacher.UpdatedAt = DateTime.UtcNow;

            var updatedTeacher =  await unitOfWork.Teachers.UpdateAsync(mappedTeacher);
            await unitOfWork.SaveChangesAsync();

            return updatedTeacher;
        }
    }
}