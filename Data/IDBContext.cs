
using System.Linq;
using DockerizedCrud.Models;
namespace DockerizedCrud.Data{
public interface IDBContext{
IQueryable<Product> Products{get;set;}

}}