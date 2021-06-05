using Microsoft.EntityFrameworkCore;
using QMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Database
{
    public static class CreateUserRoleData
    { 
        #region public Method(s)
        public static void SeedRole(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .HasData(
                    new Role { ID = 1, Name = "Administrator", Description = "Administrator", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new Role { ID = 2, Name = "QA", Description = "QA", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new Role { ID = 3, Name = "TL", Description = "TL", Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new Role { ID = 4, Name = "TM", Description = "TM", Active = true,  DateCreated = DateTimeOffset.Now, CreatedByID = 1 }
                );
        }
        public static void SeedUser(ModelBuilder builder)
        {
            Guid key1 = Guid.Parse("A891CEC8-0808-4CDE-A42E-495634B0AF03");
            Guid key2 = Guid.Parse("72B5A528-6838-4DC2-A889-30A47DB1CE07");
            Guid key3 = Guid.Parse("73D4794B-76DB-4DDD-816C-E8E25F89E756");
            Guid key4 = Guid.Parse("480DD49E-7BB8-4DF1-BD16-C9592F3BE5BE");
            Guid key5 = Guid.Parse("6B8538A5-5163-4B0D-902F-24B59CC00375");
            Guid key6 = Guid.Parse("EDC4150F-2723-4A38-BC59-F6FD1737D236");
            Guid key7 = Guid.Parse("D5FA1BED-9A40-45F9-8E09-BC2B103E9BE6");
            Guid key8 = Guid.Parse("4BD2EF61-0FB8-4FA7-A3B9-39C63060336C");
            Guid key9 = Guid.Parse("F472A092-DC4C-4FA3-90D9-5A86EEA5AA38");
            Guid key0 = Guid.Parse("295BFAD2-997F-40AF-A50C-B2B76E558A5E");
            Guid key10 = Guid.Parse("74E8DB5D-E9C9-47A1-B793-BA6CCB09C404");
            Guid key11 = Guid.Parse("A0215166-0718-4D4F-957C-7A104B533884");
            Guid key12 = Guid.Parse("A86CD837-1C50-49DE-82BD-93203717FE3E");
            Guid key13 = Guid.Parse("B89E8918-0952-4546-883D-EFB54095619E");
            Guid key14 = Guid.Parse("C1007D8C-3D00-4264-B93E-D9E04E420197");
            //NOTE: Password == pasok12345
            builder.Entity<User>()
                .HasData(
                    new User { ID = 1, Username = "1604993", Email = "mcnielv@gmail.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "McNiel", LastName = "Viray", MiddleName = "N", Key = key1, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now},
                    new User { ID = 2, Username = "1604991", Email = "pacquito.diaz@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Pacquito", LastName = "Diaz", MiddleName = "B", Key = key2, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 3, Username = "1604992", Email = "romy.diaz@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Romy", LastName = "Diaz", MiddleName = "B", Key = key3, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 4, Username = "1604990", Email = "vic.diaz@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Vic", LastName = "Diaz", MiddleName = "C", Key = key4, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 5, Username = "1604994", Email = "dick.israel@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Dick", LastName = "Israel", MiddleName = "D", Key = key5, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 6, Username = "1604995", Email = "rex.cortez@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Rex", LastName = "Cortez", MiddleName = "E", Key = key6, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 7, Username = "1604996", Email = "ace.vergel@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Jimmy", LastName = "Santos", MiddleName = "F", Key = key7, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 8, Username = "1604997", Email = "jimmy.santos@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Ace", LastName = "Vergel", MiddleName = "H", Key = key8, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 9, Username = "1604998", Email = "max.alvarado@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Max", LastName = "Alvarado", MiddleName = "G", Key = key9, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 10, Username = "1604999", Email = "charlie.davao@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Charlie", LastName = "Davao", MiddleName = "G", Key = key0, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 11, Username = "1605000", Email = "kitty.chicha@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Kitty Chicha", LastName = "Amatayakul", MiddleName = "Z", Key = key10, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 12, Username = "1605001", Email = "evag.yariv@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Evag", LastName = "Yariv", MiddleName = "D", Key = key11, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 13, Username = "1605002", Email = "bella.flores@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Bella", LastName = "Flores", MiddleName = "S", Key = key12, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 14, Username = "1605003", Email = "roel.bernal@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Roel", LastName = "Bernal", MiddleName = "V", Key = key13, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now },
                    new User { ID = 15, Username = "1605004", Email = "ohdet.khan@email.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "Ohdet", LastName = "Khan", MiddleName = "R", Key = key14, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now }
                );
        }
        public static void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<UserRole>()
                .HasData(
                    new UserRole { ID = 1, UserID = 1, RoleID = 1, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 2, UserID = 2, RoleID = 4, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 3, UserID = 3, RoleID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 4, UserID = 4, RoleID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 5, UserID = 5, RoleID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 6, UserID = 6, RoleID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 7, UserID = 7, RoleID = 4, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 8, UserID = 8, RoleID = 4, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 9, UserID = 9, RoleID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 10, UserID = 10, RoleID = 3, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 11, UserID = 11, RoleID = 4, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 12, UserID = 12, RoleID = 4, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 13, UserID = 13, RoleID = 4, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 14, UserID = 14, RoleID = 4, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 },
                    new UserRole { ID = 15, UserID = 15, RoleID = 2, Active = true, DateCreated = DateTimeOffset.Now, CreatedByID = 1 }
                );
        }

        #endregion
    }
}
