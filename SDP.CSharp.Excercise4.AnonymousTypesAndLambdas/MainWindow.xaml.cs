using SDP.CSharp.Excercise4.AnonymousTypesAndLambdas.ViewModel;
using System.Windows;

namespace SDP.CSharp.Excercise4.AnonymousTypesAndLambdas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // create and assign view model instance to the window's data context on Loaded event 
            Loaded += (s,e) => DataContext = new TreeViewViewModel();
        }
    }
}
