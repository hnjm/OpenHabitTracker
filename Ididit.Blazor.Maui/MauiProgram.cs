﻿using Ididit.Backup;
using Ididit.Blazor.Files;
using Ididit.Blazor.Layout;
using Ididit.Data;
using Ididit.EntityFrameworkCore;
using Ididit.Services;
using Microsoft.Extensions.Logging;

namespace Ididit.Blazor.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        string databasePath = "Ididit.db";

        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databasePath);
        }
        else if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databasePath);
        }

        builder.Services.AddServices();
        builder.Services.AddDataAccess(databasePath); // %localappdata%\Packages\...\LocalState - Environment.SpecialFolder.LocalApplicationData - FileSystem.Current.AppDataDirectory
        builder.Services.AddBackup();
        builder.Services.AddScoped<IOpenFile, OpenFile>();
        builder.Services.AddScoped<JsInterop>();
        builder.Services.AddScoped<ISaveFile, SaveFile>();
        builder.Services.AddScoped<INavBarFragment, NavBarFragment>();
        builder.Services.AddScoped<IAssemblyProvider, AssemblyProvider>();

        MauiApp mauiApp = builder.Build();

        IDataAccess dataAccess = mauiApp.Services.GetRequiredService<IDataAccess>();
        dataAccess.Initialize();

        return mauiApp;
    }
}
