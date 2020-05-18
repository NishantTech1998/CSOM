using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ListTask listTask = new ListTask();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("My Team Site");
                Console.WriteLine("1.Get All List\n2.Create a new contact list\n3.Delete a list\n4.Add items in list\n5.Print All list Item\n6.Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ListCollection lists = listTask.GetAllList();
                        Display.PrintLists(lists);
                        break;

                    case "2": Console.WriteLine("Enter Title");
                        string title = Console.ReadLine();
                        listTask.CreateList(title);
                        break;

                    case "3":
                        Console.WriteLine("Enter Title");
                        string listTitle = Console.ReadLine();
                        listTask.DeleteList(listTitle);
                        break;

                    case "4":
                        Console.WriteLine("Enter Title");
                        string listName = Console.ReadLine();
                        Contact contact = Display.NewListItem();
                        listTask.CreateNewListItem(contact,listName);
                        break;

                    case "5":
                        Console.WriteLine("Enter Title");
                        string lName = Console.ReadLine();
                        ListItemCollection listItems= listTask.GetListItems(lName);
                        Display.PrintListItems(listItems);
                        break;

                    case "6":Environment.Exit(0);
                        break;

                    default:continue;
                }
            }
        }
    }
}
