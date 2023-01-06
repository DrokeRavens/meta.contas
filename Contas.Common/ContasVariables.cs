namespace Contas.Common;

public static class ContasVariables
{
    public static string ContaDbHost = Environment.GetEnvironmentVariable("ContaDbHost") ?? "localhost";
}