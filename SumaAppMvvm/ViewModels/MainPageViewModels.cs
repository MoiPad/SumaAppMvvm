
using SumaAppMvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SumaAppMvvm.ViewModels
{
    internal partial class MainPageViewModels : ObservableObject
    {
        [ObservableProperty]
        private double _valor1;

        [ObservableProperty] 
        private double _valor2;

        [ObservableProperty]
        private double _Resultado;

        [RelayCommand]
        private void SumarValores()
        {
            try
            {
                if (Validar())
                { 
                    Suma suma = new Suma();
                    suma.Valor1 = _valor1;
                    suma.Valor2 = _valor2;
                    Resultado = suma.SumarValores();
                }
            }
            catch (Exception ex) 
            {
                Alerta("Error: ", $"Se obtuvo una excepción: {ex.Message}");
            }
        
        }

        [RelayCommand]
        private void Limpiar() 
        {
            Valor1 = 0;
            Valor2 = 0;
            Resultado = 0;
        }

        private bool Validar()
        {
            if (Valor1 == 0)
            {
                Alerta("Avertencia!","Los campos no pueden ir vacios, ingrese el primer valor");
                return false;
            }
            else if (Valor2 == 0)
            {
                Alerta("Avertencia!", "Los campos no pueden ir vacios, ingrese el segundo valor");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Método personalizable para construir alertas
        /// </summary>
        /// <param name="Tipo">Tipo de Alerta</param>
        /// <param name="Mensaje">Mensaje de alerta</param>
        public void Alerta(String Tipo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Tipo, Mensaje, "Aceptar"));
        }

    }

}
