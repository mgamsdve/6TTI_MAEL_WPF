using System.Globalization;

namespace Calculatrice.Wpf;

public class MethodesDuProjet
{
    public string Calculer(decimal a, decimal b, string operation)
    {
        if (operation == "/" && b == 0)
            return "Division par zéro impossible.";

        try
        {
            decimal resultat = operation switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a / b,
                _ => throw new ArgumentException("Opération inconnue.")
            };
            var culture = CultureInfo.GetCultureInfo("fr-BE");
            return $"{a.ToString(culture)} {operation} {b.ToString(culture)} = {resultat.ToString(culture)}";
        }
        catch (OverflowException)
        {
            return "Le résultat est trop grand.";
        }
    }
}
