using ChessGame.database;
using ChessGame.entities;
using ChessGame.views;
using ChessGame.views.administration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ChessGame.viewmodels
{
    class ThemeAdminVM
    {
        private ThemeAdmin themeAdmin;
        private Theme currentTheme;
        private MySQLManager<Theme> themeManager = new MySQLManager<Theme>();

        public ThemeAdminVM(ThemeAdmin themeAdmin)
        {
            this.themeAdmin = themeAdmin;
            InitActions();
            currentTheme = new Theme();
        }

        private void InitActions()
        {
            this.themeAdmin.btnNewPawn.Click += BtnNewPawn_Click;
            this.themeAdmin.btnNewRook.Click += BtnNewRook_Click;
            this.themeAdmin.btnNewKnight.Click += BtnNewKnight_Click;
            this.themeAdmin.btnNewBishop.Click += BtnNewBishop_Click;
            this.themeAdmin.btnNewQueen.Click += BtnNewQueen_Click;
            this.themeAdmin.btnNewKing.Click += BtnNewKing_Click;
            this.themeAdmin.btnOk.Click += BtnOk_Click;
            this.themeAdmin.btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.themeAdmin.NavigationService.GoBack();
        }

        private async void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (currentTheme.PawnFileName != null && currentTheme.RookFileName != null &&
                currentTheme.KnightFileName != null && currentTheme.BishopFileName != null &&
                currentTheme.QueenFileName != null && currentTheme.KingFileName != null)
            {
                currentTheme.Name = this.themeAdmin.txtBName.Text;
                themeManager = new MySQLManager<Theme>();
                await themeManager.Insert(currentTheme);
                this.themeAdmin.NavigationService.GoBack();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Your theme is not complete!", "Theme incomplete",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void BtnNewKing_Click(object sender, RoutedEventArgs e)
        {
            String filename = LoadPieceFile();
            if (filename != null)
            {
                // Update the current theme
                currentTheme.KingFileName = filename;
                this.themeAdmin.txtBKing.Text = filename;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added to your theme!", "No File Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnNewQueen_Click(object sender, RoutedEventArgs e)
        {
            String filename = LoadPieceFile();
            if (filename != null)
            {
                // Update the current theme
                currentTheme.QueenFileName = filename;
                this.themeAdmin.txtBQueen.Text = filename;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added to your theme!", "No File Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnNewBishop_Click(object sender, RoutedEventArgs e)
        {
            String filename = LoadPieceFile();
            if (filename != null)
            {
                // Update the current theme
                currentTheme.BishopFileName = filename;
                this.themeAdmin.txtBBishop.Text = filename;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added to your theme!", "No File Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnNewKnight_Click(object sender, RoutedEventArgs e)
        {
            String filename = LoadPieceFile();
            if (filename != null)
            {
                // Update the current theme
                currentTheme.KnightFileName = filename;
                this.themeAdmin.txtBKnight.Text = filename;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added to your theme!", "No File Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnNewRook_Click(object sender, RoutedEventArgs e)
        {
            String filename = LoadPieceFile();
            if (filename != null)
            {
                // Update the current theme
                currentTheme.RookFileName = filename;
                this.themeAdmin.txtBRook.Text = filename;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added to your theme!", "No File Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnNewPawn_Click(object sender, RoutedEventArgs e)
        {
            String filename = LoadPieceFile();
            if (filename != null)
            {
                // Update the current theme
                currentTheme.PawnFileName = filename;
                this.themeAdmin.txtBPawn.Text = filename;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added to your theme!", "No File Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private String LoadPieceFile()
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
                return newPath;

            }
            return null;
        }
    }
}
