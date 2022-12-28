﻿using Dalamud.Plugin;
using KitchenSync.Data;
using KitchenSync.System;
using KitchenSync.Windows;

namespace KitchenSync;

public sealed class KitchenSyncPlugin : IDalamudPlugin
{
    public string Name => "KitchenSync";

    public KitchenSyncPlugin(DalamudPluginInterface pluginInterface)
    {
        pluginInterface.Create<Service>();
        
        KamiLib.KamiLib.Initialize(pluginInterface, Name, () => Service.Configuration.Save());
        
        Service.Configuration = pluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Service.Configuration.Initialize(pluginInterface);

        KamiLib.KamiLib.WindowManager.AddWindow(new ConfigurationWindow());
        
        Service.HotbarManager = new HotbarManager();
    }

    public void Dispose()
    {
        KamiLib.KamiLib.Dispose();
        
        Service.HotbarManager.Dispose();
    }
}