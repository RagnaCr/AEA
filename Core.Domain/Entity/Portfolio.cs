using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entity;

/// <summary>
/// Portfolio класс который уже ссылкой связан с пользователем, отвечает за все транзакции пользователя подключенные 
/// к этому самому портфолио в себе хранит список апи из которых он получает актуальные данные которые обновляются в фоновом воркере, 
/// так же имеет метод для добавление транзакций вручную, как из официального списка Assets так и кастомных
/// </summary>
public class Portfolio
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; }

    // --- СВЯЗЬ С ОПЕРАЦИЯМИ (ТРАНЗАКЦИЯМИ) ---
    private readonly List<Operation> _operations = new();
    public IReadOnlyList<Operation> Operations => _operations.AsReadOnly();

    // --- СВЯЗЬ С API ПОДКЛЮЧЕНИЯМИ (Многие-ко-многим) ---
    private readonly List<PortfolioApiConnection> _apiConnections = new();
    public IReadOnlyList<PortfolioApiConnection> ApiConnections => _apiConnections.AsReadOnly();

    private Portfolio() { }

    public Portfolio(Guid userId, string name)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
    }

    /// <summary>
    /// Добавляет операцию в портфель, гарантируя целостность.
    /// </summary>
    public void AddOperation(Operation operation)
    {
        if (operation.PortfolioId != this.Id)
            throw new InvalidOperationException("Cannot add an operation belonging to another portfolio.");
        _operations.Add(operation);
    }

    /// <summary>
    /// Связывает существующее API подключение с этим портфелем.
    /// </summary>
    public void LinkApiConnection(ApiConnection connection)
    {
        if (connection.UserId != this.UserId)
            throw new InvalidOperationException("Cannot link a connection from another user.");

        if (!_apiConnections.Any(c => c.ApiConnectionId == connection.Id))
        {
            _apiConnections.Add(new PortfolioApiConnection(this.Id, connection.Id));
        }
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Portfolio name cannot be empty.", nameof(newName));
        }

        if (newName.Length > 100)
        {
            throw new ArgumentException("Portfolio name cannot be longer than 100 characters.", nameof(newName));
        }

        Name = newName.Trim();
    }
}