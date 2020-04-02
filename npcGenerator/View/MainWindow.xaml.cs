using npcGenerator.Model;
using System.Windows;

namespace npcGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(); // Связка представления и модели Phone
        }
    }
}
