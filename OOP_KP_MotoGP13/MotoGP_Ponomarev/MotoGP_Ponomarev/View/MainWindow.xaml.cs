using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MotoGP_Ponomarev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new AppViewModel();
            InitializeComponent();

        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #region Delete Window
        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            object tag = ((Button)e.OriginalSource).Tag;
            Guid a = (Guid)tag;
            for (int i = 0; i < AppViewModel.MotoGPCollectionVM.Count; i++)
            {
                if (a == AppViewModel.MotoGPCollectionVM[i].Guid)
                {
                    LB.SelectedItem = AppViewModel.MotoGPCollectionVM[i];
                }
            }
            LB.Items.Refresh();

        }
        #endregion
        #region Update Window
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            PersonalInform.Visibility = Visibility.Visible;
            ShadowOverlay.Visibility = Visibility.Visible;
            MainPanel.IsEnabled = false;
            LeftMenu.IsEnabled = false;
            UpdateAcceptPIButton.Visibility = Visibility.Visible;
            UpdateCancelPIButton.Visibility = Visibility.Visible;
            object tag = ((Button)e.OriginalSource).Tag;
            Guid a = (Guid)tag;
            for (int i = 0; i < AppViewModel.MotoGPCollectionVM.Count; i++)
            {
                if (a == AppViewModel.MotoGPCollectionVM[i].Guid)
                {
                    LB.SelectedItem = AppViewModel.MotoGPCollectionVM[i];
                    
                    PilotNameTextBox.Text = AppViewModel.MotoGPCollectionVM[i].PilotName;
                    NameTeamTextBox.Text = AppViewModel.MotoGPCollectionVM[i].TeamName;
                    CountryTextBox.Text = AppViewModel.MotoGPCollectionVM[i].Country;
                    PilotNumberTextBox.Text = Convert.ToString(AppViewModel.MotoGPCollectionVM[i].PilotNumber);
                    ModelMotoTextBox.Text = AppViewModel.MotoGPCollectionVM[i].MotoModel;

                    string[] Str;

                    Str = AppViewModel.MotoGPCollectionVM[i].pilotInformGP[0].PointGP.Split('/');
                    PointKTextBox.Text = Str[0];
                    PlaceKTextBox.Text = Str[1];

                    Str = AppViewModel.MotoGPCollectionVM[i].pilotInformGP[1].PointGP.Split('/');
                    PointATextBox.Text = Str[0];
                    PlaceATextBox.Text = Str[1];

                    Str = AppViewModel.MotoGPCollectionVM[i].pilotInformGP[2].PointGP.Split('/');
                    PointAmericTextBox.Text = Str[0];
                    PlaceAmericTextBox.Text = Str[1];

                    Str = AppViewModel.MotoGPCollectionVM[i].pilotInformGP[3].PointGP.Split('/');
                    PointSpainTextBox.Text = Str[0];
                    PlaceSpainTextBox.Text = Str[1];

                    Str = AppViewModel.MotoGPCollectionVM[i].pilotInformGP[4].PointGP.Split('/');
                    PointFranceTextBox.Text = Str[0];
                    PlaceFranceTextBox.Text = Str[1];
                }
            }
            LB.Items.Refresh();
        }
        private void UpdateAcceptWindow_Click(object sender, RoutedEventArgs e)
        {
            
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].PilotName = PilotNameTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].TeamName = NameTeamTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].Country = CountryTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].PilotNumber = Convert.ToInt32(PilotNumberTextBox.Text);
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].MotoModel = ModelMotoTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].pilotInformGP[0].PointGP = PointKTextBox.Text + "/" + PlaceKTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].pilotInformGP[1].PointGP = PointATextBox.Text + "/" + PlaceATextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].pilotInformGP[2].PointGP = PointAmericTextBox.Text + "/" + PlaceAmericTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].pilotInformGP[3].PointGP = PointSpainTextBox.Text + "/" + PlaceSpainTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].pilotInformGP[4].PointGP = PointFranceTextBox.Text + "/" + PlaceFranceTextBox.Text;
            ShadowOverlay.Visibility = Visibility.Collapsed;
            MainPanel.IsEnabled = true;
            LeftMenu.IsEnabled = true;
            GPResults.Visibility = Visibility.Collapsed;
            PersonalInform.Visibility = Visibility.Collapsed;
            UpdateAcceptPIButton.Visibility = Visibility.Collapsed;
            UpdateCancelPIButton.Visibility = Visibility.Collapsed;
            UpdateAcceptGPButton.Visibility = Visibility.Collapsed;
            UpdateCancelGPButton.Visibility = Visibility.Collapsed;
            LB.Items.Refresh();
            GP.Items.Refresh();
            Zeroing();

            
        }
        private void UpdateCancelWindow_Click(object sender, RoutedEventArgs e)
        {
            
            ShadowOverlay.Visibility = Visibility.Collapsed;
            MainPanel.IsEnabled = true;
            LeftMenu.IsEnabled = true;
            GPResults.Visibility = Visibility.Collapsed;
            PersonalInform.Visibility = Visibility.Collapsed;
            UpdateAcceptPIButton.Visibility = Visibility.Collapsed;
            UpdateCancelPIButton.Visibility = Visibility.Collapsed;
            UpdateAcceptGPButton.Visibility = Visibility.Collapsed;
            UpdateCancelGPButton.Visibility = Visibility.Collapsed;
            Zeroing();
            LB.Items.Refresh();

        }
        #endregion

        #region Add Window
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            PersonalInform.Visibility = Visibility.Visible;
            ShadowOverlay.Visibility = Visibility.Visible;
            MainPanel.IsEnabled = false;
            LeftMenu.IsEnabled = false;
            AddAcceptPIButton.Visibility = Visibility.Visible;
            AddCancelPIButton.Visibility = Visibility.Visible;
            AppViewModel.MotoGPCollectionVM.Add(new MotoGP());
            LB.SelectedItem = AppViewModel.MotoGPCollectionVM[AppViewModel.MotoGPCollectionVM.Count - 1];
            LB.Items.Refresh();
        }
       
       

        private void AddAcceptWindow_Click(object sender, RoutedEventArgs e)
        {
            List<GrandPrix> GPL = new List<GrandPrix>();

            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].PilotName = PilotNameTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].TeamName = NameTeamTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].Country = CountryTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].PilotNumber = Convert.ToInt32(PilotNumberTextBox.Text);
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].MotoModel = ModelMotoTextBox.Text;
            AppViewModel.MotoGPCollectionVM[LB.SelectedIndex].pilotInformGP = GPL;

            GPL.Add(new GrandPrix
            {
                NameGrandPrix = "Grand Prix Qatar",
                NameRaceGP = "Losail",
                PointGP = PointKTextBox.Text + "/" + PlaceKTextBox.Text,
            });
            GPL.Add(new GrandPrix
            {
                NameGrandPrix = "Grand Prix Argentinian",
                NameRaceGP = "Termas de Rio Hondo",
                PointGP = PointATextBox.Text + "/" + PlaceATextBox.Text,
            });
            GPL.Add(new GrandPrix
            {
                NameGrandPrix = "Grand Prix German",
                NameRaceGP = "Sachsenring",
                PointGP = PointAmericTextBox.Text + "/" + PlaceAmericTextBox.Text,
            });
            GPL.Add(new GrandPrix
            {
                NameGrandPrix = "Grand Prix Spanish",
                NameRaceGP = "Circuito de Jerez",
                PointGP = PointSpainTextBox.Text + "/" + PlaceSpainTextBox.Text,
            });
            GPL.Add(new GrandPrix
            {
                NameGrandPrix = "Grand Prix French",
                NameRaceGP = "Le Mans Circuit Bugatti",
                PointGP = PointFranceTextBox.Text + "/" + PlaceFranceTextBox.Text,
            });
            ShadowOverlay.Visibility = Visibility.Collapsed;
            MainPanel.IsEnabled = true;
            LeftMenu.IsEnabled = true;
            GPResults.Visibility = Visibility.Collapsed;
            PersonalInform.Visibility = Visibility.Collapsed;
            AddAcceptPIButton.Visibility = Visibility.Collapsed;
            AddCancelPIButton.Visibility = Visibility.Collapsed;
            AddAcceptGPButton.Visibility = Visibility.Collapsed;
            AddCancelGPButton.Visibility = Visibility.Collapsed;
            Zeroing();
            LB.Items.Refresh();
        }
        private void AddCancelWindow_Click(object sender, RoutedEventArgs e)
        {
            ShadowOverlay.Visibility = Visibility.Collapsed;
            MainPanel.IsEnabled = true;
            LeftMenu.IsEnabled = true;
            GPResults.Visibility = Visibility.Collapsed;
            PersonalInform.Visibility = Visibility.Collapsed;

            AddAcceptPIButton.Visibility = Visibility.Collapsed;
            AddCancelPIButton.Visibility = Visibility.Collapsed;
            AddAcceptGPButton.Visibility = Visibility.Collapsed;
            AddCancelGPButton.Visibility = Visibility.Collapsed;
            if (AppViewModel.MotoGPCollectionVM[AppViewModel.MotoGPCollectionVM.Count-1].TeamName == null) //deleting an empty object
            {
                AppViewModel.MotoGPCollectionVM.RemoveAt(AppViewModel.MotoGPCollectionVM.Count - 1);
            }
            Zeroing();
            LB.Items.Refresh();
        }
        #endregion

        #region Common for Add and Update windows
        private void Zeroing()
        {
            PilotNameTextBox.Text = null;
            NameTeamTextBox.Text = null;
            CountryTextBox.Text = null;
            PilotNumberTextBox.Text = null;
            ModelMotoTextBox.Text = null;
            PointKTextBox.Text = null;
            PlaceKTextBox.Text = null;
            PointATextBox.Text = null;
            PlaceATextBox.Text = null;
            PointAmericTextBox.Text = null;
            PlaceAmericTextBox.Text = null;
            PointSpainTextBox.Text = null;
            PlaceSpainTextBox.Text = null;
            PointFranceTextBox.Text = null;
            PlaceFranceTextBox.Text = null;
        }
        private void AddUpdateWindowTextBox_TextChanged(object sender, TextChangedEventArgs e) //event is common for Add Window and Update Window
        {
            if (PilotNameTextBox.Text != "" & NameTeamTextBox.Text != "" & CountryTextBox.Text != "" & PilotNumberTextBox.Text != "" & ModelMotoTextBox.Text != "" & PointKTextBox.Text != "" & PlaceKTextBox.Text != "" &
                PointATextBox.Text != "" & PlaceATextBox.Text != "" & PointAmericTextBox.Text != "" & PlaceAmericTextBox.Text != "" & PointSpainTextBox.Text != "" & PlaceSpainTextBox.Text != "" & PointFranceTextBox.Text != ""
                & PlaceFranceTextBox.Text != "")
            {
                UpdateAcceptPIButton.IsEnabled = true;
                UpdateAcceptGPButton.IsEnabled = true;
                AddAcceptPIButton.IsEnabled = true;
                AddAcceptGPButton.IsEnabled = true;
            }

            else
            {
                UpdateAcceptPIButton.IsEnabled = false;
                UpdateAcceptGPButton.IsEnabled = false;
                AddAcceptPIButton.IsEnabled = false;
                AddAcceptGPButton.IsEnabled = false;
            }
        }
        private void TransitionToGPResultsButton_Click(object sender, RoutedEventArgs e) //too and for Update Window
        {
            if (LB.SelectedItem == AppViewModel.MotoGPCollectionVM[AppViewModel.MotoGPCollectionVM.Count - 1])
            {
                AddAcceptGPButton.Visibility = Visibility.Visible;
                AddCancelGPButton.Visibility = Visibility.Visible;
                AddAcceptPIButton.Visibility = Visibility.Collapsed;
                AddCancelPIButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                UpdateAcceptGPButton.Visibility = Visibility.Visible;
                UpdateCancelGPButton.Visibility = Visibility.Visible;
                UpdateAcceptPIButton.Visibility = Visibility.Collapsed;
                UpdateCancelPIButton.Visibility = Visibility.Collapsed;
            }
            GPResults.Visibility = Visibility.Visible;
            PersonalInform.Visibility = Visibility.Hidden;
            LB.Items.Refresh();
        }
        private void TransitionToPIButton_Click(object sender, RoutedEventArgs e) //too and for Update Window 
        {
            if (LB.SelectedItem == AppViewModel.MotoGPCollectionVM[AppViewModel.MotoGPCollectionVM.Count - 1])
            {
                AddAcceptGPButton.Visibility = Visibility.Collapsed;
                AddCancelGPButton.Visibility = Visibility.Collapsed;
                AddAcceptPIButton.Visibility = Visibility.Visible;
                AddCancelPIButton.Visibility = Visibility.Visible;
            }
            else
            {
                UpdateAcceptGPButton.Visibility = Visibility.Collapsed;
                UpdateCancelGPButton.Visibility = Visibility.Collapsed;
                UpdateAcceptPIButton.Visibility = Visibility.Visible;
                UpdateCancelPIButton.Visibility = Visibility.Visible;
            }
            GPResults.Visibility = Visibility.Hidden;
            PersonalInform.Visibility = Visibility.Visible;
            LB.Items.Refresh();
        }
        #endregion


        #region Grand Prix Window
        private void ButtonResultsGP_Click(object sender, RoutedEventArgs e)
        {
            GPPlace.Visibility = Visibility;
            ShadowOverlay.Visibility = Visibility.Visible;
            LBPlace.IsEnabled = false;
            LeftMenu.IsEnabled = false;
            ButtonRight.IsEnabled = true;
            List<GrandPrix> GPL = new List<GrandPrix>();

            object tag = ((Button)e.OriginalSource).Tag;
            Guid a = (Guid)tag;
            for (int i = 0; i < AppViewModel.MotoGPCollectionVM.Count; i++)
            {
                if (a == AppViewModel.MotoGPCollectionVM[i].Guid)
                {
                    GPL = AppViewModel.MotoGPCollectionVM[i].pilotInformGP;
                    GP.ItemsSource = GPL;
                }
            }
            ButtonLeft.IsEnabled = false;
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            if (GP.Items.CurrentPosition > 0)
            {
                GP.ScrollIntoView(GP.Items[GP.Items.CurrentPosition - 1]);
                GP.Items.MoveCurrentTo(GP.Items[GP.Items.CurrentPosition - 1]);
                ButtonRight.IsEnabled = true;
            }
            if (GP.Items.CurrentPosition == 0)
                ButtonLeft.IsEnabled = false;
        }

        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            if (GP.Items.CurrentPosition < 4)
            {
                GP.ScrollIntoView(GP.Items[GP.Items.CurrentPosition + 1]);
                GP.Items.MoveCurrentTo(GP.Items[GP.Items.CurrentPosition + 1]);
                ButtonLeft.IsEnabled = true;
            }
            if (GP.Items.CurrentPosition == 4)
                ButtonRight.IsEnabled = false;
        }

        private void ButtonCancelGP_Click(object sender, RoutedEventArgs e)
        {
            GPPlace.Visibility = Visibility.Hidden;
            ShadowOverlay.Visibility = Visibility.Collapsed;
            LBPlace.IsEnabled = true;
            GP.ScrollIntoView(GP.Items[0]);
            GP.Items.MoveCurrentTo(GP.Items[0]);
            LeftMenu.IsEnabled = true;
        }
        #endregion

        #region Left Menu
        private void ListViewLeftMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemMemoryRepository":
                    StartScreen.Visibility = Visibility.Collapsed;
                    MainPanel.Visibility = Visibility.Visible;
                    ButtonAdd.Visibility = Visibility.Visible;
                    Contacts.Visibility = Visibility.Collapsed;
                    AppViewModel.MemoryRepositoryCreate();
                    LB.Items.Refresh();
                    break;
                case "ItemTextRepository":
                    StartScreen.Visibility = Visibility.Collapsed;
                    MainPanel.Visibility = Visibility.Visible;
                    ButtonAdd.Visibility = Visibility.Visible;
                    Contacts.Visibility = Visibility.Collapsed;
                    AppViewModel.TextRepositoryCreate();
                    LB.Items.Refresh();
                    break;
                case "ItemBinRepository":
                    StartScreen.Visibility = Visibility.Collapsed;
                    ButtonAdd.Visibility = Visibility.Visible;
                    MainPanel.Visibility = Visibility.Visible;
                    AppViewModel.BinaryRepositoryCreate();
                    Contacts.Visibility = Visibility.Collapsed;
                    LB.Items.Refresh();
                    break;
                case "ItemAuthor":
                    MainPanel.Visibility = Visibility.Collapsed;
                    StartScreen.Visibility = Visibility.Collapsed;
                    Contacts.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
        private void ButtonOpenLeftMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseLeftMenu.Visibility = Visibility.Visible;
            ButtonOpenLeftMenu.Visibility = Visibility.Collapsed;
            Contacts.IsEnabled = false;
            MainPanel.IsEnabled = false;
        }

        private void ButtonCloseLeftMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseLeftMenu.Visibility = Visibility.Collapsed;
            ButtonOpenLeftMenu.Visibility = Visibility.Visible;
            Contacts.IsEnabled = true;
            MainPanel.IsEnabled = true;
        }

        #endregion

        private void LinkedinButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/%D0%BC%D0%B0%D0%BA%D1%81%D0%B8%D0%BC-%D0%BF%D0%BE%D0%BD%D0%BE%D0%BC%D0%B0%D1%80%D1%91%D0%B2-085896168/");
        }
        

        private void GithubPIButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
