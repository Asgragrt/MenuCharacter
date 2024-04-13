using MelonLoader.Utils;
using MenuCharacter.Utils;

namespace MenuCharacter.Managers;

using static MelonEnvironment;

internal static class WatcherManager
{
    private static readonly FileSystemWatcher Watcher = new(UserDataDirectory);

    internal static void Init()
    {
        Logger.Debug("Initializing watcher settings.");

        // Initialize file watcher
        Watcher.NotifyFilter = NotifyFilters.LastWrite
                               | NotifyFilters.Size;

        Watcher.Filter = SettingsManager.SettingsFileName;

        EnableWatcherEvents();
    }

    internal static event FileSystemEventHandler WatcherEvent
    {
        add => Watcher.Changed += value;
        remove => Watcher.Changed -= value;
    }

    private static void EnableWatcherEvents()
    {
        Watcher.EnableRaisingEvents = true;
    }
}