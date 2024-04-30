public class SupplierController 
{
    private readonly SupplierService _service;

    public SupplierController() 
    {
        _service = new SupplierService(); 
    }

    public IResult Get(int id) 
    {
        try
        {
            Supplier supplierId = _service.Get(id);
            return Results.Json(supplierId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public IResult Create(Supplier supplier) 
    {
        try
        {
            int? supplierId = _service.Create(supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail);
            return Results.Json(supplierId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public void Update(int id, Supplier supplier) 
    {
        try 
        {
            _service.Update(id, supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail);
        }
        catch (Exception)
        {
            Results.Problem();
        }
    }
    
    public void Delete(int id) 
    {
        _service.Delete(id);
    }
}
