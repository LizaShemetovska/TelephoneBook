using System;
using System.Data.Entity;

namespace TelephoneBook.Models
{
    internal class CustomInit<T> : DropCreateDatabaseIfModelChanges<PhoneContext>
    {
        protected override void Seed(PhoneContext context)
        {
            base.Seed(context);
            context.People.Add(new Person
            {
                FirstName = "Petro",
                LastName = "Petrenko",
                BirthDay= new DateTime( 1981,10,12) ,
             NickName ="Petya123",
             Telephone="0985697800"
            });
            context.People.Add(new Person

            {
                FirstName = "Ivan",
                LastName = "Ivanenko",
                BirthDay = new DateTime(1999, 01, 02),
                NickName = "Ivan123",
                Telephone = "0961597800"
            });
          
            context.SaveChanges();
        }
    }
}