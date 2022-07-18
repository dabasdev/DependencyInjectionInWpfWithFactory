namespace DiWpfApp.StartupHelpers;

public interface IAbstractFactory<out T>
{
    T Create();
}