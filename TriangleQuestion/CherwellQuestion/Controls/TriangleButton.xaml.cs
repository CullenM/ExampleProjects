using Classes.CherwellQuestion;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Controls.CherwellQuestion
{
    /// <summary>
    /// Interaction logic for TriangleButton.xaml
    /// </summary>
    public partial class TriangleButton : UserControl
    {
        public TriangleButton(bool orientDown, Triangle triangle)
        {
            InitializeComponent();
            BaseTriangle = triangle;
            CreateTriangle(orientDown, triangle.Text);
            DataContext = this;
        }

        public Triangle BaseTriangle { get; set; }

        private void CreateTriangle(bool orientation, string text)
        {
            if (orientation)
            {
                Triangle.Points = new PointCollection(new[] { new Point(75, 75), new Point(0, 0), new Point(0, 75) });
                TriangleText.Margin = new Thickness(5, 25, 0, 0);
            }
            else
            {                
                Triangle.Points = new PointCollection(new[] { new Point(75, 75), new Point(0, 0), new Point(75, 0) });
                TriangleText.Margin = new Thickness(30, 10, 0, 0);
            }
            TriangleText.Text = text;
        }

        public event EventHandler TriangleClicked;

        private void Triangle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EventHandler handler = TriangleClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
