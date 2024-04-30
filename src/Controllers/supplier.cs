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
            Supplier? supplierId = _service.Get(id) ?? throw new Exception("does not exist");

            return Results.Json(supplierId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }

    public IResult Create(Supplier supplier) 
    {
        try
        {
            int? supplierId = _service.Create(supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail) ?? throw new Exception("did not create");
            
            return Results.Json(supplierId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }

    public IResult Update(int id, Supplier supplier) 
    {
        try 
        {
            _service.Update(id, supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail);

            return Results.Ok();
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }
    
    public IResult Delete(int id) 
    {
        try 
        {
            _service.Delete(id);

            return Results.Ok();
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }    
    }
}
