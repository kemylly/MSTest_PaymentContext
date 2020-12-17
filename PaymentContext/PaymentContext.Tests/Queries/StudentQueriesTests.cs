using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            for(var i = 0; i <= 10; i++)
            {
                _students.Add(new Student
                    (new Name("Aluno", i.ToString()), 
                    new Document("12345432112" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "kemylly@gmail.com"))
                );
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678912");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345432112");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }
    }
}