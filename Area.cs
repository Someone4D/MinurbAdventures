public static class Area
{
    public static List<string> GetAllAreaNames()
    {
        AreaName[] areaNames = (AreaName[])Enum.GetValues(typeof(AreaName));
        List<string> names = new List<string>();
        
        foreach (var item in areaNames)
        {
            names.Add(item.ToString());
        }

        return names;
    }
    
    public enum AreaName
    {
        Forest,
        Cavern,
        Beach,
        Mountain,
        Volcano
    }
}