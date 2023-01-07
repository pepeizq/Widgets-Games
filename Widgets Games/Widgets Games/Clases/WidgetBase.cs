using Microsoft.Windows.Widgets.Providers;

public abstract class WidgetBase : IWidget
{
    public string? ID { get; init; }
    public virtual string? Estado { get; set; }
    public string? Enlace { get; set; }

    public bool Activado { get; private set; }

    public virtual void Activar()
    {
        Activado = true;
    }

    public virtual void Desactivar()
    {
        Activado = false;
    }

    public virtual void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs) { }
    public virtual void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs) { }
    public abstract string GetTemplateForWidget(string id);
    public abstract string GetDataForWidget();
}