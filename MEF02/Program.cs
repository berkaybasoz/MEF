using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;

namespace MEF02
{
      class Program
    {
        private static PluginFileWatcher watcher;
        private static DirectoryCatalog catalog;
        private static CompositionContainer container;

        [STAThread]
        static void Main(string[] args)
        {
            //AssemblyCatalog catalog = new AssemblyCatalog(Assembly.GetCallingAssembly());
            //yada
            // TypeCatalog catalog = new TypeCatalog(typeof(MenuSystem), typeof(SizeUpPlugin), typeof(SizeDownPlugin), typeof(ColorRedPlugin));
            //yada
            catalog = new DirectoryCatalog(PluginDirectoryInfo.DirectoryName, PluginDirectoryInfo.Filter);
            catalog.Changed += catalog_Changed;
             
            ListenPluginDirectory();

            container = new CompositionContainer(catalog);

            FrmPlugin form = container.GetExportedValue<FrmPlugin>();


            #region Comment
            //Task timer = Task.Factory.StartNew(new Action(() =>
            //{
            //    System.Threading.Thread.Sleep(5000);
            //    catalog.Refresh();
            //}));

            //var sizePlugins = container.GetExportedValues<IMenuPlugin>("Size");

            //          Label lbl = new Label() { Font = new System.Drawing.Font("Arial", 14.0f) };

            //          foreach (var p in sizePlugins)
            //          {
            //              p.ChangeLabel(lbl);
            //          }

            //          var colorPlugins = container.GetExports<IMenuPlugin, IMenuPluginMetadata>("Color");
            //          var redPlugin = colorPlugins.First(c => c.Metadata.MenuText.Equals("Red"));

            //          redPlugin.Value.ChangeLabel(lbl);




            
            #endregion

            form.ShowDialog();

        }

        private static void catalog_Changed(object sender, ComposablePartCatalogChangeEventArgs e)
        {
            catalog.Refresh();
        }

        private static void ListenPluginDirectory()
        {
            watcher = new PluginFileWatcher(PluginDirectoryInfo.DirectoryName);
            watcher.OnUpdate += watcher_OnUpdate;
            watcher.Start();
        }

        private static void watcher_OnUpdate(object sender, FileSystemEventArgs eventArgs)
        {
            catalog.Refresh();
        }

    }


}
