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

    app.MapGet("/health", async () => await healthController.Check());

    // Category Routes
    app.MapGet("/category", async () => await categoryController.List());
    app.MapGet("/category/{id}", async (int id) => await categoryController.Get(id));
    app.MapPost("/category", async ([FromBody] Category category) => await categoryController.Create(category));
    app.MapPut("/category/{id}", async ([FromBody] Category category, int id) => await categoryController.Update(id, category));
    app.MapDelete("/category/{id}", async (int id) => await categoryController.Delete(id));

    // Employee Routes
    app.MapGet("/employee", async () => await employeeController.List());
    app.MapGet("/employee/{id}", async (int id) => await employeeController.Get(id));
    app.MapPost("/employee", async ([FromBody] Employee employee) => await employeeController.Create(employee));
    app.MapPut("/employee/{id}", async ([FromBody] Employee employee, int id) => await employeeController.Update(id, employee));
    app.MapDelete("/employee/{id}", async (int id) => await employeeController.Delete(id));

    // Product Routes
    app.MapGet("/product", async () => await productController.List());
    app.MapGet("/product/{id}", async (int id) => await productController.Get(id));
    app.MapPost("/product", async ([FromBody] Product product) => await productController.Create(product));
    app.MapPut("/product/{id}", async ([FromBody] Product product, int id) => await productController.Update(id, product));
    app.MapDelete("/product/{id}", async (int id) => await productController.Delete(id));

    // Production Item Routes
    app.MapGet("/production/item", async () => await productionItemController.List());
    app.MapGet("/production/item/{id}", async (int id) => await productionItemController.Get(id));
    app.MapPost("/production/item", async ([FromBody] ProductionItem productionItem) => await productionItemController.Create(productionItem));
    app.MapPut("/production/item/{id}", async ([FromBody] ProductionItem productionItem, int id) => await productionItemController.Update(id, productionItem));
    app.MapDelete("/production/item/{id}", async (int id) => await productionItemController.Delete(id));

    // Production Order Routes
    app.MapGet("/production/order", async () => await productionOrderController.List());
    app.MapGet("/production/order/{id}", async (int id) => await productionOrderController.Get(id));
    app.MapPost("/production/order", async ([FromBody] ProductionOrder productionOrder) => await productionOrderController.Create(productionOrder));
    app.MapPut("/production/order/{id}", async ([FromBody]  ProductionOrder productionOrder, int id) => await productionOrderController.Update(id, productionOrder));
    app.MapDelete("/production/order/{id}", async (int id) => await productionOrderController.Delete(id));

    // Supplier Routes
    app.MapGet("/supplier", async () => await supplierController.List());
    app.MapGet("/supplier/{id}", async (int id) => await supplierController.Get(id));
    app.MapPost("/supplier", async ([FromBody] Supplier supplier) => await supplierController.Create(supplier));
    app.MapPut("/supplier/{id}", async ([FromBody] Supplier supplier, int id) => await supplierController.Update(id, supplier));
    app.MapDelete("/supplier/{id}", async (int id) => await supplierController.Delete(id));
  }
}
