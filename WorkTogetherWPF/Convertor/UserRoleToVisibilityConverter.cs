using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WorkTogetherLib.Class;

namespace WorkTogetherWPF.Convertor;

/// <summary>
/// Convertisseur pour afficher ou masquer un élément en fonction du rôle de l'utilisateur.
/// </summary>
class UserRoleToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Convertit le rôle de l'utilisateur en visibilité.
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Visibility visibility = Visibility.Collapsed;

        if (value is not null && ((User)value).Roles.Contains(((string)parameter)))
        {
            visibility = Visibility.Visible;
        }
        return visibility;
    }

    /// <summary>
    /// Non implémenté, car la conversion en arrière n'est pas nécessaire pour ce convertisseur.
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
