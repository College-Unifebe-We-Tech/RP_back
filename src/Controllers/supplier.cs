public class SupplierController 
{
    private readonly SupplierService _service;

    public SupplierController() 
    {
        _service = new SupplierService(); 
    }

    public IResult Get(int id) 
    {
        Supplier? supplierId = _service.Get(id) ?? throw new Exception("does not exist");

        return Results.Json(supplierId, statusCode: StatusCodes.Status200OK);
    }

    public IResult Create(Supplier supplier) 
    {
        int? supplierId = _service.Create(supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail) ?? throw new Exception("did not create");
            
        return Results.Json(supplierId, statusCode: StatusCodes.Status200OK);
    }

    public IResult Update(int id, Supplier supplier) 
    {
        _service.Update(id, supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail);

        return Results.Ok();
    }
    
    public IResult Delete(int id) 
    {
        _service.Delete(id);

        return Results.Ok();
    }
}
