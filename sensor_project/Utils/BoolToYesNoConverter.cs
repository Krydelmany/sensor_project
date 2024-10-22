using System;
using System.Globalization;
using System.Windows.Data;

namespace sensor_project.Utils
{
    public class BoolToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Verificação para garantir que o valor é booleano
            if (value is bool booleanValue)
            {
                return booleanValue ? "Sim" : "Não";
            }

            // Valor padrão caso o valor de entrada não seja booleano
            return "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Verificação para garantir que o valor é uma string válida
            if (value is string stringValue)
            {
                return stringValue.Trim().Equals("Yes", StringComparison.OrdinalIgnoreCase);
            }

            // Valor padrão caso a string não seja "Yes"
            return false;
        }
    }
}
