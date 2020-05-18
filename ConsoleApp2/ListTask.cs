using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;
using System.Configuration;

namespace ConsoleApp2
{
    class ListTask
    {
        public ClientContext GetContext()
        {
            string SiteUrl ="https://nishant1999.sharepoint.com/sites/myteamsite";
            string AppId = ConfigurationSettings.AppSettings["ClientId"];
            string secret =ConfigurationSettings.AppSettings["ClientSecret"];
            AuthenticationManager authenticationManager = new AuthenticationManager();
            ClientContext context = authenticationManager.GetAppOnlyAuthenticatedContext(SiteUrl, AppId, secret);
            return context;
        }
        public ListCollection GetAllList()
        {
            ClientContext context = GetContext();
            Web web = context.Web;
            context.Load(web.Lists, lists => lists.Include(list => list.Title, List => List.Id));
            context.ExecuteQuery();
            return web.Lists;
        }

        public void CreateList(string title)
        {
            ClientContext context =GetContext();
            Web web = context.Web;
            ListCreationInformation creationInformation = new ListCreationInformation();
            creationInformation.Title = title;
            creationInformation.TemplateType = (int)ListTemplateType.Contacts;
            List list = web.Lists.Add(creationInformation);
            list.Update();
            context.ExecuteQuery();
        }

        public void DeleteList(string listTitle)
        {
            ClientContext context = GetContext();
            Web web = context.Web;
            List list = web.Lists.GetByTitle(listTitle);
            list.DeleteObject();
            context.ExecuteQuery();
        }

        public ListItemCollection GetListItems(string listTitle)
        {
            ClientContext context = GetContext();
            Web web = context.Web;
            List list = web.Lists.GetByTitle(listTitle);
            CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
            ListItemCollection items = list.GetItems(query);
            context.Load(items);
            context.ExecuteQuery();
            return items;
        }

        public void CreateNewListItem(Contact contact,string listTitle)
        {
            ClientContext context = GetContext();
            Web web = context.Web;
            List list = web.Lists.GetByTitle(listTitle);
            ListItemCreationInformation itemCreationInformation = new ListItemCreationInformation();
            ListItem listItem = list.AddItem(itemCreationInformation);
            listItem["Firstname"] = contact.FirstName;
            listItem["LastName"] = contact.LastName;
            listItem["FullName"] = contact.FullName;
            listItem["EmailAddress"] = contact.EmailAddress;
            listItem["Company"] = contact.Company;
            listItem["JobTitle"] = contact.JobTitle;
            listItem["MobileNumber"] = contact.MobileNumber;
            listItem["City"] = contact.City;
            listItem["Webpage"] = contact.Webpage;
            listItem.Update();
            context.ExecuteQuery();

        }

    }
}
