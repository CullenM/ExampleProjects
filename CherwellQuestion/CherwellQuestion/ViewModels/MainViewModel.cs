using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using Classes.CherwellQuestion;
using Views.CherwellQuestion;
using Controls.CherwellQuestion;

namespace ViewModels.CherwellQuestion
{
    public class MainViewModel: INotifyPropertyChanged
    {

        #region fields
        private string _clickedTriangleName;
        private string _triangleName;
        private int _rowNumber;
        private int _columnNumber;
        private int _v1x;
        private int _v1y;
        private int _v2x;
        private int _v2y;
        private int _v3x;
        private int _v3y;
        private ICommand _getTriangleCommand;
        private Visibility _showAnswerVisibility;
        private Visibility _showNotFoundVisibility;

        private readonly string[] letters = new string[] {"A", "B", "C", "D", "E", "F", "G", "H" };
        private MainWindow window;
        private List<Triangle> triangles;
        #endregion
        
        #region constructor
        public MainViewModel()
        {
            _getTriangleCommand = new DelegateCommand(GetTriangle);
            ShowNotFoundVisibility = Visibility.Collapsed;
            ShowAnswerVisibility = Visibility.Collapsed;
            triangles = new List<Triangle>();
            window = new MainWindow(this);
            window.Show();

            CreateGrid();
        }
        #endregion

        #region methods
        private void CreateGrid()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    string text = letters[i] + (j + 1).ToString();
                    Triangle triangle = new Triangle { Text = text, Row = i, Column = j };
                    triangles.Add(triangle);

                    bool orientation = j % 2 == 0;
                    TriangleButton triangleButton = new TriangleButton(orientation, triangle);
                    triangleButton.TriangleClicked += TriangleClicked;

                    window.AddTriangleToGrid(triangleButton);
                }
            }
        }

        private Triangle FindTriangle(int row, int column)
        {
            foreach (Triangle triangle in triangles)
            {
                if (triangle.Row == row)
                {
                    if (triangle.Column == column)
                    {
                        return triangle;
                    }
                }
            }
            return null;
        }

        private void GetPoints(Triangle triangle)
        {
            List<Tuple<int, int>> points = triangle.GetPoints();
            ClickedTriangleName = triangle.Text;

            foreach (Tuple<int, int> point in points)
            {
                window.AddTrianglePointLabel(point.Item1, point.Item2);
            }
        }

        private void GetTriangle()
        {
                int row = ((Math.Max(Math.Max(VertexOneY, VertexTwoY), VertexThreeY)) / 10) - 1;
                int column = (VertexOneX + VertexTwoX + VertexThreeX) / 15;

                Triangle triangle = FindTriangle(row, column);

            if (triangle != null)
            {
                TriangleName = triangle.Text;
                RowNumber = triangle.Row;
                ColumnNumber = triangle.Column/2;
                ShowAnswerVisibility = Visibility.Visible;
                ShowNotFoundVisibility = Visibility.Collapsed;
            }
            else
            {
                ShowAnswerVisibility = Visibility.Collapsed;
                ShowNotFoundVisibility = Visibility.Visible;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void TriangleClicked(object sender, EventArgs e)
        {
            TriangleButton button = sender as TriangleButton;
            window.ClearResultPanel();
            GetPoints(button.BaseTriangle);
        }
        #endregion

        #region properties
        public ICommand GetTriangleCommand
        {
            get { return _getTriangleCommand; }
        }

        public string ClickedTriangleName
        {
            get { return _clickedTriangleName; }
            set
            {
                _clickedTriangleName = value;
                NotifyPropertyChanged("ClickedTriangleName");
            }
        }

        public int ColumnNumber
        {
            get { return _columnNumber; }
            set
            {
                _columnNumber = value;
                NotifyPropertyChanged("ColumnNumber");
            }
        }

        public int RowNumber
        {
            get { return _rowNumber; }
            set
            {
                _rowNumber = value;
                NotifyPropertyChanged("RowNumber");
            }
        }

        public Visibility ShowAnswerVisibility
        {
            get { return _showAnswerVisibility; }
            set
            {
                _showAnswerVisibility = value;
                NotifyPropertyChanged("ShowAnswerVisibility");
            }
        }

        public Visibility ShowNotFoundVisibility
        {
            get { return _showNotFoundVisibility; }
            set
            {
                _showNotFoundVisibility = value;
                NotifyPropertyChanged("ShowNotFoundVisibility");
            }
        }

        public string TriangleName
        {
            get { return _triangleName; }
            set
            {
                _triangleName = value;
                NotifyPropertyChanged("TriangleName");
            }
        }

        public int VertexOneX
        {
            get { return _v1x; }
            set { _v1x = value; }
        }

        public int VertexOneY
        {
            get { return _v1y; }
            set { _v1y = value; }
        }

        public int VertexTwoX
        {
            get { return _v2x; }
            set { _v2x = value; }
        }

        public int VertexTwoY
        {
            get { return _v2y; }
            set { _v2y = value; }
        }

        public int VertexThreeX
        {
            get { return _v3x; }
            set { _v3x = value; }
        }

        public int VertexThreeY
        {
            get { return _v3y; }
            set { _v3y = value; }
        }
        #endregion
    }
}
