using ReactiveUI.Maui;

namespace GettingStarted
{
    public partial class MainPage : ReactiveContentPage<ViewModel>
    {
        public MainPage(ViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
