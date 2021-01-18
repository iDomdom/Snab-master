using DevExpress.Mvvm;
using SnabBashka.Pages;
using System.Windows.Controls;


namespace SnabBashka.ViewModels
{
    class MainViewModel : BindableBase
    {
        public Page CurrentPage { get; set; }

        public MainViewModel(PageService navigation)
        {
            navigation.OnPageChanged += page => CurrentPage = page;
            navigation.Navigate(new MainPage());
        }
    }
}
