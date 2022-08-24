using System.Collections.ObjectModel;

namespace AccountServiceTests;

public class StatementPrinterShould
{
    [Test]
    public void PrintStatementWithNoTransactions()
    {
        var printer = new Mock<IPrinter>();
        var sp = new StatementPrinter(printer.Object);
        var transactions = new List<Transaction>();
        
        sp.Print(new ReadOnlyCollection<Transaction>(transactions));
        
        printer.Verify(p => p.Print("Date || Amount || Balance"), Times.Once);
    }
}