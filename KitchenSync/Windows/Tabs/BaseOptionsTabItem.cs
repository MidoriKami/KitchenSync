using KamiLib.Drawing;
using KamiLib.Interfaces;
using KitchenSync.Data;

namespace KitchenSync.Windows.Tabs;

public class BaseOptionsTabItem : ITabItem
{
    private static Configuration Settings => Service.Configuration;
    public string TabName => "Options";
    public bool Enabled => true;
    
    public void Draw()
    {
        InfoBox.Instance
            .AddTitle("Transparency", out var innerWidth, 0.90f)
            .AddDragFloat("", Settings.HotbarSettings.Transparency, 0.10f, 1.0f, innerWidth)
            .Draw();

        InfoBox.Instance
            .AddTitle("Extra Options", 0.90f)
            .AddConfigCheckbox("Disable in Sanctuaries", Settings.HotbarSettings.DisableInSanctuaries)
            .AddConfigCheckbox("Apply to Macros", Settings.HotbarSettings.IncludeMacros)
            .AddConfigCheckbox("Apply to not yet unlocked", Settings.HotbarSettings.IncludeNotUnlocked, "Applies transparency to skills that you do not have unlocked")
            .Draw();
    }
}