using System.Windows;

namespace Calculatrice.Wpf;

public partial class PageResultat : Window
{
    public PageResultat(string message)
    {
        InitializeComponent();
        LblResultat.Text = message;
    }

    private void Retour_Click(object sender, RoutedEventArgs e) => Close();
}
