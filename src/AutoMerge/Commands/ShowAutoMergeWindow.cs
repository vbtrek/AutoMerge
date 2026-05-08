using System;
using System.ComponentModel.Design;
using Microsoft.TeamFoundation.Controls;
using Microsoft.VisualStudio.Shell;
using Microsoft.TeamFoundation.Controls.WPF.TeamExplorer;
using Task = System.Threading.Tasks.Task;

namespace AutoMerge.Commands
{
    internal sealed class ShowAutoMergeWindow
    {
        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;

            // must match the button GUID and ID specified in the .vsct file
            var cmdId = new CommandID(GuidList.ShowAutoMergeCmdSet, 0x0100);
            var cmd = new MenuCommand((s, e) => Execute(package), cmdId);
            commandService.AddCommand(cmd);
        }

        private static void Execute(AsyncPackage package)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            // Navigate to the AutoMerge page in Team Explorer
            var serviceProvider = package as IServiceProvider;
            if (serviceProvider != null)
            {
                TeamExplorerUtils.Instance.NavigateToPage(GuidList.AutoMergePageGuid.ToString(), serviceProvider, null);
            }
        }
    }
}
