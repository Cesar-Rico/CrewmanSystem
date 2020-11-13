package pe.edu.pucp.CrewmanSystem.mysql;

import pe.edu.pucp.CrewmanSystem.config.DBManager;
import pe.edu.pucp.CrewmanSystem.dao.ProductoXZonaDAO;
import pe.edu.pucp.CrewmanSystem.model.ProductoXZona;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.CrewmanSystem.model.Producto;
import pe.edu.pucp.CrewmanSystem.model.Zona;

public class ProductoXZonaMySQL implements ProductoXZonaDAO{
    Connection con;
    CallableStatement cs;
    ResultSet rs;
    
    @Override
    public int insertar(ProductoXZona productoXZona)
    {
        int resultado = 0;
        try{
            Class.forName("com.mysql.cj.jdbc.Driver");
            con = DriverManager.getConnection(DBManager.urlMySQL, DBManager.user, DBManager.pass);
            String sql ="{ call INSERTAR_PRODUCTOXZONA(?,?,?,?,?)}";
            cs = con.prepareCall(sql);
            cs.registerOutParameter("_ID_PRODUCTOXZONA", java.sql.Types.INTEGER);
            cs.setInt("_ID_PRODUCTO", productoXZona.getProducto().getIdProducto());
            cs.setInt("_ID_ZONA", productoXZona.getZona().getIdZona());
            cs.setDouble("_PRECIOREAL", productoXZona.getPrecioReal());
            cs.setDate("_FECHA_INICIO", new java.sql.Date(new Date().getTime()));
            cs.executeUpdate();
            resultado = cs.getInt("_ID_PRODUCTOXZONA");
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }
    
    @Override
    public ArrayList<ProductoXZona> listar(String nombre,String familiaStr,String subFamiliaStr,String marcaStr,int idZona){
        ArrayList<ProductoXZona> productoszonas = new ArrayList<>();
        try{
            Class.forName("com.mysql.cj.jdbc.Driver");
            con = DriverManager.getConnection(DBManager.urlMySQL, DBManager.user, DBManager.pass);
            String sql ="{ call LISTAR_PRODUCTOXZONA (?,?,?,?,?) }";
            cs = con.prepareCall(sql);
            cs.setString("_NOMBRE", nombre);
            cs.setString("_F_DESCRIPCION", familiaStr);
            cs.setString("_S_DESCRIPCION", subFamiliaStr);
            cs.setString("_M_NOMBRE", marcaStr);
            cs.setInt("_ID_ZONA", idZona);
            cs.executeUpdate();
            rs = cs.getResultSet();
            while(rs.next()){
                ProductoXZona pz=new ProductoXZona();
                Producto p=new Producto();
                pz.setIdProductoXZona(rs.getInt("ID_PRODUCTOXZONA"));
                                
                p.setIdProducto(rs.getInt("ID_PRODUCTO"));
                p.setNombre(rs.getString("NOMBRE"));
                p.getSubFamilia().setDescripcionSubFamilia(rs.getString("S_DESCRIPCION"));
                p.getSubFamilia().getFamilia().setDescripcion(rs.getString("F_DESCRIPCION"));
                p.getMarca().setNombre(rs.getString("M_NOMBRE"));
                
                pz.setPrecioReal(rs.getDouble("PRECIOREAL"));
                p.setPrecioSugerido(rs.getDouble("PRECIO_SUGERIDO"));
                p.setCantUnidad(rs.getInt("CANT_UNIDADES"));
                p.setUnidades(rs.getString("UNIDADES"));
                p.setStock(rs.getInt("STOCK"));
                
                pz.setProducto(p);
                productoszonas.add(pz);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{
                con.close();
            }catch(Exception ex){
                System.out.println(ex.getMessage());
            }
        }
        return productoszonas;
    }
}
