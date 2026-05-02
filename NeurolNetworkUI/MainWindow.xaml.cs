using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeurolNetworkUI
{
    public partial class MainWindow : Window
    {
        const int GRID_SIZE = 28; // 28 x 28 neurons
        const int PIXEL_SIZE = 16; // 1 neuron = 16 x 16

        Rectangle[,] rects = new Rectangle[GRID_SIZE, GRID_SIZE];
        bool isDrawing = false;

        public MainWindow()
        {
            InitializeComponent();
            BuildGrid();
        }

        void BuildGrid()
        {
            for (int row = 0; row < GRID_SIZE; row++) // 28 times
            {
                for (int col = 0; col < GRID_SIZE; col++) // Dont know yet
                {
                    
                    // Create a neutron 16x16 pixel

                    var rect = new Rectangle
                    {
                        Width = PIXEL_SIZE,
                        Height = PIXEL_SIZE,
                        Fill = Brushes.Black,
                        Stroke = new SolidColorBrush(Color.FromRgb(40,40,40)),
                        StrokeThickness = 0.3
                    };

                    // Created the black boxes

                    // If mouse isPressedDown change black to white
                    int r = row, c = col;

                    rect.MouseEnter += (s, e) => { if (isDrawing) Paint(r, c); };
                    rect.MouseDown += (s, e) => { isDrawing = true; Paint(r, c); };

                    rects[row, col] = rect;
                    PixelGrid.Items.Add(rect);
                }
            }
            MouseUp += (s, e) => isDrawing = false;
        }

        void Paint(int row, int col)
        {
            rects[row, col].Fill = Brushes.White;
        }

        void ResetGrid()
        {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    rects[row,col].Fill = Brushes.Black;
                }
            }
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetGrid();
        }
    }
}