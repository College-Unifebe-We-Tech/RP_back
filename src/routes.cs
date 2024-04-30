public static class Routing {
  public static void MapEndpoints(this WebApplication app) {
    HealthController healthController = new();
    CategoryController categoryController = new();
    EmployeeController employeeController = new();
    ProductController productController = new();
    ProductionItemController productionItemController = new();
    ProductionOrderController productionOrderController = new();
    SupplierController supplierController = new();

    app.MapGet("/", () => "Hello World!");

    app.MapGet("/health", (HttpContext context) => healthController.Check(context));

    // Category Routes
    app.MapGet("/category/{id}", (HttpContext context, int id) => categoryController.Get(context, id));
    app.MapPost("/category", (HttpContext context) => categoryController.Create(context));
    app.MapPut("/category/{id}", (HttpContext context, int id) => categoryController.Update(context, id));
    app.MapDelete("/category/{id}", (HttpContext context, int id) => categoryController.Delete( id));

    // Employee Routes
    app.MapGet("/employee/{id}", (HttpContext context, int id) => employeeController.Get(context, id));
    app.MapPost("/employee", (HttpContext context) => employeeController.Create(context));
    app.MapPut("/employee/{id}", (HttpContext context, int id) => employeeController.Update(context, id));
    app.MapDelete("/employee/{id}", (HttpContext context, int id) => employeeController.Delete( id));

    // Product Routes
    app.MapGet("/product/{id}", (HttpContext context, int id) => productController.Get(context, id));
    app.MapPost("/product", (HttpContext context) => productController.Create(context));
    app.MapPut("/product/{id}", (HttpContext context, int id) => productController.Update(context, id));
    app.MapDelete("/product/{id}", (HttpContext context, int id) => productController.Delete(id));

    // Production Item Routes
    app.MapGet("/production/item/{id}", (HttpContext context, int id) => productionItemController.Get(context, id));
    app.MapPost("/production/item", (HttpContext context) => productionItemController.Create(context));
    app.MapPut("/production/item/{id}", (HttpContext context, int id) => productionItemController.Update(context, id));
    app.MapDelete("/production/item/{id}", (HttpContext context, int id) => productionItemController.Delete(context, id));

    // Production Order Routes
    app.MapGet("/production/order/{id}", (HttpContext context, int id) => productionOrderController.Get(context, id));
    app.MapPost("/production/order", (HttpContext context) => productionOrderController.Create(context));
    app.MapPut("/production/order/{id}", (HttpContext context, int id) => productionOrderController.Update(context, id));
    app.MapDelete("/production/order/{id}", (HttpContext context, int id) => productionOrderController.Delete(id));

    // Supplier Routes
    app.MapGet("/supplier/{id}", (HttpContext context, int id) => supplierController.Get(context, id));
    app.MapPost("/supplier", (HttpContext context) => supplierController.Create(context));
    app.MapPut("/supplier/{id}", (HttpContext context, int id) => supplierController.Update(context, id));
    app.MapDelete("/supplier/{id}", (HttpContext context, int id) => supplierController.Delete(id));
  }
}
