public class SnowFix : FortressCraftMod
{
    private PlayerInventory playerInventory;

    // Mod registry.
    public override ModRegistrationData Register()
    {
        ModRegistrationData modRegistrationData = new ModRegistrationData();
        return modRegistrationData;
    }

    // Called once per frame.
    public void Update()
    {
        if (playerInventory == null)
        {
            playerInventory = WorldScript.mLocalPlayer.mInventory;
        }
        else
        {
            StackSnow();
        }
    }

    // Stacks snow in the player's inventory.
    private void StackSnow()
    {
        ItemBase[,] items = playerInventory.maItemInventory;
        foreach (ItemBase thisItem in items)
        {
            if (thisItem != null)
            {
                if (thisItem.GetName().Equals("Snow"))
                {
                    foreach (ItemBase otherItem in items)
                    {
                        if (otherItem != null)
                        {
                            if (otherItem.GetName().Equals("Snow"))
                            {
                                if (thisItem.GetAmount() > 0 && otherItem.GetAmount() > 0)
                                {
                                    if (thisItem.GetAmount() + otherItem.GetAmount() < ItemManager.GetMaxStackSize(thisItem))
                                    {
                                        int count = thisItem.GetAmount() + otherItem.GetAmount();
                                        playerInventory.RemoveSpecificItem(thisItem);
                                        playerInventory.RemoveSpecificItem(otherItem);
                                        TerrainDataEntry terrainDataEntry = TerrainData.mEntries[21];
                                        playerInventory.CollectValue(21, terrainDataEntry.DefaultValue, count);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}