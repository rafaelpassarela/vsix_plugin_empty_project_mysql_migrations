using EnvDTE;
using System.Windows;
using System.Windows.Controls;

namespace ApiGenerator.ToolWindows
{
    public partial class ApiConfigToolWindowControl : UserControl
    {
        private ApiGeneratorState _state;

        public ApiConfigToolWindowControl(ApiGeneratorState state)
        {
            _state = state;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string version = _state.DTE.FullName;

            string message;

            var solution = _state.DTE.Solution;
            if (solution.IsOpen)
            {
                message = "Solution Loaded: ";
                Projects projList = (Projects)_state.DTE.ActiveSolutionProjects;
                if (projList.Count > 0)
                {
                    message += " Active project: ";
                    Project proj = projList.Item(0);

                    message += proj.Name;
                } else
                {
                    message += "no project";
                }
                
            } else
            {
                message = "There are no solutions loaded.";
            }
                

            //Microsoft.VisualStudio.ProjectSystem.VS.Implementation.Package.Automation.OAProject

            MessageBox.Show( message );
        }
    }
}
