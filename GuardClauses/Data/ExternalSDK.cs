public class ExternalSDK
{
    public bool TryExternalMethod(out int? val)
    {
        val = null;
        try
        {
            val = 0;
            return true;
        }
        catch
        {
            return false;
        }
    }
}