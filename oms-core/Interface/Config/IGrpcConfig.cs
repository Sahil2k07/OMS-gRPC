namespace oms_core.Interface.Config
{
    public interface IGrpcConfig
    {
        string? GetClientAddress();

        string? GetApiToken();

        string GetCertificatePath();
    }
}
