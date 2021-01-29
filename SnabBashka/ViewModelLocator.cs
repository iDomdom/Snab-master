using SnabBashka.ViewModels;

namespace SnabBashka
{
    class ViewModelLocator
    {
        public MainViewModel MainViewModel => DependencyInjection.Resolve<MainViewModel>();
        public MainPageViewModel MainPageViewModel => DependencyInjection.Resolve<MainPageViewModel>();
        public CreateInvoicePageViewModel CreateInvoicePageViewModel => DependencyInjection.Resolve<CreateInvoicePageViewModel>();
    }
}
