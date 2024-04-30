public class SupplierController 
{
    private readonly SupplierService _service;

    public SupplierController() 
    {
        _service = new SupplierService(); 
    }

    public void Get(int id) 
    {
        var supplier =_service.Get(id);
         
        Results.Json(supplier);
        Results.Ok();
    }

    public void Create(Supplier supplier) 
    {
        int? supplierId = _service.Create(supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail);

        if (supplierId != null) 
        {
            Results.Json(supplierId);
            Results.Ok();
            
            return;
        }

        Results.Problem();
    }

    public void Update(int id, Supplier supplier) 
    {
        _service.Update(id, supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail);
    }
    
    public void Delete(int id) 
    {
        _service.Delete(id);
    }
}
