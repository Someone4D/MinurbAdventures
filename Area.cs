public static class Area
{
    public static List<string> GetAllAreaNames()
    {
        string[] names = Enum.GetNames(typeof(AreaName));

        return names.ToList();
    }
    
    public enum AreaName
    {
        Forest,
        Cavern,
        Beach,
        Mountain,
        Volcano,
        Snowfield
    }
}