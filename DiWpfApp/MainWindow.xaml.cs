using System.Windows;
using DiWpfApp.StartupHelpers;
using WpfLib;

namespace DiWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private readonly IDataAccess _dataAccess;
    private readonly IAbstractFactory<ChildForm> _factory;
    private readonly IAbstractFactory<ThirdForm> _thirdForm;

    public MainWindow(IDataAccess dataAccess , IAbstractFactory<ChildForm> factory , IAbstractFactory<ThirdForm> thirdForm)
    {
        _dataAccess = dataAccess;
        _factory = factory;
        _thirdForm = thirdForm;
        InitializeComponent();
    }

    private void BtnGetData_OnClick(object sender, RoutedEventArgs e)
    {
        TxtData.Text = _dataAccess.GetData();
    }

    private void BtnOpenChildForm_OnClick(object sender, RoutedEventArgs e)
    {
        _factory.Create().Show();
    }

    private void BtnThirdForm_OnClick(object sender, RoutedEventArgs e)
    {
        _thirdForm?.Create().Show();
    }
}