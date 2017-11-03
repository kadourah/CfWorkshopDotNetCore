using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CfWorkshopDotNetCore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CfWorkshopContext(
                serviceProvider.GetRequiredService<DbContextOptions<CfWorkshopContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Note.Any())
                {
                    return;
                }

                context.Note.AddRange(
                    new Note
                    {
                        Text = "Note #1",
                        Created = DateTime.Now
                    },
                    new Note
                    {
                        Text = "Note #2",
                        Created = DateTime.Now
                    },
                    new Note
                    {
                        Text = "Note #3",
                        Created = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
