using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CreationDynamique
{
    public partial class MainWindow : Window
    {
        private readonly Random nbAlea = new Random();

        public MainWindow()
        {
            InitializeComponent();

            // Le XAML ne contient aucun contrôle : tout est créé en C#.
            TabControl onglets = new TabControl();
            onglets.Items.Add(new TabItem
            {
                Header = "Exercice 1",
                Content = CreerExercice1()
            });
            onglets.Items.Add(new TabItem
            {
                Header = "Exercice 2 : ?",
                Content = CreerExercice2(false)
            });
            onglets.Items.Add(new TabItem
            {
                Header = "Exercice 2 : animaux",
                Content = CreerExercice2(true)
            });
            this.Content = onglets;
        }

        private Grid CreerExercice1()
        {
            Grid grdMain = new Grid();
            grdMain.Margin = new Thickness(20);

            // Trois colonnes et trois lignes de même taille.
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

            // Un bouton dans chaque colonne de la deuxième ligne.
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

        private Grid CreerExercice2(bool avecAnimaux)
        {
            Grid grdMain = new Grid();
            grdMain.Background = Brushes.White;

            // Les définitions sont stockées dans deux tableaux.
            ColumnDefinition[] colDef = new ColumnDefinition[4];
            RowDefinition[] rowDef = new RowDefinition[4];

            for (int i = 0; i < 4; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }

            // Une matrice contient les seize TextBlocks.
            TextBlock[,] textBlocks = new TextBlock[4, 4];

            for (int ligne = 0; ligne < 4; ligne++)
            {
                for (int colonne = 0; colonne < 4; colonne++)
                {
                    TextBlock txtCase = new TextBlock();
                    txtCase.Text = "?";
                    txtCase.FontSize = 36;
                    txtCase.FontFamily = new FontFamily("Segoe UI Emoji");
                    txtCase.HorizontalAlignment = HorizontalAlignment.Center;
                    txtCase.VerticalAlignment = VerticalAlignment.Center;
                    txtCase.Background = Brushes.Transparent;
                    txtCase.Padding = new Thickness(12);
                    txtCase.Cursor = Cursors.Hand;
                    txtCase.MouseDown += TextBlock_MouseDown;

                    textBlocks[ligne, colonne] = txtCase;
                    Grid.SetRow(textBlocks[ligne, colonne], ligne);
                    Grid.SetColumn(textBlocks[ligne, colonne], colonne);
                    grdMain.Children.Add(textBlocks[ligne, colonne]);
                }
            }

            if (avecAnimaux)
            {
                AttribuerAnimaux(textBlocks);
            }

            return grdMain;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock txtCase = (TextBlock)sender;
            txtCase.Text = "X";
        }

        private void AttribuerAnimaux(TextBlock[,] textBlocks)
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐈", "🐵", "🐷", "🐱", "🐐", "🐯", "🦊", "🐼",
                "🐴", "🦝", "🦨", "🐭", "🦉", "🐰", "🐀", "🦔"
            };

            foreach (TextBlock textBlock in textBlocks)
            {
                int index = nbAlea.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;

                // L'animal tiré est retiré pour éviter de le choisir à nouveau.
                animalEmoji.RemoveAt(index);
            }
        }
    }
}
