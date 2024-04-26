public class SupplierController 
{
    private readonly SupplierService _service;

    public SupplierController() 
    {
        _service = new SupplierService(); 
    }

    public async void Get(HttpContext context, int id) {
        var supplier =_service.Get(id);
         
        await context.Response.WriteAsJsonAsync<Supplier>(supplier);
    }

    public async void Create(HttpContext context) 
    {
        var supplier = await context.Request.ReadFromJsonAsync<Supplier>();

        int? supplierId = _service.Create(supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail);

        if (supplierId != null) 
        {
            context.Response.StatusCode = 201;
            await context.Response.WriteAsync(supplierId.ToString());
        
            return;
        }

        context.Response.StatusCode = 500;
    }

    public async void Update(HttpContext context, int id) 
    {
        var supplier = await context.Request.ReadFromJsonAsync<Supplier>();

        _service.Update(id, supplier.SupplierName, supplier.SupplierCNPJ, supplier.SupplierAddress, supplier.SupplierEmail);
    }
    public void Delete(HttpContext context, int id) 
    {
        _service.Delete(id);
    }
}
