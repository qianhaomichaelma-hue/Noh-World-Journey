using System.Collections.Generic;

public static class KeyInventory
{
    private static HashSet<string> keys = new HashSet<string>();

    public static void AddKey(string keyID)
    {
        keys.Add(keyID);
    }

    public static bool HasKey(string keyID)
    {
        return keys.Contains(keyID);
    }

    public static void ClearKeys()
    {
        keys.Clear();
    }
}
