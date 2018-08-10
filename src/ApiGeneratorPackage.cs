using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using ApiGenerator.ToolWindows;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace ApiGenerator
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(
        "Api Generator for MySQL Migrations",
        "Wizard for create Model, Controller, and Persistence classes for use with the \"Empty Project for MySQL and Migrations\" project (https://github.com/rafaelpassarela/empty_project_mysql_migrations)", 
        "1.0")]
    [ProvideToolWindow(
        typeof(ApiConfigToolWindow), 
        Style = VsDockStyle.Tabbed, 
        DockedWidth = 300, 
        Window = "DocumentWell", 
        Orientation = ToolWindowOrientation.Left)]
    [Guid("6e3b2e95-902b-4385-a966-30c06ab3c7a6")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class ApiGeneratorPackage : AsyncPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync();
            await ShowApiToolWindow.InitializeAsync(this);
        }

        public override IVsAsyncToolWindowFactory GetAsyncToolWindowFactory(Guid toolWindowType)
        {
            return toolWindowType.Equals(Guid.Parse(ApiConfigToolWindow.WindowGuidString)) ? this : null;
        }

        protected override string GetToolWindowTitle(Type toolWindowType, int id)
        {
            return toolWindowType == typeof(ApiConfigToolWindow) ? ApiConfigToolWindow.Title : base.GetToolWindowTitle(toolWindowType, id);
        }

        protected override async Task<object> InitializeToolWindowAsync(Type toolWindowType, int id, CancellationToken cancellationToken)
        {
            // Perform as much work as possible in this method which is being run on a background thread.
            // The object returned from this method is passed into the constructor of the SampleToolWindow 
            var dte = await GetServiceAsync(typeof(EnvDTE.DTE)) as EnvDTE80.DTE2;

            return new ApiGeneratorState
            {
                DTE = dte
            };
        }
    }
}
