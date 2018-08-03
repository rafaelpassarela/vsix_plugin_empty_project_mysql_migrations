using System.Windows;
using System.Windows.Controls;

namespace ApiGenerator.ToolWindows
{
    public partial class SampleToolWindowControl : UserControl
    {
        private ApiGeneratorState _state;

        public SampleToolWindowControl(ApiGeneratorState state)
        {
            _state = state;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string version = _state.DTE.FullName;

            MessageBox.Show($"Visual Studio is located here: '{version}'");
        }
    }
}
