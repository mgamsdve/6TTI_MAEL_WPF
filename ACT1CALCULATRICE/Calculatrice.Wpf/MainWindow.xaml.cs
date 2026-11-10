using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculatrice.Wpf;

public partial class MainWindow : Window
{
    private static readonly CultureInfo Culture = CultureInfo.GetCultureInfo("fr-BE");

    public MainWindow()
    {
        InitializeComponent();
        TxtA.PreviewTextInput += VerifTextInput;
        TxtB.PreviewTextInput += VerifTextInput;
        DataObject.AddPastingHandler(TxtA, VerifCollage);
        DataObject.AddPastingHandler(TxtB, VerifCollage);
        BtnCalculer.MouseEnter += SurvolBouton;
        BtnCalculer.MouseLeave += FinSurvolBouton;
        BtnCalculer.Click += Calculer_Click;
    }

    private static bool EstEntier(string texteUser) => int.TryParse(texteUser, out _);

    private void VerifTextInput(object sender, TextCompositionEventArgs e)
    {
        var zone = (TextBox)sender;
        if (e.Text != "," && !EstEntier(e.Text))
            e.Handled = true;
        else if (e.Text == "," && zone.Text.Contains(','))
        {
            // La virgule déjà présente peut être remplacée si elle est sélectionnée.
            var selection = zone.Text.Substring(zone.SelectionStart, zone.SelectionLength);
            e.Handled = !selection.Contains(',');
        }
    }

    private void VerifCollage(object sender, DataObjectPastingEventArgs e)
    {
        if (!e.DataObject.GetDataPresent(DataFormats.UnicodeText))
        {
            e.CancelCommand();
            return;
        }
        var zone = (TextBox)sender;
        var collage = (string)e.DataObject.GetData(DataFormats.UnicodeText)!;
        var futurTexte = zone.Text.Remove(zone.SelectionStart, zone.SelectionLength)
                                 .Insert(zone.SelectionStart, collage);
        if (futurTexte.Count(c => c == ',') > 1 ||
            futurTexte.Any(c => !char.IsDigit(c) && c != ','))
            e.CancelCommand();
    }

    private void SurvolBouton(object sender, MouseEventArgs e)
    {
        BtnV.Visibility = Visibility.Visible;
        BtnV.Background = Brushes.Red;
    }

    private void FinSurvolBouton(object sender, MouseEventArgs e)
    {
        BtnV.Visibility = Visibility.Hidden;
        BtnV.Background = SystemColors.ControlBrush;
    }

    private void Calculer_Click(object sender, RoutedEventArgs e)
    {
        if (!decimal.TryParse(TxtA.Text, NumberStyles.Number, Culture, out var a) ||
            !decimal.TryParse(TxtB.Text, NumberStyles.Number, Culture, out var b))
        {
            MessageBox.Show(this, "Saisissez deux nombres valides.", "Saisie invalide",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var operation = ((ComboBoxItem)CboOperation.SelectedItem).Tag.ToString()!;
        var outils = new MethodesDuProjet();
        var message = outils.Calculer(a, b, operation);
        var pageResultat = new PageResultat(message);
        pageResultat.Closed += (_, _) => Show();
        Hide();
        pageResultat.Show();
    }
}
