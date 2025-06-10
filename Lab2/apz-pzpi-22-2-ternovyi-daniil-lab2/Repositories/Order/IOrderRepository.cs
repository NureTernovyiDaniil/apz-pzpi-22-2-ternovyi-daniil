﻿using ChefMate_backend.Models;

namespace ChefMate_backend.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> Retrieve();
        Task<List<Order>> RetrieveByPeriod(DateTime startDate, DateTime endDate, Guid organizationId);
        Task<List<Order>> RetrieveByDate(DateTime targetDate, Guid organizationId);
        Task<Order> Retrieve(Guid orderId);
        Task<bool> Insert(OrderDto order);
        Task<bool> Update(OrderDto order);
        Task<bool> Delete(Guid orderId);
        Task<bool> Delete(OrderDto order);
    }
}
