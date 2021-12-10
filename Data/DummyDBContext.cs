
using System.Linq;
using DockerizedCrud.Models;
namespace DockerizedCrud.Data{
public class DummyDBContext:IDBContext{
    
public IQueryable<Product> Products {
    get=> new Product[] {
new Product { Name = "Prod1", Category = "Cat1", Price = 100 },
new Product { Name = "Prod2", Category = "Cat1", Price = 100 },
new Product { Name = "Prod3", Category = "Cat2", Price = 100 },
new Product { Name = "Prod4", Category = "Cat2", Price = 100 },
}.AsQueryable();
set=>Products=value;
}


}

}