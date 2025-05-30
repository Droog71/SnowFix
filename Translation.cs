public class Translator
{
    private readonly string[] snowNames = { 
        "Snow", "Kar", "Schnee",  "Снег", "Śnieg", 
        "Neve", "Neige", "Lumi", "Sníh", "雪"
    };

    public bool IsSnow(string name)
    {
        for (int i = 0; i < snowNames.Length; ++i)
        {
            if (name.Equals(snowNames[i]))
            {
                return true;
            }
        }
        return false;
    }
}
