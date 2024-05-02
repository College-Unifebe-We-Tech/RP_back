public class SupplierController 
{
    private readonly SupplierService _service;

    public SupplierController() 
    {
        _service = new SupplierService(); 
    }

    public async Task<IResult> List()
    {
        List<Supplier> suppliers = await _service.List();

        return Results.Json(suppliers, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Get(int id) 
    {
        Supplier? supplierId = await _service.Get(id) ?? throw new Exception("does not exist");

        return Results.Json(supplierId, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Create(Supplier supplier) 
    {
        int? supplierId = await _service.Create(supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail) ?? throw new Exception("did not create");
            
        return Results.Json(supplierId, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Update(int id, Supplier supplier) 
    {
        await _service.Update(id, supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail);

        return Results.NoContent();
    }
    
    public async Task<IResult> Delete(int id) 
    {
        await _service.Delete(id);

        return Results.NoContent();
    }
}
