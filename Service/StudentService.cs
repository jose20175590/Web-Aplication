﻿using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IStudentService
    {
        IEnumerable<Students> GetAll();
        bool Add(Students model);
        bool Delete(int id);
        bool Update(Students model);
        Students Get(int id);
    }
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentService(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public IEnumerable<Students> GetAll()
        {
            var result = new List<Students>();

            try
            {
                result = _studentDbContext.Student.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public Students Get(int id)
        {
            var result = new Students();

            try
            {
                result = _studentDbContext.Student.Single(x => x.StudentId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Students model)
        {
            try
            {
                _studentDbContext.Add(model);
                _studentDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(Students model)
        {
            try
            {
                var originalModel = _studentDbContext.Student.Single(x =>
                    x.StudentId == model.StudentId
                );

                originalModel.Name = model.Name;
                originalModel.LastName = model.LastName;
                originalModel.Bio = model.Bio;

                _studentDbContext.Update(originalModel);
                _studentDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _studentDbContext.Entry(new Students { StudentId = id }).State = EntityState.Deleted; ;
                _studentDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}