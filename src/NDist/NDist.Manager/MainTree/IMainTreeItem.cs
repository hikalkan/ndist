using System;
using System.Windows.Controls;

namespace Hik.NDist.Manager.MainTree
{
    public interface IMainTreeItem : IDisposable
    {
        TreeView TreeView { get; set; }

        TreeViewItem TreeViewItem { get; set; }

        void Initialize();

        void CreateContextMenu();
    }
}