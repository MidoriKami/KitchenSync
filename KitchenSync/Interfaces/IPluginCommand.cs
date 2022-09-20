﻿namespace KitchenSync.Interfaces;

internal interface IPluginCommand
{
    string? CommandArgument { get; }

    void Execute(string? additionalArguments);
}