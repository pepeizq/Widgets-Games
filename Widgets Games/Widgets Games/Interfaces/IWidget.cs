using Microsoft.Windows.Widgets.Providers;

public interface IWidget
{
    string? ID { get; }
    string? Estado { get; }
    string? Enlace { get; }

    bool Activado { get; }

    void Activar();
    void Desactivar();
    void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs);
    void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs);
    string GetTemplateForWidget(string id);
    string GetDataForWidget();
}