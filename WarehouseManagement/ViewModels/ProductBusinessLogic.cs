using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseManagement.DAL;
using WarehouseManagement.Models;

public class ProductBusinessLogic
{
    private WarehouseContext Context;
    public ProductBusinessLogic()
    {
        Context = new WarehouseContext();
    }

    public IQueryable<Product> GetProducts(ProductSearchModel searchModel)
    {
        var result = Context.Products.AsQueryable();
        if (searchModel != null)
        {
            if (searchModel.Id.HasValue)
                result = result.Where(x => x.ProductID == searchModel.Id);
            if (!string.IsNullOrEmpty(searchModel.Name))
                result = result.Where(x => x.Name.Contains(searchModel.Name));
            if (searchModel.Price.HasValue)
                result = result.Where(x => x.Price >= searchModel.Price);

        }
        return result;
    }
}