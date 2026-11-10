using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CreationDynamique
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = CreerExercice1();
        }

        private Grid CreerExercice1()
        {
            Grid grdMain = new Grid();
            grdMain.Margin = new Thickness(20);

            for (int i = 0; i < 3; i++)
            {
                grdMain.ColumnDefinitions.Add(new ColumnDefinition());
                grdMain.RowDefinitions.Add(new RowDefinition());
            }

            TextBlock txtTitre = new TextBlock();
            txtTitre.Text = "Création dynamique d'objets";
            txtTitre.FontFamily = new FontFamily("Segoe UI");
            txtTitre.FontSize = 28;
            txtTitre.FontWeight = FontWeights.Bold;
            txtTitre.Foreground = Brushes.DarkBlue;
            txtTitre.Background = Brushes.LightBlue;
            txtTitre.TextWrapping = TextWrapping.Wrap;
            txtTitre.TextAlignment = TextAlignment.Center;
            txtTitre.Padding = new Thickness(15);
            Grid.SetRow(txtTitre, 0);
            Grid.SetColumn(txtTitre, 0);
            Grid.SetColumnSpan(txtTitre, 3);
            grdMain.Children.Add(txtTitre);

            for (int colonne = 0; colonne < 3; colonne++)
            {
                Button btn = new Button();
                btn.Content = "Bouton " + (colonne + 1);
                btn.Margin = new Thickness(8);
                btn.Height = 45;
                Grid.SetRow(btn, 1);
                Grid.SetColumn(btn, colonne);
                grdMain.Children.Add(btn);
            }

            StackPanel stkBloc = new StackPanel();
            stkBloc.Orientation = Orientation.Vertical;
            stkBloc.Margin = new Thickness(8);

            TextBlock txtNom = new TextBlock();
            txtNom.Text = "Votre prénom :";
            txtNom.Margin = new Thickness(0, 0, 0, 8);
            stkBloc.Children.Add(txtNom);

            TextBox txtSaisie = new TextBox();
            txtSaisie.Height = 32;
            stkBloc.Children.Add(txtSaisie);

            Grid.SetRow(stkBloc, 2);
            Grid.SetColumn(stkBloc, 0);
            Grid.SetColumnSpan(stkBloc, 2);
            grdMain.Children.Add(stkBloc);

            ComboBox cboAnimaux = new ComboBox();
            cboAnimaux.Items.Add("Chat");
            cboAnimaux.Items.Add("Chien");
            cboAnimaux.SelectedIndex = 0;
            cboAnimaux.Margin = new Thickness(8);
            cboAnimaux.Height = 32;
            cboAnimaux.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(cboAnimaux, 2);
            Grid.SetColumn(cboAnimaux, 2);
            grdMain.Children.Add(cboAnimaux);

            return grdMain;
        }
    }
}
