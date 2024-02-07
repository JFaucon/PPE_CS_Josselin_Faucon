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
/// Convertisseur pour déterminer si un utilisateur a un rôle spécifique.
/// </summary>
class ObjectToisReadOnlyConverter : IValueConverter
{
    /// <summary>
    /// Convertit l'objet en un booléen indiquant si l'utilisateur a un rôle spécifique.
    /// </summary>
    /// <param name="value">L'objet à convertir (doit être de type User).</param>
    /// <param name="targetType">Le type de la propriété cible de la liaison (non utilisé).</param>
    /// <param name="parameter">Le paramètre supplémentaire (le rôle à vérifier).</param>
    /// <param name="culture">Les informations culturelles utilisées pour la conversion (non utilisées).</param>
    /// <returns>True si l'utilisateur a le rôle spécifié, sinon false.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isReadOnly = true;

        if (value is not null && ((User)value).Roles.Contains(((string)parameter)))
        {
            isReadOnly = true;
        }
        return isReadOnly;
    }

    /// <summary>
    /// Non implémenté car la conversion en arrière n'est pas nécessaire dans ce contexte.
    /// </summary>
    /// <param name="value">La valeur à convertir en arrière (non utilisée).</param>
    /// <param name="targetType">Le type de la propriété source de la liaison (non utilisé).</param>
    /// <param name="parameter">Le paramètre supplémentaire (non utilisé).</param>
    /// <param name="culture">Les informations culturelles utilisées pour la conversion (non utilisées).</param>
    /// <returns>Non implémenté, lève toujours une exception.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
