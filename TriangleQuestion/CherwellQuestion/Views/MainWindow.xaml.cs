using Controls.CherwellQuestion;
using System.Windows;
using System.Windows.Controls;
using ViewModels.CherwellQuestion;

namespace Views.CherwellQuestion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public void AddTriangleToGrid(TriangleButton triangleButton)
        {
            Grid.SetRow(triangleButton, triangleButton.BaseTriangle.Row);
            Grid.SetColumn(triangleButton, triangleButton.BaseTriangle.Column/2);
            TraingleGrid.Children.Add(triangleButton);
        }

        public void AddTrianglePointLabel(int x, int y)
        {
            Label label = new Label();
            label.Content = "{" + x + "," + y + "}";
            label.Margin = new Thickness(20, 0, 0, 0);
            label.FontSize = 16;
            ResultPanel.Children.Add(label);
        }

        public void ClearResultPanel()
        {
            ResultPanel.Children.Clear();
        }
    }
}
