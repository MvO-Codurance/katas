namespace StockPortfolio;

public record struct Share(string Name);
public record struct SharePrice(decimal Value);
public record struct ShareUnits(int Number);
public record struct Transaction(Share Share, ShareUnits Units, DateOnly Date);
public record struct Statement(List<StatementLine> Lines);
public record struct StatementLine(Share Share, ShareUnits ShareUnits, SharePrice Price, decimal Value, DateOnly FirstOperationDate, string LastOperation);