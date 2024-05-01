using Microsoft.AspNetCore.Mvc;

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
    app.MapGet("/category", async () => await categoryController.List());
    app.MapGet("/category/{id}", async (int id) => await categoryController.Get(id));
    app.MapPost("/category", async ([FromBody] Category category) => await categoryController.Create(category));
    app.MapPut("/category/{id}", async ([FromBody] Category category, int id) => await categoryController.Update(id, category));
    app.MapDelete("/category/{id}", async (int id) => await categoryController.Delete(id));

    // Employee Routes
    app.MapGet("/employee/{id}", (int id) => employeeController.Get(id));
    app.MapPost("/employee", ([FromBody] Employee employee) => employeeController.Create(employee));
    app.MapPut("/employee/{id}", ([FromBody] Employee employee, int id) => employeeController.Update(id, employee));
    app.MapDelete("/employee/{id}", (int id) => employeeController.Delete(id));

    // Product Routes
    app.MapGet("/product/{id}", (int id) => productController.Get(id));
    app.MapPost("/product", ([FromBody] Product product) => productController.Create(product));
    app.MapPut("/product/{id}", ([FromBody] Product product, int id) => productController.Update(id, product));
    app.MapDelete("/product/{id}", (int id) => productController.Delete(id));

    // Production Item Routes
    app.MapGet("/production/item/{id}", (int id) => productionItemController.Get(id));
    app.MapPost("/production/item", ([FromBody] ProductionItem productionItem) => productionItemController.Create(productionItem));
    app.MapPut("/production/item/{id}", ([FromBody] ProductionItem productionItem, int id) => productionItemController.Update(id, productionItem));
    app.MapDelete("/production/item/{id}", (int id) => productionItemController.Delete(id));

    // Production Order Routes
    app.MapGet("/production/order/{id}", (int id) => productionOrderController.Get(id));
    app.MapPost("/production/order", ([FromBody] ProductionOrder productionOrder) => productionOrderController.Create(productionOrder));
    app.MapPut("/production/order/{id}", ([FromBody] ProductionOrder productionOrder, int id) => productionOrderController.Update(id, productionOrder));
    app.MapDelete("/production/order/{id}", (int id) => productionOrderController.Delete(id));

    // Supplier Routes
    app.MapGet("/supplier/{id}", (int id) => supplierController.Get(id));
    app.MapPost("/supplier", ([FromBody] Supplier supplier) => supplierController.Create(supplier));
    app.MapPut("/supplier/{id}", ([FromBody] Supplier supplier, int id) => supplierController.Update(id, supplier));
    app.MapDelete("/supplier/{id}", (int id) => supplierController.Delete(id));
  }
}
