using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Calculatrice.Mac;

public partial class MainWindow : Window
{
    private static readonly CultureInfo Culture = CultureInfo.GetCultureInfo("fr-BE");
    private decimal? _left;
    private string? _operator;
    private bool _startNewNumber;

    public MainWindow() => InitializeComponent();

    private void OnDigit(object? sender, RoutedEventArgs e)
    {
        var digit = ((Button)sender!).Content!.ToString();
        Display.Text = _startNewNumber || Display.Text == "0" || Display.Text == "Erreur"
            ? digit
            : Display.Text + digit;
        _startNewNumber = false;
    }

    private void OnDecimal(object? sender, RoutedEventArgs e)
    {
        if (_startNewNumber || Display.Text == "Erreur")
        {
            Display.Text = "0";
            _startNewNumber = false;
        }
        if (!Display.Text!.Contains(',')) Display.Text += ",";
    }

    private void OnOperator(object? sender, RoutedEventArgs e)
    {
        if (_operator != null && !_startNewNumber) Calculate();
        if (!decimal.TryParse(Display.Text, NumberStyles.Number, Culture, out var value)) return;
        _left = value;
        _operator = ((Button)sender!).Content!.ToString();
        _startNewNumber = true;
    }

    private void OnEquals(object? sender, RoutedEventArgs e) => Calculate();

    private void Calculate()
    {
        if (_left is null || _operator is null ||
            !decimal.TryParse(Display.Text, NumberStyles.Number, Culture, out var right)) return;
        try
        {
            var result = _operator switch
            {
                "+" => _left.Value + right,
                "-" => _left.Value - right,
                "*" => _left.Value * right,
                "/" => _left.Value / right,
                _ => right
            };
            Display.Text = result.ToString(Culture);
        }
        catch (Exception exception) when (exception is DivideByZeroException or OverflowException)
        {
            Display.Text = "Erreur";
        }
        _left = null;
        _operator = null;
        _startNewNumber = true;
    }

    private void OnClear(object? sender, RoutedEventArgs e)
    {
        Display.Text = "0";
        _left = null;
        _operator = null;
        _startNewNumber = false;
    }
}
