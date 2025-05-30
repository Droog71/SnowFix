using System.Collections;

public class SnowFix : FortressCraftMod
{
    private PlayerInventory playerInventory;
    private IEnumerator inventoryCoroutine;
    private bool inventoryCoroutineBusy;

    public override ModRegistrationData Register()
    {
        ModRegistrationData modRegistrationData = new ModRegistrationData();
        return modRegistrationData;
    }

    public void Update()
    {
        if (playerInventory == null)
        {
            playerInventory = WorldScript.mLocalPlayer.mInventory;
        }
        else
        {
            if (inventoryCoroutineBusy == false)
            {
                inventoryCoroutine = ReplaceItems();
                StartCoroutine(inventoryCoroutine);
            }
        }
    }

    private IEnumerator ReplaceItems()
    {
        inventoryCoroutineBusy = true;
        Translator translator = new Translator();
        ItemBase[,] items = playerInventory.maItemInventory;

        foreach (ItemBase thisItem in items)
        {
            if (thisItem != null)
            {
                if (translator.IsSnow(thisItem.GetName()))
                {
                    int count = thisItem.GetAmount();
                    playerInventory.RemoveSpecificItem(thisItem);
                    TerrainDataEntry terrainDataEntry = TerrainData.mEntries[21];
                    playerInventory.CollectValue(21, terrainDataEntry.DefaultValue, count);
                }
            }
            yield return null;
        }
        inventoryCoroutineBusy = false;
    }
}