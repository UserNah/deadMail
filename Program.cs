using System;
using System.Collections.Generic;
using Microsoft.Exchange.WebServices.Data;
using deadMail.Classes;
using System.Data;

namespace deadMail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vars.output = Connections.ConnectToExchangeServer();
                if (Vars.output == "")
                {
                    if (Vars.exchange == null)
                    {
                        Vars.output = "exchange var is null!";
                    }
                    else
                    {
                        FindFoldersResults findResults1 = Vars.exchange.FindFolders(WellKnownFolderName.Inbox, new FolderView(int.MaxValue) { Traversal = FolderTraversal.Deep });
                        {
                            Folder folder = findResults1.Folders[0];
                            Console.WriteLine(folder.DisplayName);
                            FindItemsResults<Item> findResults = Vars.exchange.FindItems(folder.Id, Vars.filter, new ItemView(600));

                            if (findResults.Items.Count <= 0)
                            {
                                Vars.output = "No messages found!";
                            }
                            else
                            {
                                foreach (Item item in findResults)
                                {
                                    //Get Message
                                    EmailMessage message = EmailMessage.Bind(Vars.exchange, item.Id);
                                    if (message.Body.ToString().Contains("Введенный адрес электронной почты не удалось найти"))
                                    {
                                        getMailLine.getMailLineParse(message.Body.ToString());
                                    }
                                }
                                for (int a = 0; Vars.BodyWithDeadMails.Count > a; a++)
                                {
                                    if (!String.IsNullOrEmpty(Vars.BodyWithDeadMails[a]))
                                    {
                                        // изъять 
                                        string finalMail = MailParse.getMailFromLine(a);

                                        DataTable dtMailDubled = CheckIsDubled.isMailExists(finalMail);
                                        if (dtMailDubled.Rows.Count == 0)
                                        {
                                            Vars.output = InsertMail.saveMailToTable(finalMail);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (Vars.output != "")
                {
                    Log.WriteToLogError("output: " + Vars.output);
                }
                else
                {
                    Console.WriteLine("THE END!");
                    Console.Read();
                }
            }
            catch (Exception ex)
            {
                //Save To Log
                Log.WriteToLogError("Exception: " + ex.ToString());
            }
        }
    }
}
