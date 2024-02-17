namespace Bookify.Domain.Shared;
public record Currency {
    private Currency(string code) => Code = code;
    public string Code { get; init; }

    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static Currency FromCode(string code) {
        return All.FirstOrDefault(x => x.Code == code)
            ?? throw new ApplicationException($"The currency code {code} is invalid");
    }
    public static readonly IReadOnlyCollection<Currency> All = new[] {
        Usd,
        Eur
    };
}