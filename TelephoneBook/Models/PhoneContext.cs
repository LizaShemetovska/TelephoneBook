namespace TelephoneBook.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhoneContext : DbContext
    {
       
        public PhoneContext()
            : base("name=PhoneContext")
        {
            Database.SetInitializer<PhoneContext>(new CustomInit<PhoneContext>());

        }


        public virtual DbSet<Person> People { get; set; }
    }
    /// <summary>
    /// Person DB Model
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string NickName { get; set; }
        public string Avatarka { get; set; }
        public string Telephone { get; set; }





    }
}