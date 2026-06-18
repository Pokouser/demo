USE demo;
GO

SELECT
    o.OrderNumber AS [Номер заказа],
    o.OrderDate AS [Дата заказа],
    c.Name AS [Заказчик],
    SUM(oi.Quantity * sm.Quantity * m.Price) AS [Полная стоимость материалов]
FROM CustomerOrders o
JOIN Counterparties c ON c.CounterpartyId = o.CustomerId
JOIN CustomerOrderItems oi ON oi.CustomerOrderId = o.CustomerOrderId
JOIN Specifications s ON s.ProductId = oi.ProductId
JOIN SpecificationMaterials sm ON sm.SpecificationId = s.SpecificationId
JOIN Materials m ON m.MaterialId = sm.MaterialId
WHERE o.OrderNumber = 3
GROUP BY o.OrderNumber, o.OrderDate, c.Name;
