using eTickets.Data.Enums;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Venue
                if (!context.Venues.Any())
                {
                    context.Venues.AddRange(new List<Venue>()
                    {
                        new Venue()
                        {
                            Name = "Stark Arena",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6df6ceSe6yhu25Y06egXxzO4mRXaefyOPMnI9-3smdg&s",
                            Description = "This is the description of the first Venue"
                        },
                        new Venue()
                        {
                            Name = "Venue 2",
                            Logo = "https://pscpinki.org.rs/wp-content/uploads/2016/06/logo-final.png",
                            Description = "This is the description of the first Venue"
                        },
                        new Venue()
                        {
                            Name = "Venue 3",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwur-xv6rrHyOb4-rJpTpdjEOXhWvPw29Zp-IY-fUGLQ&s",
                            Description = "This is the description of the first Venue"
                        },
                        new Venue()
                        {
                            Name = "Venue 4",
                            Logo = "https://storage-profili-poslovi.infostud.com/15491/20220509/c98ba10d24abe991fa3adfa043431d37dc3409093b4e6ed9ddea84b6de55419a",
                            Description = "This is the description of the first Venue"
                        },
                        new Venue()
                        {
                            Name = "Venue 5",
                            Logo = "https://www.mtsdvorana.rs/favicon.jpg",
                            Description = "This is the description of the first Venue"
                        },
                    });
                    context.SaveChanges();
                }
                //Performers
                if (!context.Performers.Any())
                {
                    context.Performers.AddRange(new List<Performer>()
                    {
                        new Performer()
                        {
                            FullName = "Performer 1",
                            Bio = "This is the Bio of the first Performer",
                            ProfilePictureURL = "https://i1.sndcdn.com/artworks-000056714009-zv9qdn-t500x500.jpg"

                        },
                        new Performer()
                        {
                            FullName = "Performer 2",
                            Bio = "This is the Bio of the second Performer",
                            ProfilePictureURL = "https://yt3.googleusercontent.com/--BwRKbqE9LPFHkTWLao5JK7sH_TJKrZMckTgB8FWxWqK5L8vbO91aYkAySzgX0kCqlNMG1823o=s900-c-k-c0x00ffffff-no-rj"
                        },
                        new Performer()
                        {
                            FullName = "Performer 3",
                            Bio = "This is the Bio of the second Performer",
                            ProfilePictureURL = "https://yt3.googleusercontent.com/_BSxUATTVxh1fMIMuXYSLr65Py9PeIicA4aOf5n-GhXmnXjSah9iiTjjUYwujgcvVG6gkWZ74g=s900-c-k-c0x00ffffff-no-rj"
                        },
                        new Performer()
                        {
                            FullName = "Performer 4",
                            Bio = "This is the Bio of the second Performer",
                            ProfilePictureURL = "https://yt3.googleusercontent.com/ytc/AIf8zZQy1Bois1MpWyXgmr5cpDp-cxLYCf8LfNjvvgWpTw=s900-c-k-c0x00ffffff-no-rj"
                        },
                        new Performer()
                        {
                            FullName = "Performer 5",
                            Bio = "This is the Bio of the second Performer",
                            ProfilePictureURL = "https://cdns-images.dzcdn.net/images/artist/b592f5364939a6a7f2c989aa17893d1d/500x500.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Persons
                if (!context.Persons.Any())
                {
                    context.Persons.AddRange(new List<Person>()
                    {
                        new Person()
                        {
                            FullName = "Person 1",
                            Bio = "This is the Bio of the first Performer",
                            ProfilePictureURL = "https://t3.ftcdn.net/jpg/02/43/12/34/360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg"

                        },
                        new Person()
                        {
                            FullName = "Person 2",
                            Bio = "This is the Bio of the second Performer",
                            ProfilePictureURL = "https://t4.ftcdn.net/jpg/03/83/25/83/360_F_383258331_D8imaEMl8Q3lf7EKU2Pi78Cn0R7KkW9o.jpg"
                        },
                        new Person()
                        {
                            FullName = "Person 3",
                            Bio = "This is the Bio of the second Performer",
                            ProfilePictureURL = "https://t4.ftcdn.net/jpg/04/76/04/99/360_F_476049927_ogzHW1dr6WBAg4Vlaz76NThq0k0bF17y.jpg"
                        },
                        new Person()
                        {
                            FullName = "Person 4",
                            Bio = "This is the Bio of the second Performer",
                            ProfilePictureURL = "https://img.freepik.com/free-photo/happy-smiling-handsome-man-against-blue-background_93675-135164.jpg"
                        },
                        new Person()
                        {
                            FullName = "Person 5",
                            Bio = "This is the Bio of the second Performer",
                            ProfilePictureURL = "https://media.istockphoto.com/id/1388645967/photo/pensive-thoughtful-contemplating-caucasian-young-man-thinking-about-future-planning-new.jpg?s=612x612&w=0&k=20&c=Keax_Or9RivnYV_9VoOLjknWQP8iaxYXc4jS9rwBmcc="
                        }
                    });
                    context.SaveChanges();
                }
                //Concert
                if (!context.Concerts.Any())
                {
                    context.Concerts.AddRange(new List<Concert>()
                    {
                        new Concert()
                        {
                            Name = "Humanitarni Koncert za Marka",
                            Description = "Marku je potrebna pomoc",
                            Price = 39.50,
                            ImageURL = "https://gradsubotica.co.rs/wp-content/uploads/2023/11/Koncert-poster-A4-1.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            VenueId = 3,
                            PersonId = 3,
                            ConcertCategory = ConcertCategory.Pop
                        },
                        new Concert()
                        {
                            Name = "Humanitarni Koncert za Peru",
                            Description = "Peri je potrebna pomoc",
                            Price = 29.50,
                            ImageURL = "https://gradsubotica.co.rs/wp-content/uploads/2023/11/Koncert-poster-A4-1.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            VenueId = 1,
                            PersonId = 1,
                            ConcertCategory = ConcertCategory.Rock
                        },
                        new Concert()
                        {
                             Name = "Humanitarni Koncert za Mihajla",
                            Description = "Mihajlu je potrebna pomoc",
                            Price = 39.50,
                            ImageURL = "https://gradsubotica.co.rs/wp-content/uploads/2023/11/Koncert-poster-A4-1.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            VenueId = 4,
                            PersonId = 4,
                            ConcertCategory = ConcertCategory.Folk
                        },
                        new Concert()
                        {
                             Name = "Humanitarni Koncert za Milicu",
                            Description = "Milici je potrebna pomoc",
                            Price = 39.50,
                            ImageURL = "https://gradsubotica.co.rs/wp-content/uploads/2023/11/Koncert-poster-A4-1.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            VenueId = 1,
                            PersonId = 2,
                            ConcertCategory = ConcertCategory.Rep
                        },
                        new Concert()
                        {
                           Name = "Humanitarni Koncert za Janu",
                            Description = "Jani je potrebna pomoc",
                            Price = 39.50,
                            ImageURL = "https://gradsubotica.co.rs/wp-content/uploads/2023/11/Koncert-poster-A4-1.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            VenueId = 1,
                            PersonId = 3,
                            ConcertCategory = ConcertCategory.Narodna
                        },
                        new Concert()
                        {
                            Name = "Humanitarni Koncert za Jovanu",
                            Description = "Jovani je potrebna pomoc",
                            Price = 39.50,
                            ImageURL = "https://gradsubotica.co.rs/wp-content/uploads/2023/11/Koncert-poster-A4-1.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            VenueId = 1,
                            PersonId = 5,
                            ConcertCategory = ConcertCategory.Folk
                        }
                    });
                    context.SaveChanges();
                }
                //Performers & Movies
                if (!context.Performers_Concerts.Any())
                {
                    context.Performers_Concerts.AddRange(new List<Performer_Concert>()
                    {
                        new Performer_Concert()
                        {
                            PerformerId = 1,
                            ConcertId = 1
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 3,
                            ConcertId = 1
                        },

                         new Performer_Concert()
                        {
                            PerformerId = 1,
                            ConcertId = 2
                        },
                         new Performer_Concert()
                        {
                            PerformerId = 4,
                            ConcertId = 2
                        },

                        new Performer_Concert()
                        {
                            PerformerId = 1,
                            ConcertId = 3
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 2,
                            ConcertId = 3
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 5,
                            ConcertId = 3
                        },


                        new Performer_Concert()
                        {
                            PerformerId = 2,
                            ConcertId = 4
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 3,
                            ConcertId = 4
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 4,
                            ConcertId = 4
                        },


                        new Performer_Concert()
                        {
                            PerformerId = 2,
                            ConcertId = 5
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 3,
                            ConcertId = 5
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 4,
                            ConcertId = 5
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 5,
                            ConcertId = 5
                        },


                        new Performer_Concert()
                        {
                            PerformerId = 3,
                            ConcertId = 6
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 4,
                            ConcertId = 6
                        },
                        new Performer_Concert()
                        {
                            PerformerId = 5,
                            ConcertId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}