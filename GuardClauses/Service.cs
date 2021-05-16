public partial class Service : GuardClauses.Core.IService
{
    private readonly ExternalSDK _externalDependency;
    public Service(ExternalSDK externalDependency) { _externalDependency = externalDependency; }

    public int TryCatchGuard(int initialVal)
    {
        int? externalResult;

        try
        {
            _externalDependency.TryExternalMethod(out externalResult);
        }
        catch
        {
            return initialVal;
        }

        return AddValues(initialVal, externalResult.Value);
    }

    public int GuardClause(int initialVal)
    {
        _externalDependency.TryExternalMethod(out int? externalResult);
        if (externalResult == null)
            return initialVal;

        return AddValues(initialVal, externalResult.Value);
    }

    public int LogicalHappyPath(int initialVal)
    {
        _externalDependency.TryExternalMethod(out int? externalResult);
        if (externalResult != null)
            return AddValues(initialVal, externalResult.Value);
        
        return initialVal;
    }
}