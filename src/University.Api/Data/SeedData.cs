using System;
using System.Collections.Generic;
using System.Linq;
using University.Api.Core;
using University.Api.Models;

namespace University.Api.Data
{
    public static class SeedData
    {
        public static void Seed(UniversityDbContext context)
        {
            BookConfiguration.Seed(context);
            CellphoneConfiguration.Seed(context);            
            StudentConfiguration.Seed(context);
        }

        internal static class CellphoneConfiguration
        {
            internal static void Seed(UniversityDbContext context)
            {
                var entities = new List<Cellphone>
                {
                    new Cellphone
                    {
                        PhoneName = Constants.PhoneName.iPhone,
                        PhoneModel = "5",
                        Color = "White"
                    },
                    new Cellphone
                    {
                        PhoneName = Constants.PhoneName.Blackberry,
                        PhoneModel = "BB500",
                        Color = "Aluminum"
                    },
                    new Cellphone
                    {
                        PhoneName = Constants.PhoneName.Samsung,
                        PhoneModel = "Galaxy",
                        Color = "Black"
                    }
                };

                foreach(var entity in entities)
                {
                    if(context.Set<Cellphone>().SingleOrDefault(x  => x.PhoneName == entity.PhoneName) == null)
                    {
                        context.Add(entity);
                    }
                }

                context.SaveChanges();
            }
        }

        internal static class BookConfiguration
        {
            internal static void Seed(UniversityDbContext context)
            {
                var entities = new List<Book>
                {
                    new Book
                    {
                        BookName = Constants.BookName.GreatByChoice,
                        Color = "Blue",
                        PublishYear = 2019
                    },
                    new Book
                    {
                        BookName = Constants.BookName.DataStructures,
                        Color = "Purple",
                        PublishYear = 2020
                    },
                    new Book
                    {
                        BookName = Constants.BookName.AdaptiveCode,
                        Color = "Pink",
                        PublishYear = 2016
                    },
                    new Book
                    {
                        BookName = Constants.BookName.ScenarioFocusedEnginerring,
                        Color = "Black",
                        PublishYear = 1983
                    },
                    new Book
                    {
                        BookName = Constants.BookName.DomainDrivenDesign,
                        Color = "White",
                        PublishYear = 1977
                    }
                };

                foreach (var entity in entities)
                {
                    if (context.Set<Book>().SingleOrDefault(x => x.BookName == entity.BookName) == null)
                    {
                        context.Add(entity);
                    }
                }

                context.SaveChanges();
            }
        }

        internal static class StudentConfiguration
        {
            internal static void Seed(UniversityDbContext context)
            {
                var entities = new List<Student>
                {
                    new Student
                    {
                        Firstname = "Kyle",
                        Lastname = "Lowry",
                        Age = 23,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.iPhone ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.DomainDrivenDesign ).BookId
                    },
                    new Student
                    {
                        Firstname = "Billy",
                        Lastname = "Michaels",
                        Age = 20,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.Samsung ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.DomainDrivenDesign ).BookId
                    },
                    new Student
                    {
                        Firstname = "Monique",
                        Lastname = "Anderson",
                        Age = 28,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.Blackberry ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.DomainDrivenDesign).BookId
                    },
                    new Student
                    {
                        Firstname = "Chris",
                        Lastname = "Rock",
                        Age = 39,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.iPhone ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.AdaptiveCode ).BookId
                    },
                    new Student
                    {
                        Firstname = "Jerry",
                        Lastname = "Seinfeld",
                        Age = 20,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.Samsung ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.ScenarioFocusedEnginerring ).BookId
                    },
                    new Student
                    {
                        Firstname = "Lisa",
                        Lastname = "Simpson",
                        Age = 22,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.Samsung ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.ScenarioFocusedEnginerring ).BookId
                    },
                    new Student
                    {
                        Firstname = "Michael",
                        Lastname = "Jordan",
                        Age = 24,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.Samsung ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.AdaptiveCode ).BookId
                    },
                    new Student
                    {
                        Firstname = "Hendricks",
                        Lastname = "Quintyne",
                        Age = 19,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.Samsung ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.GreatByChoice ).BookId
                    },
                    new Student
                    {
                        Firstname = "Olivia",
                        Lastname = "Brown",
                        Age = 31,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.Samsung ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.DomainDrivenDesign ).BookId
                    },
                    new Student
                    {
                        Firstname = "DeAndre",
                        Lastname = "Jordan",
                        Age = 40,
                        Sex = 'M',
                        PhoneId = context.Cellphones.Single(x => x.PhoneName == Constants.PhoneName.Samsung ).PhoneId,
                        BookeId = context.Books.Single(x => x.BookName == Constants.BookName.DataStructures ).BookId
                    },
                };

                foreach (var entity in entities)
                {
                    if (context.Set<Student>().SingleOrDefault(x => x.Firstname == entity.Firstname && x.Lastname == entity.Lastname) == null)
                    {
                        context.Add(entity);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
