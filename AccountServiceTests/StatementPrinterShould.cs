﻿using System.Collections.ObjectModel;

namespace AccountServiceTests;

public class StatementPrinterShould
{
    private StatementPrinter _statementPrinter = null!;
    private Mock<IPrinter> _printer = null!;

    private const string StatementHeader = "Date || Amount || Balance";

    [SetUp]
    public void SetUp()
    {
        _printer = new Mock<IPrinter>(MockBehavior.Strict);
        _statementPrinter = new StatementPrinter(_printer.Object);
    }

    [Test]
    public void PrintStatementWithNoTransactions()
    {
        List<Transaction> transactions = [];

        _statementPrinter.Print(new ReadOnlyCollection<Transaction>(transactions));

        _printer.Verify(p => p.Print(StatementHeader), Times.Once);
    }

    [Test]
    public void PrintStatementWithTransactions()
    {
        List<Transaction> transactions = [new(new DateTime(2012, 1, 10), 1000)];

        var sequence = new MockSequence();
        _printer.InSequence(sequence).Setup(p => p.Print(StatementHeader));
        _printer.InSequence(sequence).Setup(p => p.Print("10/01/2012 || 1000 || 1000"));

        _statementPrinter.Print(new ReadOnlyCollection<Transaction>(transactions));

        _printer.Verify(p => p.Print(StatementHeader), Times.Once);
        _printer.Verify(p => p.Print("10/01/2012 || 1000 || 1000"), Times.Once);
    }
}
