using ChessGame.database;
using ChessGame.entities;
using ChessGame.views;
using ChessGame.views.administration;
using ChessGame.views.game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChessGame.viewmodels
{
    /// <summary>
    /// Configuration controller
    /// </summary>
    public class MainAdminVM
    {
        private MainAdmin mainAdmin;
        private Map currentMap;
        private MySQLManager<Map> mapManager = new MySQLManager<Map>();
        private Theme currentTheme;
        private MySQLManager<Theme> themeManager = new MySQLManager<Theme>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainAdmin">view</param>
        public MainAdminVM(MainAdmin mainAdmin)
        {
            this.mainAdmin = mainAdmin;

            InitUC();
            InitLUC();
            InitActions();
        }

        /// <summary>
        /// Initialize actions
        /// </summary>
        private void InitActions()
        {
            this.mainAdmin.btnNewMap.Click += BtnNewMap_Click;
            this.mainAdmin.btnNewTheme.Click += BtnNewTheme_Click;
            this.mainAdmin.btnRemoveMap.Click += BtnRemoveMap_Click;
            this.mainAdmin.btnRemoveTheme.Click += BtnRemoveTheme_Click;
            this.mainAdmin.btnOk.Click += BtnOk_Click;
            this.mainAdmin.ListMapUC.ItemsList.SelectionChanged += MapItemsList_SelectionChanged;
            this.mainAdmin.ListThemeUC.ItemsList.SelectionChanged += ThemeItemsList_SelectionChanged;
        }

        private void ThemeItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                currentTheme = (e.AddedItems[0] as Theme);
        }

        private void MapItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                currentMap = (e.AddedItems[0] as Map);
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Window w = (Window)this.mainAdmin.Parent;
            w.Close();
        }

        private async void BtnRemoveTheme_Click(object sender, RoutedEventArgs e)
        {
            if (currentTheme == null)
            {
                MessageBox.Show("No theme selected!");
                return;
            }
            MessageBoxResult mbr = MessageBox.Show("Do you really want to delete this item ?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

            if (mbr == MessageBoxResult.OK)
            {
                await themeManager.Delete(currentTheme);
                this.mainAdmin.ListThemeUC.RemoveItem(currentTheme);
                currentTheme = null;
            }
        }

        private async void BtnRemoveMap_Click(object sender, RoutedEventArgs e)
        {

            if (currentMap == null)
            {
                MessageBox.Show("No map selected!");
                return;
            }
            MessageBoxResult mbr = MessageBox.Show("Do you really want to delete this item ?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

            if (mbr == MessageBoxResult.OK)
            {
                await mapManager.Delete(currentMap);
                this.mainAdmin.ListMapUC.RemoveItem(currentMap);
                currentMap = null;
            }
        }

        private void BtnNewTheme_Click(object sender, RoutedEventArgs e)
        {
            Page themeAdmin = new ThemeAdmin();
            this.mainAdmin.NavigationService.Navigate(themeAdmin);
        }

        private async void BtnNewMap_Click(object sender, RoutedEventArgs e)
        {

            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


             
            if (result == true)
            {
                // Get the selected file name
                string filename = dlg.FileName;
                    
                // Copy the file to local app directory
                string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Images\\";

                if (!Directory.Exists(folderpath))
                    Directory.CreateDirectory(folderpath);

                string newPath = folderpath + System.IO.Path.GetFileName(filename);
                System.IO.File.Copy(filename, newPath, true);
                filename = newPath;

                // Open dialog to get a name for the file
                string name;
                DialogWindow inputDialog = new DialogWindow("Please enter a name for your map:", "new map");
                if (inputDialog.ShowDialog() == true)
                    name = inputDialog.Answer;
                else
                    name = "new map" + DateTime.Now.ToString();

                if (name == "new map")
                    name += DateTime.Now.ToString();

                // Save the new Map
                currentMap = new Map();
                currentMap.FileName = filename;
                currentMap.Name = name;
                MySQLManager<Map> mapManager = new MySQLManager<Map>();
                await mapManager.Insert(currentMap);
                this.mainAdmin.ListMapUC.AddItem(currentMap);
            }
        }
        private async void InitLUC()
        {
            this.mainAdmin.ListMapUC.LoadItems((await mapManager.Get()).ToList());
            this.mainAdmin.ListThemeUC.LoadItems((await themeManager.Get()).ToList());
        }

        private void InitUC()
        {
            
        }

    }
}
