using G3_PatronFlyweight.Data;
using Microsoft.EntityFrameworkCore;

namespace G3_PatronFlyweight.Models
{
    public class ProductoFactory
    {
        private G3_PatronFlyweightContext _dbContext;

        public ProductoFactory(G3_PatronFlyweightContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Producto ObtenerProducto(string nombre, string descripcion, decimal precio)
        {
            Producto productoExistente = _dbContext.Productos.FirstOrDefault(p =>
                p.Nombre == nombre && p.Descripcion == descripcion && p.Precio == precio);

            if (productoExistente != null)
            {
                Console.WriteLine("Obteniendo producto existente: {0}", productoExistente);
                return productoExistente;
            }

            Console.WriteLine("Creando nuevo producto");
            Producto nuevoProducto = new Producto { Nombre = nombre, Descripcion = descripcion, Precio = precio };
            _dbContext.Productos.Add(nuevoProducto);
            _dbContext.SaveChanges();
            return nuevoProducto;
        }

    }
}
