using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
               string option = "";
               string FormatAccountsHeader = String.Format("{0, 10} {1, 10} {2,10} {3, 10}", "Number", "Balance", "Label", "Owner");
            bool bajs=true;
            while (bajs) {
                var accs = ReadAccounts();
                Console.WriteLine("-------Menu-------");
                Console.WriteLine("1: View accounts");
                Console.WriteLine("2: View account by number");
                Console.WriteLine("3: Exit");
                option = Console.ReadLine();
                Console.WriteLine("------------------");
                switch (option) {
                    case "1":
                    Console.WriteLine(FormatAccountsHeader);
                    Console.WriteLine("_____________________________________________");    
                    foreach(var acc in accs) {
                        string FormatAccountsValue = String.Format("{0, 10} {1, 10} {2, 10} {3, 10}", acc.Number, acc.Balance, acc.Label, acc.Owner);
                        Console.WriteLine(FormatAccountsValue);
                        Console.WriteLine("---------------------------------------------"); 
                    }
                    break;

                    case "2":
                    var nr = 0;
                    do {
                        Console.WriteLine("Insert Account Number!:");
                        string input = Console.ReadLine();
                        nr = Int32.Parse(input);
                    } while (0 > nr || nr >= accs.Count());
                    Console.WriteLine(FormatAccountsHeader);
                    Console.WriteLine("_____________________________________________"); 
                    string FormatAccount = String.Format("{0, 10} {1, 10} {2, 10} {3, 10}", accs.ElementAt(nr).Number, accs.ElementAt(nr).Balance, accs.ElementAt(nr).Label, accs.ElementAt(nr).Owner);
                    Console.WriteLine(FormatAccount);
                    break;
                      
                            case "3":
                            bajs=false;
                            break;


                            }
                            

 
        }

        static IEnumerable<Account> ReadAccounts()
        {
            String file = "data/account.json";

            using (StreamReader r = new StreamReader(file))
            {
                string data = r.ReadToEnd();
                // Console.WriteLine(data);

                var json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    }
                );

                //Console.WriteLine(json[0]);
                return json;
            }
        }
        
        

    }
     public class Account
    {
        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }
        
        public override string ToString() {
            return JsonSerializer.Serialize<Account>(this);
        }
    }
}
}