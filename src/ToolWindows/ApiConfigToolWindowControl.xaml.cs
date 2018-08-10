using ApiGenerator.Controller;
using EnvDTE;
using System.Windows;
using System.Windows.Controls;

namespace ApiGenerator.ToolWindows
{
    public partial class ApiConfigToolWindowControl : UserControl
    {
        private ApiController _controller;

        public ApiConfigToolWindowControl(ApiGeneratorState state)
        {
            _controller = new ApiController(state);

            InitializeComponent();

            lblProjectName.Content = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string version = _state.DTE.FullName;

            if (_controller.SolutionIsOpen)
            {
                var proj = _controller.GetActiveProject;
                if (proj != null)
                {
                    lblProjectName.Content = proj.Name;
                } else
                {
                    lblProjectName.Content = "There are no projects actives.";
                }
                    

                //message = $"Solution Loaded: Projects { _controller.GetProjects.Count } , Active { _controller.GetActiveProject.FullName }";

                //var item = _controller.GetActiveProject.ProjectItems.Item(0);
                //item.


                //Projects projList = (Projects)_state.DTE.ActiveSolutionProjects;
                //if (projList.Count > 0)
                //{
                //    message += " Active project: ";
                //    Project proj = projList.Item(0);

                //    message += proj.Name;
                //}
                //else
                //{
                //    message += "no project";
                //}

            }
            else
            {
                lblProjectName.Content = "There are no solutions loaded.";
            }


            //Microsoft.VisualStudio.ProjectSystem.VS.Implementation.Package.Automation.OAProject

            MessageBox.Show(message);
        }
    }
}
