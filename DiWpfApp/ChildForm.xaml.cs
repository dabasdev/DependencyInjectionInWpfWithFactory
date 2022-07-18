using System.Windows;
using WpfLib;

namespace DiWpfApp;

/// <summary>
/// Interaction logic for ChildForm.xaml
/// </summary>
public partial class ChildForm 
{
    private readonly IDataAccess _dataAccess;

    public ChildForm(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
        InitializeComponent();
        MessageBox.Show(_dataAccess.GetData());
    }
}