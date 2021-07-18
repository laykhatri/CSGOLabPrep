using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media;


namespace CSGOLabPrep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private int page = 0;
        static private SolidColorBrush fore = Brushes.Black;
        static private SolidColorBrush back = Brushes.White;
        static private String Source = "";
        public MainWindow()
        {
            InitializeComponent();
            makeScreen();

            try
            {
                initCheck();
            }
            catch(FileNotFoundException e)
            {
                MessageBox.Show("Source File not Found or Corrupted.\nGoto settings Page and Config it.");
            }

        }

        private void initCheck()
        {
            FileStream fs = new FileStream("Source.dat", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            Source = sr.ReadLine();
            tbSource.Text = Source;

            sr.Close();
            fs.Close();
        }

        private void clearScreen()
        {
            switch(page)
            {
                case -2:
                    gridSettings.Visibility = Visibility.Collapsed;

                    break;

                case -1:
                    gridServerLoadout.Visibility = Visibility.Collapsed;
                    break;

                case 0:
                    gridHomePage.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    gridServerCfg.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    gridMapCycle.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void setEleTheme()
        {
            mainWin.Background = back;
            lbSubCont.Foreground = fore;
            lbCDS.Foreground = fore;
            btnLeft.Background = back;
            btnLeft.Foreground = fore;
            btnRight.Background = back;
            btnRight.Foreground = fore;

            switch (page)
            {
                case -2:
                    lbDarkTheme.Background = back;
                    lbDarkTheme.Foreground = fore;
                    lbSource.Background = back;
                    lbSource.Foreground = fore;
                    tbSource.Background = back;
                    tbSource.Foreground = fore;
                    break;
                case -1:
                    btnArmsRace.Background = back;
                    btnCasual.Background = back;
                    btnCompi.Background = back;
                    btnDemoli.Background = back;
                    btnDM.Background = back;
                    btnArmsRace.Foreground = fore;
                    btnCasual.Foreground = fore;
                    btnCompi.Foreground = fore;
                    btnDemoli.Foreground = fore;
                    btnDM.Foreground = fore;
                    break;
                case 0:
                    lbHomeMapCy.Foreground= fore;
                    lbHomeSerCfg.Foreground= fore;
                    lbHomeSerLodOut.Foreground= fore;
                    lbHomeSetting.Foreground= fore;
                    lbHomeMapCy.Background = back;
                    lbHomeSerCfg.Background = back;
                    lbHomeSerLodOut.Background = back;
                    lbHomeSetting.Background = back;
                    break;
                case 1:
                    btnSerCfgLoad.Foreground = fore;
                    btnSerCfgSave.Foreground = fore;
                    lboxSerCfgList.Foreground = fore;
                    lbSerCfgCmdGrp.Foreground = fore;
                    cboxSerCfgCmdGrp.Foreground = fore;
                    lbSerCfgCmd.Foreground = fore;
                    cboxSerCfgCmd.Foreground = fore;
                    lbSerCfgVal.Foreground = fore;
                    tbSerVal.Foreground = fore;
                    btnSerCfgAdd.Foreground = fore;
                    btnSerCfgRemo.Foreground = fore;

                    btnSerCfgLoad.Background = back;
                    btnSerCfgSave.Background = back;
                    lboxSerCfgList.Background = back;
                    lbSerCfgCmdGrp.Background = back;
                    cboxSerCfgCmdGrp.Background = back;
                    lbSerCfgCmd.Background = back;
                    cboxSerCfgCmd.Background = back;
                    lbSerCfgVal.Background = back;
                    tbSerVal.Background = back;
                    btnSerCfgAdd.Background = back;
                    btnSerCfgRemo.Background = back;
                    break;
                case 2:
                    btnMapCyLoad.Foreground = fore;
                    btnMapCySave.Foreground = fore;
                    lbMapCyLoaded.Foreground = fore;
                    cboxMapCyLoaded.Foreground = fore;
                    lbMapCyAvai.Foreground = fore;
                    cboxMapCyAvai.Foreground = fore;
                    btnMapCyAdd.Foreground = fore;
                    btnMapCyRemo.Foreground = fore;

                    btnMapCyLoad.Background = back;
                    btnMapCySave.Background = back;
                    lbMapCyLoaded.Background = back;
                    cboxMapCyLoaded.Background = back;
                    lbMapCyAvai.Background = back;
                    cboxMapCyAvai.Background = back;
                    btnMapCyAdd.Background = back;
                    btnMapCyRemo.Background = back;
                    break;
            }
        }

        private void makeScreen()
        {
            switch(page)
            {
                case -2:
                    gridSettings.Visibility = Visibility.Visible;
                    lbSubCont.Content = "Settings";
                    btnLeft.Visibility = Visibility.Collapsed;
                    btnRight.Content = "Server Loadouts";
                    break;

                case -1:
                    btnLeft.Visibility = Visibility.Visible;
                    btnLeft.Content = "Settings";
                    btnRight.Content = "HomePage";
                    lbSubCont.Content = "Server Loadouts";
                    gridServerLoadout.Visibility = Visibility.Visible;
                    break;
                case 0:
                    btnLeft.Content = "Server";
                    btnRight.Content = "Server Config";
                    lbSubCont.Content = "Welcome to CDS-V2";
                    gridHomePage.Visibility = Visibility.Visible;
                    Homepage_load();
                    break;
                case 1:
                    btnLeft.Content = "HomePage";
                    btnRight.Visibility = Visibility.Visible;
                    btnRight.Content = "Map Cycle";
                    lbSubCont.Content = "Server Cfg Maker";
                    gridServerCfg.Visibility = Visibility.Visible;
                    break;
                case 2:
                    btnRight.Visibility = Visibility.Collapsed;
                    btnLeft.Content = "Server Cfg Maker";
                    lbSubCont.Content = "Map Cycle Maker";
                    gridMapCycle.Visibility = Visibility.Visible;
                    cboxMapCyAvai_Load();
                    break;

            }
            setEleTheme();

        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            clearScreen();
            page--;
            makeScreen();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            clearScreen();
            page++;
            makeScreen();
        }

        private void darkTheme_Change(object sender, RoutedEventArgs e)
        {
            if (cboxDarkTheme.IsChecked == true)
            {
                fore = Brushes.White;
                back = Brushes.Black;
            }
            else
            {
                fore = Brushes.Black;
                back = Brushes.White;
            }

            setEleTheme();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("Source.dat", FileMode.Create, FileAccess.Write);
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            cofd.EnsurePathExists = true;
            cofd.ShowDialog();

            foreach(String str in cofd.FileNames)
            {
                Source = str;
                tbSource.Text = Source;
            }

            
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(Source);
            sw.Flush();

            sw.Close();
            fs.Close();
            
        }

        private void startServer_Click(object sender, RoutedEventArgs e)
        {
            String server = Source + "\\srcds.exe";
            String command = " -game csgo -usercon -tickrate 128";
            Button btn = sender as Button;

            switch(btn.Name)
            {
                case "btnCompi":
                    MessageBox.Show("Compi Server");
                    command += " +game_type 0 +game_mode 1";
                    break;
                case "btnCasual":
                    MessageBox.Show("Casual Server");
                    command += " +game_type 0 +game_mode 0";
                    break;
                case "btnDm":
                    MessageBox.Show("Deathmatch Server");
                    command += " +game_type 1 +game_mode 2";
                    break;
                case "btnArmsRace":
                    MessageBox.Show("Arms Race Server");
                    command += " +game_type 1 +game_mode 0";
                    break;
                case "btnDemoli":
                    MessageBox.Show("Demolition Server");
                    command += " +game_type 1 +game_mode 11";
                    break;
            }

            Process P = new Process();
            P.StartInfo.FileName = server;
            P.StartInfo.Arguments = command;
            P.Start();

            P.WaitForExit();
        }

        private void cboxSerCfg_PreviewText(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == null)
            {
                btnMapCyLoad_Click(sender, null);
            }
            ComboBox cb = new ComboBox();
            foreach(String s in cboxMapCyLoaded.Items)
            {
                cb.Items.Add(s);
            }
            cb.Items.Remove(null);
            cboxMapCyLoaded.Items.Clear();
            foreach(String cbi in cb.Items)
            {
                if(cbi.ToUpper().Contains(e.Text.ToUpper()))
                {
                    cboxMapCyLoaded.Items.Add(cbi);
                    cboxMapCyLoaded.SelectedItem = cbi;
                    break;
                }
            }
            e.Handled = true;
            cb.IsDropDownOpen = true;
        }

        private void cboxMapCyAvai_Load()
        {
            cboxMapCyAvai.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(Source + @"\csgo\maps");
            FileInfo[] files = di.GetFiles("*.bsp");
            String str;

            List<String> mapavi = new List<string>();

            foreach(String s in cboxMapCyLoaded.Items)
            {
                mapavi.Add(s);
            }


            foreach (FileInfo fi in files)
            {
                str = "";
                str += fi.Name;

                str = str.Substring(0, (str.Length - 4));

                if(!mapavi.Contains(str))
                {
                    cboxMapCyAvai.Items.Add(str);
                }
            }

        }

        private void btnMapCyAdd_Click(object sender, RoutedEventArgs e)
        {
            if(cboxMapCyAvai.SelectedIndex != -1)
            {
                String map2Load = cboxMapCyAvai.SelectedItem.ToString();
                cboxMapCyLoaded.Items.Add(map2Load);
                MessageBox.Show("Map added: " + map2Load);
                cboxMapCyAvai_Load();
            }
        }

        private void btnMapCyLoad_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(Source + @"\csgo\mapcycle.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            String str;
            
            do
            {
                str = "";
                str = sr.ReadLine();
                cboxMapCyLoaded.Items.Add(str);
            } while (str != null);

            sr.Close();
            fs.Close();

            cboxMapCyAvai_Load();

        }

        private void btnMapCyRemo_Click(object sender, RoutedEventArgs e)
        {
            if(cboxMapCyLoaded.SelectedIndex != -1)
            {
                String map2Remo = cboxMapCyLoaded.SelectedItem.ToString();
                cboxMapCyLoaded.Items.Remove(map2Remo);
                MessageBox.Show("Map Removed: " + map2Remo);
                cboxMapCyAvai_Load();
            }
        }

        private void btnMapCySave_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(Source + @"\csgo\mapcycle.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            foreach(String s in cboxMapCyLoaded.Items)
            {
                sw.WriteLine(s);

            }
            sw.Close();
            fs.Close();

        }

        private void Homepage_load()
        {
            lbHomeSetting.Content += "\n\nTo set some properties\n of the Application.\n\n1) Theme: Dark and Light\n2) Source: The source folder\n for the Game.";
            lbHomeSerLodOut.Content += "\n\nTo start the server\nin specific game type\n\n For custom configs use\nServer cfg or map cycle\n appropriately.";
            lbHomeSerCfg.Content += "\n\nTo Configure server\n and store the file\n\n Create/Modify the server\n configuration file for \n enhanced experience.";
            lbHomeMapCy.Content += "\n\nTo Configure Map Cycle\n for sequence of maps\n\n Create/Modify the Map cycle\n for automatic next map \n selection by system.";
        }
    }
}
