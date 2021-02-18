using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.Services
{
    public class InvoiceWatcher
    {
        string path = "D:\\Invoices";
        private readonly MessageBus _messageBus;
        private readonly PageService _navigation;
        public InvoiceWatcher()
        {
            _messageBus = new MessageBus();
        }
        public Invoice Watch()
        {

            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = path;

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                // Only watch text files.
                

                // Add event handlers.
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                //watcher.Renamed += OnRenamed;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
            }
            return new Invoice();
        }

        private async void OnChanged(object source, FileSystemEventArgs e)
        {
            Invoice invoice = new Invoice()
            {
                Number = "1488",
                Date = DateTime.Now,
                Department = "СТР",
                Summ = 1488
            };
            await _messageBus.SendTo<object>(new InvoiceMessage(invoice));
        }
    }
    
}
