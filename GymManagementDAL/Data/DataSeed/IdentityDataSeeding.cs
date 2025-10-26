﻿using GymManagementDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GymManagementDAL.Data.DataSeed
{
    public static class IdentityDataSeeding
    {
        public static bool SeedData(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            try
            {
                bool HasUsers = userManager.Users.Any();
                bool HasRoles = roleManager.Roles.Any();

                if (HasUsers && HasRoles) return false;

                if (!HasRoles)
                {
                    var Roles = new List<IdentityRole>()
                    {
                        new IdentityRole() { Name = "SuperAdmin" },
                        new IdentityRole() { Name = "Admin" }
                    };

                    foreach (var Role in Roles)
                    {
                        if (!roleManager.RoleExistsAsync(Role.Name!).Result)
                        {
                            roleManager.CreateAsync(Role).Wait();
                        }
                    }
                }

                if (!HasUsers)
                {
                    var MainAdmin = new ApplicationUser()
                    {
                        FirstName = "Aliaa",
                        LastName = "Tarek",
                        UserName = "AliaaTarek",
                        Email = "Aliaatarek@gmail.com",
                        PhoneNumber = "01123652635"
                    };
                    userManager.CreateAsync(MainAdmin, "P@ssw0rd").Wait();
                    // Changed: AddToRoleAsync takes the user object, not ID
                    userManager.AddToRoleAsync(MainAdmin, "SuperAdmin").Wait();

                    var Admin01 = new ApplicationUser()
                    {
                        FirstName = "Omar",
                        LastName = "Mohamed",
                        UserName = "OmarMohamed",
                        Email = "OmarMohamed@gmail.com",
                        PhoneNumber = "01232589652"
                    };
                    userManager.CreateAsync(Admin01, "P@ssw0rd").Wait();
                    // Changed: AddToRoleAsync takes the user object, not ID
                    userManager.AddToRoleAsync(Admin01, "Admin").Wait();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding Failed : {ex}");
                return false;
            }
        }
    }
}