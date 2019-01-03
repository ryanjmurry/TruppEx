using System;
using TruppEx.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace TruppEx.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TruppContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee
                {
                    FullName = "Ricky Carmichael"
                },
                new Employee
                {
                    FullName = "Ryan Dungey"
                }
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            var lifeEventTypes = new LifeEventType[]
            {
                new LifeEventType
                {
                    Type = "Date of hire"
                },
                new LifeEventType
                {
                    Type = "Marriage"
                },
                new LifeEventType
                {
                    Type = "Birth/Adoption"
                },
                new LifeEventType
                {
                    Type = "Gain of other coverage"
                },
                new LifeEventType
                {
                    Type = "Loss of other coverage"
                }
            };
            foreach (LifeEventType let in lifeEventTypes)
            {
                context.LifeEventTypes.Add(let);
            }
            context.SaveChanges();

            var lifeEvents = new LifeEvent[]
            {
                new LifeEvent
                {
                    LifeEventTypeID = lifeEventTypes.Single( let => let.Type == "Date of hire").LifeEventTypeID,
                    EmployeeID = employees.Single( e => e.FullName == "Ricky Carmichael").EmployeeID,
                    EventDate = DateTime.Parse("2008-07-04")
                },
                new LifeEvent
                {
                    LifeEventTypeID = lifeEventTypes.Single( let => let.Type == "Marriage").LifeEventTypeID,
                    EmployeeID = employees.Single( e => e.FullName == "Ricky Carmichael").EmployeeID,
                    EventDate = DateTime.Parse("2010-04-12")
                },
                new LifeEvent
                {
                    LifeEventTypeID = lifeEventTypes.Single( let => let.Type == "Gain of other coverage").LifeEventTypeID,
                    EmployeeID = employees.Single( e => e.FullName == "Ricky Carmichael").EmployeeID,
                    EventDate = DateTime.Parse("2011-01-01")
                },
                new LifeEvent
                {
                    LifeEventTypeID = lifeEventTypes.Single( let => let.Type == "Date of hire").LifeEventTypeID,
                    EmployeeID = employees.Single( e => e.FullName == "Ryan Dungey").EmployeeID,
                    EventDate = DateTime.Parse("2015-08-10")
                },
                new LifeEvent
                {
                    LifeEventTypeID = lifeEventTypes.Single( let => let.Type == "Birth/Adoption").LifeEventTypeID,
                    EmployeeID = employees.Single( e => e.FullName == "Ryan Dungey").EmployeeID,
                    EventDate = DateTime.Parse("2016-02-15")
                },
                new LifeEvent
                {
                    LifeEventTypeID = lifeEventTypes.Single( let => let.Type == "Birth/Adoption").LifeEventTypeID,
                    EmployeeID = employees.Single( e => e.FullName == "Ryan Dungey").EmployeeID,
                    EventDate = DateTime.Parse("2017-11-30")
                },
                new LifeEvent
                {
                    LifeEventTypeID = lifeEventTypes.Single( let => let.Type == "Loss of other coverage").LifeEventTypeID,
                    EmployeeID = employees.Single( e => e.FullName == "Ricky Carmichael").EmployeeID,
                    EventDate = DateTime.Parse("2018-06-05")
                }
            };
            foreach (LifeEvent le in lifeEvents)
            {
                context.Add(le);
            }
            context.SaveChanges();
        }
    }
}
