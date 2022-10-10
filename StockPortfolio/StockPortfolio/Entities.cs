namespace StockPortfolio;

public record struct Share(string Name);
public record struct SharePrice(decimal Value);
public record struct ShareUnits(int Number);
public record struct Transaction(Share Share, ShareUnits Units, DateOnly Date);