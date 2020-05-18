using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace ConsoleApp2
{
    class Display
    {
        public static void PrintLists(ListCollection lists)
        {
            foreach (List list in lists)
            {
                Console.WriteLine(list.Title);
            }
            Console.ReadLine();
        }

        public static Contact NewListItem()
        {
            Contact contact = new Contact();
            do
            {
                Console.WriteLine("First Name");
                contact.FirstName = Console.ReadLine();
            } while (contact.FirstName == "");

            Console.WriteLine("Last Name");
            contact.LastName = Console.ReadLine();

           contact.FullName = contact.FirstName.ToString() + contact.LastName.ToString();

            Console.WriteLine("Email Address");
            contact.EmailAddress = Console.ReadLine();

            Console.WriteLine("Company");
            contact.Company = Console.ReadLine();

            Console.WriteLine("Job Title");
            contact.JobTitle = Console.ReadLine();

            Console.WriteLine("Mobile Number");
            contact.MobileNumber = Console.ReadLine();

            Console.WriteLine("City");
            contact.City = Console.ReadLine();

            Console.WriteLine("Web Page");
            contact.Webpage = Console.ReadLine();

            return contact;
        }

        public static void PrintListItems(ListItemCollection listItems)
        {
            Console.WriteLine("First Name   " + "Last Name  " + "Email Address   " + "Company       " + "Job Title   " + "Mobile Number   " + "City      " + "Web Page      \n");
            foreach (ListItem listItem in listItems)
            {
                Console.WriteLine(listItem["Firstname"]+"       "+listItem["LastName"]+"       "+ listItem["EmailAddress"] + "       " + listItem["Company"] + "      " + listItem["JobTitle"] + "     " + listItem["MobileNumber"] + "   " + listItem["City"] + "   " + listItem["Webpage"] + " \n");   
            }
            Console.ReadLine();
        }
    }
}
