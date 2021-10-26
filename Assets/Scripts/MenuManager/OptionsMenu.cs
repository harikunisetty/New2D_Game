using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : Menu<OptionsMenu>
{
    public override void BackButton()
    {
        base.BackButton();

        /*if (dataManager != null)
            dataManager.Save();*/
    }
}
