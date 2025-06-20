using System;

namespace Sanura.Movil.Utils;

public class Notifier
{
    public static async Task ShowAsync(string title, string message)
    {
        if(Application.Current != null)
        {
            var window = Application.Current.Windows.First();
            if(window.Page != null)
            {
                await window.Page.DisplayAlert(title, message, "Aceptar").ConfigureAwait(false);
            }
        }
    }
}
