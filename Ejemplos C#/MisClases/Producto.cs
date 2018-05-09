public class Producto
{
    private decimal _precioPorDefecto = 0.5m;


    public string Codigo { get; private set; }
    public string Nombre {get; set; }
    public decimal Precio {get; set; }

    public Producto()
    {
        Precio = 0.5m;
    }


    public Producto (string codigo, string nombre)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = _precioPorDefecto;
    }
    public Producto(string codigo, string nombre, decimal precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
    }
    

    public string GetDescripcionProducto()
    {
        return Codigo + " - " + Nombre +  Precio + " Con IVA: "  + GetPrecioConIva();
    }

    public decimal GetPrecioConIva()
    {

        return Precio * 1.21m;
    } 

    private string GetCodigo()
    {
        return "Cod.:" + Codigo;
    }
}