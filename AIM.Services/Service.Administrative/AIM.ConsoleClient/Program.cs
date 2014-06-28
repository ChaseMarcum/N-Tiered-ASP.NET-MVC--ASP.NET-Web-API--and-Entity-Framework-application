using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TrackableEntities.Client;
using AIM.Client.Entities.Models;

namespace AIM.Client.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press Enter to start");
            Console.ReadLine();

            // TODO: Address for Web API service (replace port number)
            const string serviceBaseAddress = "http://localhost:" + "58528" + "/";
            var client = new HttpClient { BaseAddress = new Uri(serviceBaseAddress) };

            // Get users
            Console.WriteLine("Users:");
            IEnumerable<User> users = GetUsers(client);
            if (users == null) return;
            foreach (var u in users)
                PrintUser(u);

            // Keep console open
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }

        private static IEnumerable<User> GetUsers(HttpClient client)
        {
            const string request = "api/User";
            var response = client.GetAsync(request).Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            return result;
        }

        private static void PrintUser(User u)
        {
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12}",
                u.UserId,
                u.FirstName,
                u.MiddleName,
                u.LastName,
                u.Email,
                u.SocialSecurityNumber,
                u.PersonalInfoId,
                u.ApplicantId,
                u.ApplicationId,
                u.EmployeeId,
                u.UserName,
                u.Password,
                u.AspNetUser);
        }
    }
}
