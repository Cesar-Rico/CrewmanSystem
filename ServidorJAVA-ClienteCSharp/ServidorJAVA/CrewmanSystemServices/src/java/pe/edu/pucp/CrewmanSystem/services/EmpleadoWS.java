package pe.edu.pucp.CrewmanSystem.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import pe.edu.pucp.CrewmanSystem.dao.EmpleadoDAO;
import pe.edu.pucp.CrewmanSystem.dao.PersonaDAO;
import pe.edu.pucp.CrewmanSystem.model.Empleado;
import pe.edu.pucp.CrewmanSystem.model.Persona;
import pe.edu.pucp.CrewmanSystem.mysql.EmpleadoMySQL;
import pe.edu.pucp.CrewmanSystem.mysql.PersonaMySQL;

@WebService(serviceName = "EmpleadoWS")
public class EmpleadoWS
{
    private EmpleadoDAO daoEmpleado;
    private Empleado empleado;
    private PersonaDAO daoPersona;
    
    public EmpleadoWS(){
        empleado = new Empleado();
        daoEmpleado = new EmpleadoMySQL();
        daoPersona = new PersonaMySQL();
    }
    @WebMethod(operationName = "insertarEmpleado")
    public int insertarEmpleado(@WebParam(name = "empleado") Empleado empleado){
        int resultado = 0;
        try{
            resultado = daoEmpleado.insertar(empleado);
        }catch(Exception e){
            System.out.println(e.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "actualizarEmpleado")
    public int actualizarEmpleado(@WebParam(name = "empleado") Empleado empleado) {
        int resultado=0;
        try{
            resultado = daoEmpleado.actualizar(empleado);
        }catch(Exception e){
            System.out.println(e.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "eliminarEmpleado")
    public int eliminarEmpleado(@WebParam(name = "idEmpleado") int idEmpleado) {
        int resultado=0;
        try{
            resultado = daoEmpleado.eliminar(idEmpleado);
        }catch(Exception e){
            System.out.println(e.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "permitirAccesoEmpleado")
    public Empleado permitirAccesoEmpleado(@WebParam(name = "usuario") String usuario, @WebParam(name = "contra") String contra ){
        try{
            empleado = daoEmpleado.permitirAccesoEmpleado(usuario,contra);
        }catch(Exception e){
            System.out.println(e.getMessage());
        }
        return empleado;
    }
    
    @WebMethod(operationName = "obtenerEmpleado")
    public int obtenerEmpleado(@WebParam(name = "empleado") Empleado empleado) {
        int resultado=0;
        try{
            resultado = daoEmpleado.obtenerEmpleado(empleado);
        }catch(Exception e){
            System.out.println(e.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "listarPorJefeVentas")
    public ArrayList<Empleado> listarPorJefeVentas(
            @WebParam(name = "idEmpleado") int idEmpleado,
            @WebParam(name = "nombre") String nombre,
            @WebParam(name = "apellidoPaterno") String apellidoPaterno,
            @WebParam(name = "apellidoMaterno") String apellidoMaterno) {
        ArrayList<Empleado> misEmpleados = new ArrayList<>();
        try{
            misEmpleados = daoEmpleado.listarPorJefeVentas(idEmpleado, nombre, apellidoPaterno, apellidoMaterno);
        }catch(Exception e){
            System.out.println(e.getMessage());
        }
        return misEmpleados;
    }
    
    @WebMethod(operationName = "listarPorJefeVentasYZona")
    public ArrayList<Empleado> listarPorJefeVentasYZona(
            @WebParam(name = "idEmpleado") int idEmpleado,
            @WebParam(name = "nombre") String nombre,
            @WebParam(name = "apellidoPaterno") String apellidoPaterno,
            @WebParam(name = "apellidoMaterno") String apellidoMaterno,
            @WebParam(name = "idZona") int idZona) {
        ArrayList<Empleado> misEmpleados = new ArrayList<>();
        try{
            misEmpleados = daoEmpleado.listarPorJefeVentasYZona(idEmpleado, nombre, apellidoPaterno, apellidoMaterno,idZona);
        }catch(Exception e){
            System.out.println(e.getMessage());
        }
        return misEmpleados;
    }
    @WebMethod(operationName = "insertarPersona")
    public int insertarPersona(@WebParam(name = "persona") Persona persona) {
        int resultado = 0;
        try{
            resultado = daoPersona.insertar(persona);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "actualizarPersona")
    public int actualizarPersona(@WebParam(name = "persona") Persona persona) {
        int resultado = 0;
        try{
            resultado = daoPersona.actualizar(persona);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "eliminarPersona")
    public int eliminarPersona(@WebParam(name = "idPersona") int idPersona) {
        int resultado = 0;
        try{
            resultado = daoPersona.eliminar(idPersona);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "mostrarPersona")
    public Persona mostrarPersona(@WebParam(name = "idPersona") int idPersona) {
        Persona resultado = new Persona();
        try{
            resultado = daoPersona.mostrar(idPersona);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "obtenerNumClientes")
    public ArrayList<Integer> obtenerNumClientes(@WebParam(name = "idPersona") int idPersona) {
        ArrayList<Integer> resultado = new ArrayList<>();
        try{
            resultado = daoEmpleado.obtenerNumClientes(idPersona);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "obtenerNumVisitas")
    public ArrayList<Integer> obtenerNumVisitas(@WebParam(name = "idPersona") int idPersona) {
        ArrayList<Integer> resultado = new ArrayList<>();
        try{
            resultado = daoEmpleado.obtenerNumVisitados(idPersona);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "cambiarContraseña")
    public int cambiarContraseña(@WebParam(name = "idEmpleado") int idEmpleado,
            @WebParam(name = "contraseñaActual") String contraseñaActual,
            @WebParam(name = "contraseñaNueva") String contraseñaNueva) {
        int resultado = 0;
        try{
            resultado = daoEmpleado.cambiarContraseña(idEmpleado, contraseñaActual, contraseñaNueva);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}
