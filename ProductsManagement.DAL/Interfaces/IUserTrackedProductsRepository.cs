﻿using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface IUserTrackedProductsRepository
{
    public Task<IList<UserTrackedProducts>> GetProductsTrackedByUser(string userId);
    public Task<IEnumerable<UserTrackedProducts>> GetInfoAboutProductsTrackedByUser(string userId);
}