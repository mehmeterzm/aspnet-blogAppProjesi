using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama", Url = "web-programlama", Color = TagColors.warning},
                        new Tag { Text = "backend", Url="backend", Color= TagColors.info},
                        new Tag { Text = "frontend", Url="frontend", Color = TagColors.success},
                        new Tag { Text = "fullstack",Url="fullstack", Color = TagColors.secondary},
                        new Tag { Text = "php",Url="php", Color= TagColors.primary}
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "fındılı",Name="fındılı ecer",Email="findili@gmail.com",Password="1234567", Image="findili.jpg"},
                        new User { UserName = "bıcır",Name="bıcır ecer",Email="bicir@gmail.com",Password="123456", Image="bicir.jpg"}
                    );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post{
                          Title = "Javascript",
                          Description = "Javascript dersleri",
                          Content = "Javascript dersleri",
                          Url= "javascript",
                          IsActive = true,
                          PublishedOn = DateTime.Now.AddDays(-10),
                          Tags = context.Tags.Take(3).ToList(),
                          Image = "1.jpg",
                          UserId = 1,
                          Comments = new List<Comment> { 
                            new Comment  { Text = "curk", PublishedOn = DateTime.Now.AddDays(-20), UserId = 1 },
                            new Comment  { Text = "cicikussum askım", PublishedOn = DateTime.Now.AddDays(-10), UserId = 2 },
                            }
                        },
                        new Post{
                          Title = "Asp.net core",
                          Description = "ASP.NET dersleri",
                          Content = "Asp.net core dersleri",
                          Url= "asp.net core",
                          IsActive = true,
                          PublishedOn = DateTime.Now.AddDays(-20),
                          Tags = context.Tags.Take(2).ToList(),
                          Image = "2.jpg",
                          UserId = 1
                        },
                        new Post{
                          Title = "boostrap",
                          Description = "boostrap dersleri",
                          Content = "boostrap dersleri",
                          Url= "boostrap",
                          IsActive = true,
                          PublishedOn = DateTime.Now.AddDays(-5),
                          Tags = context.Tags.Take(4).ToList(),
                          Image = "3.jpg",
                          UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}