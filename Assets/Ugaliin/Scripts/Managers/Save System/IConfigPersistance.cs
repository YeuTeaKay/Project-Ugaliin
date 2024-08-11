using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfigPersistance
{
    void LoadConfig(SettingsConfig data);
    void SaveConfig(SettingsConfig data);
}
