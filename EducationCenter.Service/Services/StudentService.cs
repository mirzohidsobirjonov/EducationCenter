using AutoMapper;
using EducationCenter.Data.IRepositories;
using EducationCenter.Domain.Configurations;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Users;
using EducationCenter.Domain.Enums;
using EducationCenter.Service.DTOs.Students;
using EducationCenter.Service.Exceptions;
using EducationCenter.Service.Extensions;
using EducationCenter.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Student> AddAsync(StudentForCreationDTO student)
        {
            var existTeacher = await unitOfWork.Teachers.GetAsync(t => t.Id == student.TeacherId);
            if (existTeacher is null)
                throw new EducationCenterException(404, "Teacher not found");

            var newStudent = mapper.Map<Student>(student);
            newStudent = await unitOfWork.Students.CreateAsync(newStudent);

            await unitOfWork.SaveChangesAsync();

            return newStudent;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Student, bool>> expression)
        {
            var existedStudent = await unitOfWork.Students.GetAsync(expression);

            if (existedStudent is null)
                throw new EducationCenterException(404, "Student not found");

            existedStudent.State = ItemState.Deleted;
            existedStudent.UpdatedAt = DateTime.UtcNow;

            await unitOfWork.Students.UpdateAsync(existedStudent);
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Student>> GetAllAync(PaginationParams @params, Expression<Func<Student, bool>> expression)
        {
            var students = unitOfWork.Students.GetAll(expression);

            return await students.ToPagedList(@params).ToListAsync();
        }

        public async Task<Student> GetAync(Expression<Func<Student, bool>> expression)
        {
            var student = await unitOfWork.Students.GetAsync(expression);
            if (student is null)
                throw new EducationCenterException(404, "User not found");

            return student;
        }

        public async Task<Student> UpdateAsync(long id, StudentForCreationDTO dto)
        {
            var student = await unitOfWork.Students.GetAsync(u => u.Id == id && u.State != ItemState.Deleted);
            if (student is null)
                throw new EducationCenterException(404, "Student not found");

            var teacher = await unitOfWork.Teachers.GetAsync(t => t.Id == dto.TeacherId);
            if (teacher is null)
                throw new EducationCenterException(404, "Teacher not found");

            var mappedStudent = mapper.Map(dto, student);

            mappedStudent.State = ItemState.Updated;
            mappedStudent.UpdatedAt = DateTime.UtcNow;

            var updatedStudent = await unitOfWork.Students.UpdateAsync(mappedStudent);

            await unitOfWork.SaveChangesAsync();

            return updatedStudent;
        }
    }
}
