using ApiGenerator.ToolWindows;
using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGenerator.Controller
{
    public class ApiController
    {
        private ApiGeneratorState _state;

        public Solution GetSolution => _state.DTE.Solution;
        public Projects GetProjects => GetSolution.Projects;
        public Project GetActiveProject
        {
            get
            {
                Project activeProject = null;

                Array activeSolutionProjects = _state.DTE.ActiveSolutionProjects as Array;
                if (activeSolutionProjects != null && activeSolutionProjects.Length > 0)
                {
                    activeProject = activeSolutionProjects.GetValue(0) as Project;
                }

                return activeProject;
            }
        }
        public bool SolutionIsOpen => GetSolution != null && GetSolution.IsOpen;

        public ApiController(ApiGeneratorState state)
        {
            _state = state;
        }
    }
}
