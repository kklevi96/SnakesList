using SnakesList.ViewModels;

namespace SnakesList
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }
    }

}
