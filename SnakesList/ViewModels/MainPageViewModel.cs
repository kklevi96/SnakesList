using CommunityToolkit.Mvvm.Input;
using SnakesList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakesList.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Snake> Snakes { get; } = new();

        [RelayCommand]
        async Task LoadSnakes()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("snakes.json");
                using var reader = new StreamReader(stream);
                var content = reader.ReadToEnd();
                var snakeList = JsonSerializer.Deserialize<List<Snake>>(content);
                if (Snakes.Count > 0)
                {
                    Snakes.Clear();
                }
                foreach (var item in snakeList)
                {
                    Snakes.Add(item);
                }
            }
            catch
            {
                await Shell.Current.DisplayAlert("Error!", "No snakes today!", "OK :(");
            }
        }

        [RelayCommand]
        public void GetNonVenomous()
        {
            var nv=Snakes.Where(s=>!s.IsVenomous).ToList();
            Snakes.Clear();
            foreach (var item in nv)
            {
                Snakes.Add(item);
            }
        }
    }
}
