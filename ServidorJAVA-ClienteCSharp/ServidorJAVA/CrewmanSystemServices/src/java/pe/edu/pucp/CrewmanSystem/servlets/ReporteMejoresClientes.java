package pe.edu.pucp.CrewmanSystem.servlets;

import java.awt.Image;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.DriverManager;
import java.util.HashMap;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.swing.ImageIcon;
import net.sf.jasperreports.engine.JasperExportManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;
import net.sf.jasperreports.engine.util.JRLoader;
import pe.edu.pucp.CrewmanSystem.config.DBManager;

public class ReporteMejoresClientes extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try{
            String rutaReporte = ReporteMejoresClientes.class.getResource("/pe/edu/pucp/CrewmanSystem/reportes/MejoresClientes.jasper").getPath();
            rutaReporte = rutaReporte.replaceAll("%20", " ");
            JasperReport reporte = (JasperReport)JRLoader.loadObjectFromFile(rutaReporte);

            String rutaLogo = ReporteMejoresClientes.class.getResource("/pe/edu/pucp/CrewmanSystem/images/portada.jpg").getPath();
            rutaLogo = rutaLogo.replaceAll("%20", " ");

            ImageIcon icono = new ImageIcon(rutaLogo);
            Image imagen = icono.getImage();

            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection con = DriverManager.getConnection(DBManager.urlMySQL, DBManager.user, DBManager.pass);

            HashMap hm = new HashMap();
            hm.put("PORTADA", imagen);

            JasperPrint jp = JasperFillManager.fillReport(reporte, hm, con);

            con.close();
            JasperExportManager.exportReportToPdfStream(jp, response.getOutputStream());

        }catch(Exception e){
            System.out.println(e.getMessage());
        }
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
